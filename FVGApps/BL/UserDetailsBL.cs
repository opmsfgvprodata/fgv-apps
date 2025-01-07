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
    public class UserDetailsBL : SubBase
    {
        public UserDetailsBL(UserDetailsRepository userDetailsRepository, string apiUrl, string apiKey) : base(userDetailsRepository, apiUrl, apiKey)
        {
        }

        public void RunJob()
        {
            ////BACKOFFICE USER
            var userDetails = _userDetailsRepository.GetAllUsers();
            //var userDetailsDataPost = UserDetailsDataPostMapping(userDetails.Take(10).ToList());
            var userDetailsDataPost = UserDetailsDataPostMapping(userDetails.ToList());
            Posting(userDetailsDataPost);

            //USER STATUS
            //var userStatus = _userDetailsRepository.GetAllUsersStatus();
            //var userStatusDataPost = UserStatusDataPostMapping(userStatus.ToList());
            //Posting(userStatusDataPost);
        }

        public List<UserDetailsDataPost> UserDetailsDataPostMapping(List<UserDetailsModel> UserDetails)
        {
            var userDetailsDataPostList = new List<UserDetailsDataPost>();
            foreach (UserDetailsModel item in UserDetails)
            {
                var userDetailsDataPost = new UserDetailsDataPost
                {
                    name = item.name,
                    mobile_number = item.mobile_number,
                    employee_id = item.employee_id,
                    status = item.status,
                    id_type = item.id_type,
                    id_number = item.id_number,
                    email = item.email,
                    office_number = item.office_number,
                    company = item.company,
                    source = item.source,
                    is_hq = item.is_hq,
                    designation = item.designation.ToString(),
                    department = item.department,
                    role_mapping = item.role_mapping,
                    zone_code = item.zone_code.ToString(),
                    region_code = item.region_code.ToString(),
                    estate_code = item.estate_code,
                    division_code = item.division_code,
                    block_code = item.block_code,
                    worker_group_details = new WorkerGroupDetails
                    {
                        worker_group_id = item.worker_group_id,
                        worker_group_name = item.worker_group_name
                    },
                    allowable_estate = new AllowableEstate
                    {
                        all_estates = item.all_estate,
                        zone_code = item.zone_code.ToString(),
                        region_code = item.region_code.ToString(),
                        estate_code = item.estate_code
                    }                        
                };
                userDetailsDataPostList.Add(userDetailsDataPost);
            }
            return userDetailsDataPostList;
        }

        public List<UserStatusDataPost> UserStatusDataPostMapping(List<UserDetailsModel> UserDetails)
        {
            var userStatusDataPostList = new List<UserStatusDataPost>();
            foreach (UserDetailsModel item in UserDetails)
            {
                var userStatusDataPost = new UserStatusDataPost
                {
                    employee_id = item.employee_id,
                    status = item.status
                };
                userStatusDataPostList.Add(userStatusDataPost);
            }
            return userStatusDataPostList;
        }

        public void Posting(List<UserDetailsDataPost> UserDetailsDataPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                string output = JsonConvert.SerializeObject(UserDetailsDataPost);

                var response = client.PostAsync("add-bo/?key=" + _apiKey, new StringContent(output, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Back Office User/User Status Success");
                }
                else
                {
                    Console.WriteLine("User Error");
                    Console.WriteLine(response.ToString());
                }
            }
        }

        public void Posting(List<UserStatusDataPost> UserStatusDataPost)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                string output = JsonConvert.SerializeObject(UserStatusDataPost);

                var response = client.PostAsync("add-user-status/?key=" + _apiKey, new StringContent(output, Encoding.UTF8, "application/json")).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("User Status Success");
                }
                else
                {
                    Console.WriteLine("User Status Error");
                    Console.WriteLine(response.ToString());
                }
            }
        }
    }
}
