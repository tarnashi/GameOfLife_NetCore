using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api
{
    [Produces("application/json")]
    [Route("api/TestApi")]
    public class TestApiController : Controller
    {
        private readonly ITestService _testService;

        public TestApiController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpPost]
        public JsonResult HelloWorld()
        {
            string result = _testService.HelloWorld();
            return Json(result);
        }
    }
}