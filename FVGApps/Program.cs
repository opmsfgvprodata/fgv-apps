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

        static void Main(string[] args)
        {
            //WORKER GROUP & WORKER USER
            //#region Worker Group & Worker Details Posting
            //_workerDetailsBL.RunJob();
            //#endregion

            ////USER STATUS & BACKOFFICE USER
            #region Users Status & Users Details Posting
            _userDetailsBL.RunJob();
            #endregion

            Console.ReadLine();
        }
    }
}
