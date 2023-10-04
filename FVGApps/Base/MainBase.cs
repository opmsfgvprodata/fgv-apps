using FVGApps.BL;
using FVGApps.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.Base
{
    public class MainBase
    {
        public static WorkerDetailsRepository _workerDetailsRepository = new WorkerDetailsRepository();
        public static UserDetailsRepository _userDetailsRepository = new UserDetailsRepository();
        public static string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();
        public static string _apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
        public static WorkerDetailsBL _workerDetailsBL = new WorkerDetailsBL(_workerDetailsRepository, _apiUrl, _apiKey);
        public static UserDetailsBL _userDetailsBL = new UserDetailsBL(_userDetailsRepository, _apiUrl, _apiKey);
        public MainBase(WorkerDetailsBL workerDetailsBL, UserDetailsBL userDetailsBL)
        {
            _workerDetailsBL = workerDetailsBL;     
            _userDetailsBL = userDetailsBL;
        }
    }
}
