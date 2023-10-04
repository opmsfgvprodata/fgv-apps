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
    public class WorkerDetailsRepository
    {
        public SqlConnection con;
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);
        }

        public List<WorkerDetailsModel> GetAllWorkers()
        {
            try
            {
                connection();
                con.Open();
                IList<WorkerDetailsModel> workerDetailList = SqlMapper.Query<WorkerDetailsModel>(con, "sp_FGVAppWorkerUser").ToList();
                con.Close();
                return workerDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<WorkerGroupDetailsModel> GetAllWorkerGroups()
        {
            try
            {
                connection();
                con.Open();
                IList<WorkerGroupDetailsModel> workerGroupDetailList = SqlMapper.Query<WorkerGroupDetailsModel>(con, "sp_FGVAppWorkerGroup").ToList();
                con.Close();
                return workerGroupDetailList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
