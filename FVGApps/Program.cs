using FVGApps.BL;
using FVGApps.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using FVGApps.Base;
using FVGApps.PostData;

namespace FVGApps
{
    public class Program : MainBase
    {
        public Program(WorkerDetailsBL workerDetailsBL, UserDetailsBL userDetailsBL) : base(workerDetailsBL, userDetailsBL)
        {

        }

        // No code changes needed for your current scenario.
        // The methods in Main are already called one after another, synchronously.
        // If you want to log completion after each step, you can add Console.WriteLine statements:

        static void Main(string[] args)
        {
            _userDetailsBL.RunJobBackofficeUser();
            Console.WriteLine("Backoffice user job completed.");

            _workerDetailsBL.RunJobWorkerGroup();
            Console.WriteLine("Worker group job completed.");

            _workerDetailsBL.RunJobWorkerUser();
            Console.WriteLine("Worker user job completed.");

            _userDetailsBL.RunJobUserStatus();
            Console.WriteLine("User status job completed.");

            Console.ReadLine();
        }
    }
}
