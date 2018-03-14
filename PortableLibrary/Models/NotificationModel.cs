using System;
namespace PortableLibrary.Models
{
    public class NotificationModel
    {
        public NotificationModel()
        {
        }
        public string name { get; set; }
        public string memMobile { get; set; }

        public string memPhoto { get; set; }

        public string @event { get; set; }
        public string addedOn { get; set; }
        public string memID { get; set; }
        public string @type { get; set; }

        }
}
