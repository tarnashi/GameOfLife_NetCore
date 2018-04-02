using Abstract.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Managers
{
    public class TestManager : ITestManager
    {
        public TestManager()
        { }

        public string HelloWorld()
        {
            return "Hello, world!";
        }
    }
}
