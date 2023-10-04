using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.Models
{
    public class UserDetailsModel
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
        public int department { get; set; }
        public string role_mapping { get; set; }
        public int zone_code { get; set; }
        public int region_code { get; set; }
        public int estate_code { get; set; }
        public int division_code { get; set; }
        public int block_code { get; set; }
        public string all_estate { get; set; }
        public int worker_group_id { get; set; }
        public int worker_group_name { get; set; }
        public int zone_code1 { get; set; }
        public int region_code1 { get; set; }
        public int estate_code1 { get; set; }
    }
}
