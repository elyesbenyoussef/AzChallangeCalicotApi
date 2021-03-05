using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Base
{
    public class EnveloppeReponseBase
    {
        private bool _isValid;
        private List<Message> _messages;

        public bool IsValid { get { return _isValid; } }
        public IEnumerable<Message> Messages { get { return _messages; } }

        public EnveloppeReponseBase()
        {
            _messages = new List<Message>();
        }
        
        public void AjouterMessage(Message message)
        {
            _isValid = false;
            _messages.Add(message);
        }
    }
}
