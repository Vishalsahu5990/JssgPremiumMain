using System;
using System.Runtime.Serialization;

namespace PortableLibrary.Models
{
   public class LoginModel
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        //[DataMember(Name = "email")]
        public string email { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        //[DataMember(Name = "mobile")]
        public string mobile { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        //[DataMember(Name = "id")]
        public String id { get; set; }

        /// <summary>
        /// Gets or sets the type of the user.
        /// </summary>
        /// <value>The type of the user.</value>
        //[DataMember(Name = "name")]
        public String name { get; set; }

    }
}
