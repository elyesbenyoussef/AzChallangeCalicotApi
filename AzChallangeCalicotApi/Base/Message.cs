using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Base
{
    public class Message
    {
        public Message() { }

        public string CodeFonctionnel { get; set; }
        public string Description { get; set; }
        public Severite Severite { get; set; }
    }
}
