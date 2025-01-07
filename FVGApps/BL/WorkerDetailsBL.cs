using FVGApps.Base;
using FVGApps.DataPosts;
using FVGApps.Models;
using FVGApps.PostData;
using FVGApps.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.BL
{
    public class WorkerDetailsBL : SubBase
    {
        public WorkerDetailsBL(WorkerDetailsRepository workerDetailsRepository, string apiUrl, string apiKey) : base(workerDetailsRepository, apiUrl, apiKey)
        {
        }

        public void RunJob()
        {
            //WORKER USER
            var workerDetails = _workerDetailsRepository.GetAllWorkers();
            var workerDetailsDataPost = WorkerDetailsDataPostMapping(workerDetails.ToList());
            Posting(workerDetailsDataPost);

            //WORKER GROUP
            //var workerGroupDetails = _workerDetailsRepository.GetAllWorkerGroups();
            //var workerGroupDetailsDataPost = WorkerGroupDetailsDataPostMapping(workerGroupDetails.ToList());
            //Posting(workerGroupDetailsDataPost);
        }

        public List<WorkerDetailsDataPost> WorkerDetailsDataPostMapping(List<WorkerDetailsModel> WorkerDetails)
        {
            var workerDetailsDataPostList = new List<WorkerDetailsDataPost>();
            foreach (WorkerDetailsModel item in WorkerDetails)
            {
                var workerDetailsDataPost = new WorkerDetailsDataPost
                {
                    name = item.employee_name,
                    mobile_number = item.mobile_number,
                    employee_id = item.employee_id,
                    status = item.status,
                    id_number = item.id_number,
                    nationality = item.nationality,
                    worker_type = item.worker_type,
                    id_type = item.id_type,
                    company = item.company,
                    source = item.source,
                    zone_code = item.zone_code.ToString(),
                    region_code = item.region_code.ToString(),
                    estate_code = item.estate_code.ToString(),
                    division_code = item.division_code,
                    block_code = item.block_code,
                    supervisor_details = new SupervisorDetails
                    {
                        supervisor_employee_id = item.supervisor_employee_id,
                        supervisor_name = item.supervisor_name
                    },
                    worker_group_details = new WorkerGroupDetails
                    {
                        worker_group_id = item.worker_group_id,
                        worker_group_name = item.worker_group_name
                    },
                    documents = new Documents
                    {
                        passport_start_date = !string.IsNullOrEmpty(item.passport_start_date.ToString()) ? item.passport_start_date.Value.ToString("yyyy-MM-dd") : null,
                        passport_expiry_date = !string.IsNullOrEmpty(item.passport_expiry_date.ToString()) ? item.passport_expiry_date.Value.ToString("yyyy-MM-dd") : null,
                        passport_status = item.passport_status,
                        passport_renewal_status = item.passport_renewal_status,
                        passport_renewal_start_date = !string.IsNullOrEmpty(item.passport_renewal_start_date.ToString()) ? item.passport_renewal_start_date.Value.ToString("yyyy-MM-dd") : null,
                        permit_number = item.permit_number,
                        permit_start_date = !string.IsNullOrEmpty(item.permit_start_date.ToString()) ? item.permit_start_date.Value.ToString("yyyy-MM-dd") : null,
                        permit_expiry_date = !string.IsNullOrEmpty(item.permit_expiry_date.ToString()) ? item.permit_expiry_date.Value.ToString("yyyy-MM-dd") : null,
                        permit_status = item.permit_status,
                        permit_renewal_status = item.permit_renewal_status,
                        permit_renewal_start_date = !string.IsNullOrEmpty(item.permit_renewal_start_date.ToString()) ? item.permit_renewal_start_date.Value.ToString("yyyy-MM-dd") : null,
                        contract_start_date = !string.IsNullOrEmpty(item.contract_start_date.ToString()) ? item.contract_start_date.Value.ToString("yyyy-MM-dd") : null,
                        contract_expiry_date = !string.IsNullOrEmpty(item.contract_expiry_date.ToString()) ? item.contract_expiry_date.Value.ToString("yyyy-MM-dd") : null
                    }
                };
                workerDetailsDataPostList.Add(workerDetailsDataPost);
            }
            return workerDetailsDataPostList;
        }


        public List<WorkerGroupDetailsDataPost> WorkerGroupDetailsDataPostMapping(List<WorkerGroupDetailsModel> WorkerGroupDetails)
        {
            var workerGroupDetailsDataPostList = new List<WorkerGroupDetailsDataPost>();
            foreach (WorkerGroupDetailsModel item in WorkerGroupDetails)
            {
                var workerGroupDetailsDataPost = new WorkerGroupDetailsDataPost
                {
                    group_id = item.group_id,
                    name = item.name,
                    active = item.active,
                    company = item.company, //added by faeza 09.12.2024
                    zone = item.zone, //added by faeza 13.03.2024
                    region = item.region, //added by faeza 13.03.2024
                    estate = item.estate,                    
                    supervisor_details = new SupervisorDetails
                    {
                        supervisor_employee_id = item.supervisor_employee_id,
                        supervisor_name = item.supervisor_name
                    }
                };
                workerGroupDetailsDataPostList.Add(workerGroupDetailsDataPost);
            }
            return workerGroupDetailsDataPostList;
        }

        public void Posting(List<WorkerDetailsDataPost> WorkerDetailsDataPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                string output = JsonConvert.SerializeObject(WorkerDetailsDataPost);

                var response = client.PostAsync("add-workers/?key=" + _apiKey, new StringContent(output, Encoding.UTF8, "application/json")).Result;
                //Console.Write(response);
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Worker Success");
                }
                else
                {
                    Console.WriteLine("Worker Error");
                    Console.WriteLine(response.ToString());
                }
            }
        }

        public void Posting(List<WorkerGroupDetailsDataPost> WorkerGroupDetailsDataPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                string output = JsonConvert.SerializeObject(WorkerGroupDetailsDataPost);

                var response = client.PostAsync("add-worker-groups/?key=" + _apiKey, new StringContent(output, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Worker Group Success");
                }
                else
                {
                    Console.WriteLine("Worker Group Error");
                    Console.WriteLine(response.ToString());
                }
            }
        }
    }
}
