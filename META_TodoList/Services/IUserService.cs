using META_TodoList.Data.cs.Entities;
using META_TodoList.Models;

namespace META_TodoList.Services
{
    public interface IUserService
    {
        void createNewUser(string id, string email, string pass, string repass);
        List<DBUserSignUp> SearchUser(string id, string pass);
        void DeleteUser(string id);
        void UpdateUser(string id, string idNew, string emailNew, string passNew, string repassNew);
		List<DBUserSignUp> CheckUserName(string id);

	}
}
