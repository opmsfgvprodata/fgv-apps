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
    public class SubBase
    {
        public static WorkerDetailsRepository _workerDetailsRepository = new WorkerDetailsRepository();
        public static UserDetailsRepository _userDetailsRepository = new UserDetailsRepository();
        public static string _apiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();
        public static string _apiKey = ConfigurationManager.AppSettings["ApiKey"].ToString();
         
        public SubBase(WorkerDetailsRepository workerDetailsRepository, string apiUrl, string apiKey)
        {
            _workerDetailsRepository = workerDetailsRepository;
            _apiUrl = apiUrl;
            _apiKey = apiKey;
        }
        public SubBase(UserDetailsRepository userDetailsRepository, string apiUrl, string apiKey)
        {
            _userDetailsRepository = userDetailsRepository;
            _apiUrl = apiUrl;
            _apiKey = apiKey;
        }
    }
}
