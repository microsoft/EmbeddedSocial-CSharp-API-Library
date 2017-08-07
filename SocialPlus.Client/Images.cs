// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under
// the MIT License. See LICENSE in the project root for license information.
// <autogenerated> This file was generated using AutoRest. </autogenerated>

namespace SocialPlus.Client
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Models;

    /// <summary>
    /// Images operations.
    /// </summary>
    public partial class Images : IServiceOperations<SocialPlusClient>, IImages
    {
        /// <summary>
        /// Initializes a new instance of the Images class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        public Images(SocialPlusClient client)
        {
            if (client == null) 
            {
                throw new ArgumentNullException("client");
            }
            this.Client = client;
        }

        /// <summary>
        /// Gets a reference to the SocialPlusClient
        /// </summary>
        public SocialPlusClient Client { get; private set; }

        /// <summary>
        /// Upload a new image
        /// </summary>
        /// Images will be resized. To access a resized image, append the 1 character
        /// size identifier to the blobHandle that is returned.
        /// 
        /// - d is 25 pixels wide
        /// - h is 50 pixels wide
        /// - l is 100 pixels wide
        /// - p is 250 pixels wide
        /// - t is 500 pixels wide
        /// - x is 1000 pixels wide
        /// 
        /// - ImageType.UserPhoto supports d,h,l,p,t,x
        /// - ImageType.ContentBlob supports d,h,l,p,t,x
        /// - ImageType.AppIcon supports l
        /// 
        /// All resized images will maintain their aspect ratio. Any
        /// orientation specified in the EXIF headers will be honored.
        /// <param name='imageType'>
        /// Image type. Possible values include: 'UserPhoto', 'ContentBlob', 'AppIcon'
        /// </param>
        /// <param name='authorization'>
        /// Format is: "Scheme CredentialsList". Possible values are:
        /// 
        /// - Anon AK=AppKey
        /// 
        /// - SocialPlus TK=SessionToken
        /// 
        /// - Facebook AK=AppKey|TK=AccessToken
        /// 
        /// - Google AK=AppKey|TK=AccessToken
        /// 
        /// - Twitter AK=AppKey|RT=RequestToken|TK=AccessToken
        /// 
        /// - Microsoft AK=AppKey|TK=AccessToken
        /// 
        /// - AADS2S AK=AppKey|[UH=UserHandle]|TK=AADToken
        /// </param>
        /// <param name='image'>
        /// MIME encoded contents of the image
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<PostImageResponse>> PostImageWithHttpMessagesAsync(ImageType imageType, string authorization, System.IO.Stream image, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (authorization == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "authorization");
            }
            if (image == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "image");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("imageType", imageType);
                tracingParameters.Add("authorization", authorization);
                tracingParameters.Add("image", image);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "PostImage", tracingParameters);
            }
            // Construct URL
            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
            var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v0.7/images/{imageType}").ToString();
            _url = _url.Replace("{imageType}", Uri.EscapeDataString(SafeJsonConvert.SerializeObject(imageType, this.Client.SerializationSettings).Trim('"')));
            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("POST");
            _httpRequest.RequestUri = new Uri(_url);
            // Set Headers
            if (authorization != null)
            {
                if (_httpRequest.Headers.Contains("Authorization"))
                {
                    _httpRequest.Headers.Remove("Authorization");
                }
                _httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
            }
            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            StreamContent _fileStreamContent = new StreamContent(image);
            _httpRequest.Content = _fileStreamContent;
            _httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("image/gif");
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await this.Client.HttpClient.SendAsync(_httpRequest, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 201 && (int)_statusCode != 400 && (int)_statusCode != 401 && (int)_statusCode != 500)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<PostImageResponse>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 201)
            {
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                try
                {
                    _result.Body = SafeJsonConvert.DeserializeObject<PostImageResponse>(_responseContent, this.Client.DeserializationSettings);
                }
                catch (JsonException ex)
                {
                    _httpRequest.Dispose();
                    if (_httpResponse != null)
                    {
                        _httpResponse.Dispose();
                    }
                    throw new SerializationException("Unable to deserialize the response.", _responseContent, ex);
                }
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

        /// <summary>
        /// Get image
        /// </summary>
        /// <param name='blobHandle'>
        /// Blob handle
        /// </param>
        /// <param name='authorization'>
        /// Format is: "Scheme CredentialsList". Possible values are:
        /// 
        /// - Anon AK=AppKey
        /// 
        /// - SocialPlus TK=SessionToken
        /// 
        /// - Facebook AK=AppKey|TK=AccessToken
        /// 
        /// - Google AK=AppKey|TK=AccessToken
        /// 
        /// - Twitter AK=AppKey|RT=RequestToken|TK=AccessToken
        /// 
        /// - Microsoft AK=AppKey|TK=AccessToken
        /// 
        /// - AADS2S AK=AppKey|[UH=UserHandle]|TK=AADToken
        /// </param>
        /// <param name='customHeaders'>
        /// Headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <return>
        /// A response object containing the response body and response headers.
        /// </return>
        public async Task<HttpOperationResponse<System.IO.Stream>> GetImageWithHttpMessagesAsync(string blobHandle, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (blobHandle == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "blobHandle");
            }
            if (authorization == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "authorization");
            }
            // Tracing
            bool _shouldTrace = ServiceClientTracing.IsEnabled;
            string _invocationId = null;
            if (_shouldTrace)
            {
                _invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("blobHandle", blobHandle);
                tracingParameters.Add("authorization", authorization);
                tracingParameters.Add("cancellationToken", cancellationToken);
                ServiceClientTracing.Enter(_invocationId, this, "GetImage", tracingParameters);
            }
            // Construct URL
            var _baseUrl = this.Client.BaseUri.AbsoluteUri;
            var _url = new Uri(new Uri(_baseUrl + (_baseUrl.EndsWith("/") ? "" : "/")), "v0.7/images/{blobHandle}").ToString();
            _url = _url.Replace("{blobHandle}", Uri.EscapeDataString(blobHandle));
            // Create HTTP transport objects
            HttpRequestMessage _httpRequest = new HttpRequestMessage();
            HttpResponseMessage _httpResponse = null;
            _httpRequest.Method = new HttpMethod("GET");
            _httpRequest.RequestUri = new Uri(_url);
            // Set Headers
            if (authorization != null)
            {
                if (_httpRequest.Headers.Contains("Authorization"))
                {
                    _httpRequest.Headers.Remove("Authorization");
                }
                _httpRequest.Headers.TryAddWithoutValidation("Authorization", authorization);
            }
            if (customHeaders != null)
            {
                foreach(var _header in customHeaders)
                {
                    if (_httpRequest.Headers.Contains(_header.Key))
                    {
                        _httpRequest.Headers.Remove(_header.Key);
                    }
                    _httpRequest.Headers.TryAddWithoutValidation(_header.Key, _header.Value);
                }
            }

            // Serialize Request
            string _requestContent = null;
            // Send Request
            if (_shouldTrace)
            {
                ServiceClientTracing.SendRequest(_invocationId, _httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            _httpResponse = await this.Client.HttpClient.SendAsync(_httpRequest, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
            if (_shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(_invocationId, _httpResponse);
            }
            HttpStatusCode _statusCode = _httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string _responseContent = null;
            if ((int)_statusCode != 200 && (int)_statusCode != 400 && (int)_statusCode != 401 && (int)_statusCode != 404 && (int)_statusCode != 500)
            {
                var ex = new HttpOperationException(string.Format("Operation returned an invalid status code '{0}'", _statusCode));
                _responseContent = await _httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                ex.Request = new HttpRequestMessageWrapper(_httpRequest, _requestContent);
                ex.Response = new HttpResponseMessageWrapper(_httpResponse, _responseContent);
                if (_shouldTrace)
                {
                    ServiceClientTracing.Error(_invocationId, ex);
                }
                _httpRequest.Dispose();
                if (_httpResponse != null)
                {
                    _httpResponse.Dispose();
                }
                throw ex;
            }
            // Create Result
            var _result = new HttpOperationResponse<System.IO.Stream>();
            _result.Request = _httpRequest;
            _result.Response = _httpResponse;
            // Deserialize Response
            if ((int)_statusCode == 200)
            {
                _result.Body = await _httpResponse.Content.ReadAsStreamAsync().ConfigureAwait(false);
            }
            if (_shouldTrace)
            {
                ServiceClientTracing.Exit(_invocationId, _result);
            }
            return _result;
        }

    }
}
