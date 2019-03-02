using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PerformanceProfiling
{
    public class TestService
    {
        TestRepository repo;
        public TestService()
        {
            repo = new TestRepository();
        }
        public void Step1()
        {
            for (int i = 0; i < 1000; i++)
            {
                repo.Sleep();
            }
        }
        public void Step2()
        {
            for (int i = 0; i < 1000; i++)
            {
                repo.Serialize();
            }
        }
        public void Step3()
        {
            for (int i = 0; i < 1000; i++)
            {
                repo.Loop();
            }
        }
    }
}
