using META_TodoList.Models.User_Model;

namespace META_TodoList.Models.Jwt_Model
{
    public interface IProviderJwt
    {
        string Generate(UserSignIn user);
    }
}