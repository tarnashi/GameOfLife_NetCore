using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api
{
    [Route("api/[controller]/[action]/{id?}")]
    public class BaseApiController : Controller
    {
        private JsonResult JsonResponse(bool flagSuccess, object data = null, string message = "")
        {
            var response = new { success = flagSuccess,  data,  message };
            return Json(response);
        }

        protected JsonResult SuccessJsonResponse(object data = null, string message = "")
        {
            return JsonResponse(true, data, message);
        }

        protected JsonResult FailJsonResponse(string message = "", object data = null)
        {
            return JsonResponse(false, data, message);
        }
    }
}