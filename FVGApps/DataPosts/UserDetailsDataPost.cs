using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.PostData
{
    public class UserDetailsDataPost
    {
        public string name { get; set; }
        public string mobile_number { get; set; }
        public string employee_id { get; set; }
        public string status { get; set; }
        public string id_type { get; set; }
        public string id_number { get; set; }
        public string email { get; set; }
        public string office_number { get; set; }
        public string company { get; set; }
        public string source { get; set; }
        public string is_hq { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public string role_mapping { get; set; }
        public string zone_code { get; set; }
        public string region_code { get; set; }
        public string estate_code { get; set; }
        public string division_code { get; set; }
        public string block_code { get; set; }
        public WorkerGroupDetails worker_group_details { get; set; }
        public AllowableEstate allowable_estate { get; set; }
    }

    public class AllowableEstate
    {
        public string all_estates { get; set; }
        public string zone_code { get; set; }
        public string region_code { get; set; }
        public string estate_code { get; set; }
    }
}
