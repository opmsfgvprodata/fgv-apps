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
            Common.Log.SetLogFilePath("mylog.txt");
            _userDetailsBL.RunJobBackofficeUser();
            Common.Log.Write("Backoffice user job completed.");

            _workerDetailsBL.RunJobWorkerGroup();
            Common.Log.Write("Worker group job completed.");

            _workerDetailsBL.RunJobWorkerUser();
            Common.Log.Write("Worker user job completed.");

            _userDetailsBL.RunJobUserStatus();
            Common.Log.Write("User status job completed.");
        }
    }
}
