// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under
// the MIT License. See LICENSE in the project root for license information.
// <autogenerated> This file was generated using AutoRest. </autogenerated>

namespace SocialPlus.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for MyFollowers.
    /// </summary>
    public static partial class MyFollowersExtensions
    {
            /// <summary>
            /// Get my followers
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            /// <param name='cursor'>
            /// Current read cursor
            /// </param>
            /// <param name='limit'>
            /// Number of items to return
            /// </param>
            public static FeedResponseUserCompactView GetFollowers(this IMyFollowers operations, string authorization, string cursor = default(string), int? limit = default(int?))
            {
                return Task.Factory.StartNew(s => ((IMyFollowers)s).GetFollowersAsync(authorization, cursor, limit), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Get my followers
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
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
            /// <param name='cursor'>
            /// Current read cursor
            /// </param>
            /// <param name='limit'>
            /// Number of items to return
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<FeedResponseUserCompactView> GetFollowersAsync(this IMyFollowers operations, string authorization, string cursor = default(string), int? limit = default(int?), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetFollowersWithHttpMessagesAsync(authorization, cursor, limit, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Accept follower request
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='request'>
            /// Post follower request
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
            public static object PostFollower(this IMyFollowers operations, PostFollowerRequest request, string authorization)
            {
                return Task.Factory.StartNew(s => ((IMyFollowers)s).PostFollowerAsync(request, authorization), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Accept follower request
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='request'>
            /// Post follower request
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> PostFollowerAsync(this IMyFollowers operations, PostFollowerRequest request, string authorization, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.PostFollowerWithHttpMessagesAsync(request, authorization, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Remove follower
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userHandle'>
            /// Handle of follower user
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
            public static object DeleteFollower(this IMyFollowers operations, string userHandle, string authorization)
            {
                return Task.Factory.StartNew(s => ((IMyFollowers)s).DeleteFollowerAsync(userHandle, authorization), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Remove follower
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='userHandle'>
            /// Handle of follower user
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
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DeleteFollowerAsync(this IMyFollowers operations, string userHandle, string authorization, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DeleteFollowerWithHttpMessagesAsync(userHandle, authorization, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
