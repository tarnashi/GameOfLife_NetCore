using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstract.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Api
{
    [Produces("application/json")]
    [Route("api/TestApi")]
    public class TestApiController : Controller
    {
        private readonly ITestManager _testManager;

        public TestApiController(ITestManager testManager)
        {
            _testManager = testManager;
        }

        [HttpPost]
        public JsonResult HelloWorld()
        {
            string result = _testManager.HelloWorld();
            return Json(result);
        }
    }
}