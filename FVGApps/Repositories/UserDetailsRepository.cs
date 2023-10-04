using Dapper;
using FVGApps.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVGApps.Repositories
{
    public class UserDetailsRepository
    {
        public SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }

        public List<UserDetailsModel> GetAllUsers()
        {
            try
            {
                connection();
                con.Open();
                IList<UserDetailsModel> userDetailList = SqlMapper.Query<UserDetailsModel>(con, "sp_FGVAppBackofficeUser").ToList();
                con.Close();
                return userDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UserDetailsModel> GetAllUsersStatus()
        {
            try
            {
                connection();
                con.Open();
                IList<UserDetailsModel> userDetailList = SqlMapper.Query<UserDetailsModel>(con, "sp_FGVAppUserStatus").ToList();
                con.Close();
                return userDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
