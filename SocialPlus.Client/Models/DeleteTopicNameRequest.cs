// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under
// the MIT License. See LICENSE in the project root for license information.
// <autogenerated> This file was generated using AutoRest. </autogenerated>

namespace SocialPlus.Client.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    /// <summary>
    /// Request to delete a topic name
    /// </summary>
    public partial class DeleteTopicNameRequest
    {
        /// <summary>
        /// Initializes a new instance of the DeleteTopicNameRequest class.
        /// </summary>
        public DeleteTopicNameRequest() { }

        /// <summary>
        /// Initializes a new instance of the DeleteTopicNameRequest class.
        /// </summary>
        public DeleteTopicNameRequest(PublisherType publisherType)
        {
            PublisherType = publisherType;
        }

        /// <summary>
        /// Gets or sets publisher type. Possible values include: 'User', 'App'
        /// </summary>
        [JsonProperty(PropertyName = "publisherType")]
        public PublisherType PublisherType { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
        }
    }
}