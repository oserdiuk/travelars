﻿using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApiService.Entities.Common;
using GoogleApiService.Entities.Common.Interfaces;
using GoogleApiService.Entities.Translate.Translate.Request.Enums;
using GoogleApiService.Helpers;

namespace GoogleApiService.Entities.Translate.Translate.Request
{
    /// <summary>
    /// Translate Request.
    /// </summary>
    public class TranslateRequest : BaseRequest, IQueryStringRequest
    {
        private const string BASE_URL = "www.googleapis.com/language/translate/v2";

        /// <summary>
        /// Use the Source query parameter to specify the language you want to translate from. (optional)
        /// </summary>
        public virtual string Source { get; set; }

        /// <summary>
        /// Use the target query parameter to specify the language you want to translate into.
        /// </summary>
        public virtual string Target { get; set; } 

        /// <summary>
        /// Use the q query parameter to identify the string to translate
        /// </summary>
        public virtual IEnumerable<string> Qs { get; set; } 

        /// <summary>
        /// If prettyprint=true, the results returned by the server will be human readable (pretty printed).
        /// Default: prettyprint=true.
        /// </summary>
        public virtual bool PrettyPrint { get; set; } 

        /// <summary>
        /// This optional parameter allows you to indicate that the text to be translated is either plain-text or HTML. A value of html indicates HTML and a value of text indicates plain-text.
        /// Default: format=html.
        /// </summary>
        public virtual Format Format { get; set; }

        /// <summary>
        /// Always true. Setter is not supported.
        /// </summary>
        public override bool IsSsl
        {
            get { return true; }
            set { throw new NotSupportedException("This operation is not supported, TimeZoneRequest must use SSL"); }
        }

        /// <summary>
        /// Returns the Uri.
        /// </summary>
        /// <returns>Uri</returns>
        public override Uri GetUri()
        {
            var scheme = this.IsSsl ? "https://" : "http://";
            var queryString = this.GetQueryStringParameters().GetQueryStringPostfix();

            return new Uri(scheme + this.BaseUrl + "?" + queryString);
        }

        /// <summary>
        /// BaseUrl property overridden.
        /// </summary>
        protected internal override string BaseUrl => TranslateRequest.BASE_URL;

        /// <summary>
        /// Get the query string collection of added parameters for the request.
        /// </summary>
        /// <returns></returns>
        protected override QueryStringParametersList GetQueryStringParameters()
        {
            if (string.IsNullOrWhiteSpace(this.Key))
                throw new ArgumentException("ApiKey is required");

            if (string.IsNullOrWhiteSpace(this.Target))
                throw new ArgumentException("Target is required");

            if (this.Qs == null || !this.Qs.Any())
                throw new ArgumentException("Qs is required");

            var parameters = base.GetQueryStringParameters();

            parameters.Add("target", this.Target);

            foreach (var q in this.Qs)
            {
                parameters.Add("q", q);
            }

            parameters.Add("prettyprint", this.PrettyPrint.ToString().ToLower());
            
            if (!string.IsNullOrWhiteSpace(this.Source))
                parameters.Add("source", this.Source);

            return parameters;
        }
    }
}