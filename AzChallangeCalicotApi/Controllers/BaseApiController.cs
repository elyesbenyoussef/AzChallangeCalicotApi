using AzChallangeCalicotApi.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzChallangeCalicotApi.Controllers
{
    public static class ControllerExtensions 
    {
        public static ActionResult<EnveloppeReponse<T>> OkAvecEnveloppe<T>(this ControllerBase controller, T data)
        {
            return new OkObjectResult(controller.GetEnvelopperReponse(data));
        }

        public static EnveloppeReponse<T> GetEnvelopperReponse<T>(this ControllerBase controller, T data)
        {
            return new EnveloppeReponse<T> { Data = data };
        }
    }
}
