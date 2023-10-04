using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.Models
{
    public class WorkerDetailsModel
    {
        public string employee_id { get; set; }
        public string employee_name { get; set; }
        public string id_type { get; set; }
        public string id_number { get; set; }
        public string nationality { get; set; }
        public string worker_type { get; set; }
        public string mobile_number { get; set; }
        public string source { get; set; }
        public string company { get; set; }
        public string status { get; set; }
        public int? zone_code { get; set; }
        public int? region_code { get; set; }
        public int? estate_code { get; set; }
        public int? division_code { get; set; }
        public int? block_code { get; set; }
        public string worker_group_id { get; set; }
        public string worker_group_name { get; set; }
        public string supervisor_employee_id { get; set; }
        public string supervisor_name { get; set; }
        public DateTime? passport_start_date { get; set; }
        public DateTime? passport_expiry_date { get; set; }
        public string passport_status { get; set; }
        public string passport_renewal_status { get; set; }
        public DateTime? passport_renewal_start_date { get; set; }
        public string permit_number { get; set; }
        public DateTime? permit_start_date { get; set; }
        public DateTime? permit_expiry_date { get; set; }
        public string permit_status { get; set; }
        public string permit_renewal_status { get; set; }
        public DateTime? permit_renewal_status_date { get; set; }
        public DateTime? contract_start_date { get; set; }
        public DateTime? contract_expiry_date { get; set; }
    }

}
