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
    /// Feed response
    /// </summary>
    public partial class FeedResponseTopicView
    {
        /// <summary>
        /// Initializes a new instance of the FeedResponseTopicView class.
        /// </summary>
        public FeedResponseTopicView() { }

        /// <summary>
        /// Initializes a new instance of the FeedResponseTopicView class.
        /// </summary>
        public FeedResponseTopicView(IList<TopicView> data, string cursor)
        {
            Data = data;
            Cursor = cursor;
        }

        /// <summary>
        /// Gets or sets feed data
        /// </summary>
        [JsonProperty(PropertyName = "data")]
        public IList<TopicView> Data { get; set; }

        /// <summary>
        /// Gets or sets feed cursor
        /// </summary>
        [JsonProperty(PropertyName = "cursor")]
        public string Cursor { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Data == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Data");
            }
            if (Cursor == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Cursor");
            }
            if (this.Data != null)
            {
                foreach (var element in this.Data)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
