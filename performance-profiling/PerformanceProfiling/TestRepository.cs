using GenFu;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PerformanceProfiling
{
    public class TestRepository
    {
        public void Sleep()
        {
            Thread.Sleep(100);
        }

        public void Serialize()
        {
            var entity = A.New<TestEntity>();
            var serialized = JsonConvert.SerializeObject(entity);
        }

        public void Loop()
        {
            for (int i = 0; i < 100; i++)
            {

            }
        }
    }
}
