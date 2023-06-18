using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneSignal_API_01.Models
{
    public class NotificationDislayedRequest
    {
        public string Content { get; set; }
        public string Event { get; set; }
        public string Heading { get; set; }
        public string Id { get; set; }
        public string UserId { get; set; }
    }
}
