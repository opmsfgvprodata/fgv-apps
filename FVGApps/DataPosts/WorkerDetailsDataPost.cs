using FVGApps.DataPosts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.PostData
{
    public class WorkerDetailsDataPost
    {
        public string name { get; set; }
        public string mobile_number { get; set; }
        public string employee_id { get; set; }
        public string status { get; set; }
        public string id_number { get; set; }
        public string nationality { get; set; }
        public string worker_type { get; set; }
        public string id_type { get; set; }
        public string company { get; set; }
        public string source { get; set; }
        public string zone_code { get; set; }
        public string region_code { get; set; }
        public string estate_code { get; set; }
        public string division_code { get; set; }
        public string block_code { get; set; }
        public SupervisorDetails supervisor_details { get; set; }
        public WorkerGroupDetails worker_group_details { get; set; }
        public Documents documents { get; set; }
    }

    public class Documents
    {
        public string passport_start_date { get; set; }
        public string passport_expiry_date { get; set; }
        public string passport_status { get; set; }
        public string passport_renewal_status { get; set; }
        public string passport_renewal_start_date { get; set; }
        public string permit_number { get; set; }
        public string permit_start_date { get; set; }
        public string permit_expiry_date { get; set; }
        public string permit_status { get; set; }
        public string permit_renewal_status { get; set; }
        public string permit_renewal_start_date { get; set; }
        public string contract_start_date { get; set; }
        public string contract_expiry_date { get; set; }
    }
}
