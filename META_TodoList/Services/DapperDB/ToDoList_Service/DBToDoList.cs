using System.Data.SqlClient;
using System.Data;
using META_TodoList.Models.ToDoList_Model;
using Dapper;

namespace META_TodoList.Services.DapperDB.ToDoList_Service
{
    public class DBToDoList : IToDoList
    {
        IDbConnection getConnection()
        {
            return new SqlConnection(getConnectionString());
        }

        private string getConnectionString()
        {
            return @"Data Source=TOANDINHH\SQLTOANDINHH;Initial Catalog=META_TodoList;Persist Security Info=True;User ID=sa;Password=123456";
        }
        public void createTitle(string username, string title)
        {
            using (var conn = getConnection())
            {
                var titlecheck = 0;
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@idUser", username);
                param.Add("@toDoList", title);
                param.Add("@titleCheck", titlecheck);
                conn.Execute("Proc_CreateTitle", param, commandType: CommandType.StoredProcedure);
            }
        }
        public void deleteTitle(string username, string deletetitle)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@idUser", username);
                param.Add("@toDoList", deletetitle);
                conn.Execute("Proc_DeleteTitle", param, commandType: CommandType.StoredProcedure);
            }
        }
        public void checkTitle(string username, string checktitle)
        {
            using (var conn = getConnection())
            {
                var titlecheck = 1;
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@idUser", username);
                param.Add("@toDoList", checktitle);
                param.Add("@titleCheck", titlecheck);
                conn.Execute("Proc_UpdateTitle", param, commandType: CommandType.StoredProcedure);
            }
        }
        public List<dynamic> getTitle(string username)
        {
            using (var conn = getConnection())
            {
                conn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@idUser", username);
                return conn.Query("Proc_GetTitle", param, commandType: CommandType.StoredProcedure).ToList();
            }
        }

		List<DBToDoTitle> IToDoList.getTitle(string id)
		{
			throw new NotImplementedException();
		}
	}
}
