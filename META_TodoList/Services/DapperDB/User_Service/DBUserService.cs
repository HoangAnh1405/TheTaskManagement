using META_TodoList.Models;
using Dapper;
using System.Data;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections.Generic;
using META_TodoList.Data.cs.Entities;

namespace META_TodoList.Services.DapperDB.User_Service
{
    public class DBUserService : IUserService
    {
        IDbConnection getConnection()
        {
            return new SqlConnection(getConnectionString());
        }

        private string getConnectionString()
        {
            return @"Data Source=TOANDINHH\SQLTOANDINHH;Initial Catalog=META_TodoList;Persist Security Info=True;User ID=sa;Password=123456";
        }
        public List<dynamic> SearchUser(string id, string pass)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                param.Add("@pass", pass);
                return conn.Query("Proc_SearchUser", param, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public List<dynamic> CheckUserName(string id)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                return conn.Query("Proc_CheckUserName", param, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public void createNewUser(string id, string email, string pass, string repass)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                param.Add("@email", email);
                param.Add("@pass", pass);
                param.Add("@repass", repass);
                conn.Execute("Proc_CreateUser", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteUser(string id)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                conn.Execute("Proc_DeleteUser", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateUser(string id, string idNew, string emailNew, string passNew, string repassNew)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@idSearch", id);
                param.Add("@id", idNew);
                param.Add("@email", emailNew);
                param.Add("@pass", passNew);
                param.Add("@repass", repassNew);
                conn.Execute("Proc_UpdateUser", param, commandType: CommandType.StoredProcedure);

            }
        }

		List<DBUserSignUp> IUserService.SearchUser(string id, string pass)
		{
			throw new NotImplementedException();
		}

		List<DBUserSignUp> IUserService.CheckUserName(string id)
		{
			throw new NotImplementedException();
		}
	}
}
