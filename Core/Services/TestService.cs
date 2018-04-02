using Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class TestService : ITestService
    {
        public TestService()
        { }

        public string HelloWorld()
        {
            return "Hello, world!";
        }
    }
}
