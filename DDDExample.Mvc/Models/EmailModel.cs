using System.Collections.Generic;

namespace DDDExample.Mvc.Models
{
    public class EmailModel 
    {
        public string From { get; set; }

        public IList<string> To { get; set; }

        public IList<string> Cc { get; set; }

        public IList<string> Bcc { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool? IsHtml { get; set; }

        public byte[] ItemAttach { get; set; }

        public string AttachmentName { get; set; }
    }
}