using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Models
{
    [DataContract]
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>The code.</value>
        [DataMember(Name = "code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the error.
        /// </summary>
        /// <value>The error.</value>
        [DataMember(Name = "string")]
        public string Error { get; set; }
    }
}
