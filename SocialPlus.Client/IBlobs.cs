// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under
// the MIT License. See LICENSE in the project root for license information.
// <autogenerated> This file was generated using AutoRest. </autogenerated>

namespace SocialPlus.Client
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Blobs operations.
    /// </summary>
    public partial interface IBlobs
    {
        /// <summary>
        /// Upload a blob
        /// </summary>
        /// If your blob is an image, use image APIs. For all other blob
        /// types, use this API.
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
        /// <param name='blob'>
        /// MIME encoded contents of the blob
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<PostBlobResponse>> PostBlobWithHttpMessagesAsync(string authorization, System.IO.Stream blob, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get blob
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
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<System.IO.Stream>> GetBlobWithHttpMessagesAsync(string blobHandle, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
