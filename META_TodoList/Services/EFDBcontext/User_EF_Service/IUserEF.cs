namespace META_TodoList.Services.EFDBcontext.User_EF_Service
{
	public interface IUserEF
	{
		Task InsertUser(string id, string email, string pass, string repass);
	}
}
