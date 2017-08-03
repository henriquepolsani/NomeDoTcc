using System.Collections.Generic;

namespace SimpleClassroom.Domain.Utils
{
    public class Email
    {
        public string From { get; set; }
        public IList<string> To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
