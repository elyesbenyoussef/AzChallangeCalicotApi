using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Base
{
    public class EnveloppeReponse<T> : EnveloppeReponseBase
    {
        public EnveloppeReponse()
        {

        }

        public T Data { get; set; }
    }
}
