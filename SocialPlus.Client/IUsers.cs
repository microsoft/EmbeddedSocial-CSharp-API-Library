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
    /// Users operations.
    /// </summary>
    public partial interface IUsers
    {
        /// <summary>
        /// Create a new user
        /// </summary>
        /// Create a new user and return a fresh session token
        /// <param name='request'>
        /// Post user request
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
        Task<HttpOperationResponse<PostUserResponse>> PostUserWithHttpMessagesAsync(PostUserRequest request, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get my profile
        /// </summary>
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
        Task<HttpOperationResponse<UserProfileView>> GetMyProfileWithHttpMessagesAsync(string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete user
        /// </summary>
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
        Task<HttpOperationResponse<object>> DeleteUserWithHttpMessagesAsync(string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update user info
        /// </summary>
        /// <param name='request'>
        /// Put user info request
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
        Task<HttpOperationResponse<object>> PutUserInfoWithHttpMessagesAsync(PutUserInfoRequest request, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update user photo
        /// </summary>
        /// <param name='request'>
        /// Put user photo request
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
        Task<HttpOperationResponse<object>> PutUserPhotoWithHttpMessagesAsync(PutUserPhotoRequest request, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update user visibility
        /// </summary>
        /// <param name='request'>
        /// Put user visibility request
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
        Task<HttpOperationResponse<object>> PutUserVisibilityWithHttpMessagesAsync(PutUserVisibilityRequest request, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name='userHandle'>
        /// Handle of queried user
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
        Task<HttpOperationResponse<UserProfileView>> GetUserWithHttpMessagesAsync(string userHandle, string authorization, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get popular users
        /// </summary>
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
        /// <param name='cursor'>
        /// Current read cursor
        /// </param>
        /// <param name='limit'>
        /// Number of items to return
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<HttpOperationResponse<FeedResponseUserProfileView>> GetPopularUsersWithHttpMessagesAsync(string authorization, int? cursor = default(int?), int? limit = default(int?), Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
