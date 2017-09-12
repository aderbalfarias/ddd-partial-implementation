using System.Collections.Generic;
using System.Linq;

namespace DDDExample.Domain.Entities
{
    public class Email
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

        public bool IsCc(Email entity)
        {
            return entity.Cc != null && entity.Cc.Any();
        }

        public bool IsBcc(Email entity)
        {
            return entity.Bcc != null && entity.Bcc.Any();
        }
    }
}
