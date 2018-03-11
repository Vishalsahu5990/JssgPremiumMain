using System;
using System.Runtime.Serialization;

namespace DataAccessLayer.Models
{
    //[DataContract]
    public class CircularModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        //[DataMember(Name = "id")]
        public string id { get; set; }
        /// <summary>
        /// Gets or sets the name of the circle.
        /// </summary>
        /// <value>The name of the circle.</value>
        //[DataMember(Name = "cirName")]
        public string cirName { get; set; } 
        /// <summary>
        /// Gets or sets the cir desc.
        /// </summary>
        /// <value>The cir desc.</value>
        public string cirDesc { get; set; } 

    }
}
