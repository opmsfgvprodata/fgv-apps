using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.Models
{
    public class WorkerGroupDetailsModel
    {
        public string group_id {  get; set; }
        public string name { get; set; }
        public string active {  get; set; }
        public string estate { get; set; }
        public string supervisor_employee_id { get; set; }
        public string supervisor_name { get; set; }
    }
}
