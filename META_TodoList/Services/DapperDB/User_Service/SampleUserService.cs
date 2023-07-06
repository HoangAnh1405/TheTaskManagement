using META_TodoList.Models.User_Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.DiaSymReader;

namespace META_TodoList.Services.DapperDB.User_Service
{
    public class SampleUserService
    {
        public void createNewUser(string id, string email, string pass, string repass)
        {
            ListUserSignUp.userList.Add(new UserSignUp()
            {
                _id = id,
                _email = email,
                _pass = pass,
                _repass = repass
            });
        }
        public dynamic SearchUser(string id, string pass)
        {
            var _userList = ListUserSignUp.userList;
            UserSignUp userFinding = _userList.Find((u) =>
            {
                return u._id == id && u._pass == pass;
            });
            return userFinding;
        }
        public void DeleteUser(string id)
        {
            var _userList = ListUserSignUp.userList;
            UserSignUp userFinding = _userList.Find((u) =>
            {
                return u._id == id;
            });
            ListUserSignUp.userList.Remove(userFinding);
        }

        public void UpdateUser(string id, string idNew, string emailNew, string passNew, string repassNew)
        {
            var _userList = ListUserSignUp.userList;
            UserSignUp userFinding = _userList.Find((u) =>
            {
                return u._id == id;
            });
            userFinding._id = idNew;
            userFinding._email = emailNew;
            userFinding._pass = passNew;
            userFinding._repass = repassNew;
        }
    }
}
