using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.DataPosts
{
    public class WorkerGroupDetailsDataPost
    {
        public string group_id {  get; set; }
        public string name { get; set; }
        public string active { get; set; }
        public string estate { get; set; }
        public SupervisorDetails supervisor_details { get; set; }

    }
}
