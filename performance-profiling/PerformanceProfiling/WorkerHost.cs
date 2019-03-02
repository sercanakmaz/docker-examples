using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PerformanceProfiling
{
    public class WorkerHost : IHostedService
    {
        TestService testService;
        public WorkerHost()
        {
            testService = new TestService();
        }

        bool stopAndBlock = false;
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ThreadPool.QueueUserWorkItem((f) => Step1());
            ThreadPool.QueueUserWorkItem((f) => Step2());
            ThreadPool.QueueUserWorkItem((f) => Step3());

            await Task.CompletedTask;
        }

        private void Step1()
        {
            for (int i = 0; i < 1000; i++)
            {
                testService.Step1();
            }
            Console.WriteLine("Step1 Ended");
        }

        private void Step2()
        {
            for (int i = 0; i < 1000; i++)
            {
                testService.Step2();
            }
            Console.WriteLine("Step2 Ended");
        }

        private void Step3()
        {
            for (int i = 0; i < 1000; i++)
            {
                testService.Step3();
            }
            Console.WriteLine("Step3 Ended");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            stopAndBlock = true;

            await Task.CompletedTask;
        }
    }
}
