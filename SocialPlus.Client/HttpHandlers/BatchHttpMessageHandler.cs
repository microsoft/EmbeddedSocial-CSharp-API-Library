// <copyright file="BatchHttpMessageHandler.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace SocialPlus.Client.HttpMessageHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This HTTP handler provides batching support.
    /// It expects the caller to dispose HttpRequestMessage and HttpResponseMessage.
    /// It assumes the web service is supporting batch requests as per this MSDN article:
    /// https://blogs.msdn.microsoft.com/webdev/2013/11/01/introducing-batch-support-in-web-api-and-web-api-odata/
    /// i.e. requests are batched into a single request inside the multipart content.
    /// </summary>
    public class BatchHttpMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// To issue a batch call, do I do a POST, for example?
        /// </summary>
        private readonly HttpMethod batchMethod;

        /// <summary>
        /// The URL to issue the batch call to
        /// </summary>
        private readonly Uri batchURL;

        /// <summary>
        /// List of operations to issue in a batch
        /// </summary>
        private List<HttpRequestMessage> requests;

        /// <summary>
        /// Array of content from operations that are issued in a batch
        /// </summary>
        private HttpContent[] responses;

        /// <summary>
        /// Tells all tasks that they can proceed
        /// </summary>
        private ManualResetEvent batchCompleted;

        /// <summary>
        /// Initializes a new instance of the <see cref="BatchHttpMessageHandler"/> class.
        /// </summary>
        /// <param name="method">the type of method that the Batch operation is</param>
        /// <param name="url">the URL that the Batch operation needs to hit</param>
        public BatchHttpMessageHandler(HttpMethod method, Uri url)
        {
            this.batchMethod = method;
            this.batchURL = url;
            this.Reset();
        }

        /// <summary>
        /// Resets the batch handler to accept a new set of batch requests
        /// </summary>
        public void Reset()
        {
            this.requests = new List<HttpRequestMessage>();
            this.responses = null;
            this.batchCompleted = new ManualResetEvent(false);
        }

        /// <summary>
        /// Issues all the queued up requests as a single batch request
        /// </summary>
        /// <param name="cancellationToken">cancellation token for the batch request</param>
        /// <param name="boundary">optional string which will be used as the encapsulation boundary between each request in multipart content; if not specified, a random GUID will be used</param>
        /// <returns>task for the batch</returns>
        public async Task IssueBatch(CancellationToken cancellationToken = default(CancellationToken), string boundary = null)
        {
            // There must be at least one request to issue
            if (this.requests.Count == 0)
            {
                throw new Exception("No queued requests to issue.");
            }

            // there must not be any responses already
            if (this.responses != null)
            {
                throw new Exception("There is already at least one response. Do not reuse this instance or call reset first.");
            }

            // Create a request to the batch URL
            HttpRequestMessage batchRequest = new HttpRequestMessage(this.batchMethod, this.batchURL);

            // Create the boundary
            if (string.IsNullOrEmpty(boundary))
            {
                boundary = "batch_" + Guid.NewGuid().ToString();
            }

            // Add a multipart content to the body of the request
            MultipartContent batchContent = new MultipartContent("mixed", boundary);
            batchRequest.Content = batchContent;

            // add each request to this batch request
            foreach (HttpRequestMessage message in this.requests)
            {
                batchContent.Add(new HttpMessageContent(message));
            }

            // issue the batch request
            HttpResponseMessage batchResponse = await base.SendAsync(batchRequest, cancellationToken);

            // throw exceptions if the response is unexpected
            if (batchResponse == null)
            {
                throw new Exception("Batch request got back a null response.");
            }

            batchResponse.EnsureSuccessStatusCode();

            if (batchResponse.Content == null)
            {
                throw new Exception("Batch request got back a response with null content.");
            }

            if (!batchResponse.Content.IsMimeMultipartContent("mixed"))
            {
                throw new Exception("Batch response returned unexpected content type.");
            }

            // pull out the responses
            MultipartMemoryStreamProvider responseContents = await batchResponse.Content.ReadAsMultipartAsync();
            if (responseContents == null)
            {
                throw new Exception("Failed to convert response content into multipart components.");
            }

            if (responseContents.Contents.Count != this.requests.Count)
            {
                throw new Exception("Batch response returned " + responseContents.Contents.Count + " number of responses instead of the expected " + this.requests.Count + ".");
            }

            // copy the responses over into the array that is accessible by the tasks waiting for individual responses
            this.responses = new HttpContent[responseContents.Contents.Count];
            responseContents.Contents.CopyTo(this.responses, 0);

            // signal tasks that they can proceed with using the response
            this.batchCompleted.Set();
        }

        /// <summary>
        /// Issues the HTTP Request. DO NOT access the result until IssueBatch has been awaited.
        /// </summary>
        /// <param name="request">HTTP request to issue</param>
        /// <param name="cancellationToken">not used</param>
        /// <returns>HTTP response from server</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // there must not be any responses already
            if (this.responses != null)
            {
                throw new Exception("There is already at least one response. Do not reuse this instance or call reset first.");
            }

            // what is my queue position?
            int position = this.requests.Count;

            // add the request to the queue
            this.requests.Add(request);

            // send back a task that will return the appropriate value
            Task<HttpResponseMessage> task = Task<HttpResponseMessage>.Factory.StartNew(() => this.GetResponse(position));
            return task;
        }

        /// <summary>
        /// Wait for the batch call to finish and then return the requested response
        /// </summary>
        /// <param name="index">which response to return</param>
        /// <returns>The HttpResponseMessage inside the batch at the given index</returns>
        private HttpResponseMessage GetResponse(int index)
        {
            this.batchCompleted.WaitOne();
            return this.responses[index].ReadAsHttpResponseMessageAsync().Result;
        }
    }
}
