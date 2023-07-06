using META_TodoList.Data.cs.EF;
using META_TodoList.Data.cs.Entities;
using META_TodoList.Models.User_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using META_TodoList.Controllers;

namespace META_TodoList.Services.EFDBcontext.User_EF_Service
{
	public class UserEF : IUserService, IDisposable
	{
		private readonly IConfiguration _configuration;
		private readonly string _dbString;
		private readonly META_DBcontext _dbContext;
		public UserEF(IConfiguration configuration)
		{
			_configuration = configuration;
			_dbString = _configuration.GetConnectionString("EFDBConn");
			_dbContext = META_DBcontext.CreateContexFromDbConnStr(_dbString);
		}
		public void Dispose()
		{
			_dbContext.Dispose();
		}
		public void createNewUser(string id, string email, string pass, string repass)
		{
			Algorithm al = new Algorithm();
			var encodepass= al.GenerateMD5(pass);
			var encoderepass = al.GenerateMD5(repass);
			var user = new DBUserSignUp()
			{
				_id = id,
				_email = email,
				_pass = encodepass,
				_repass = encoderepass
			};
			_dbContext.DBUserSignUp.Add(user);
			// Thực hiện cập nhật thay đổi trong DbContext lên Server
			_dbContext.SaveChanges();
			Dispose();
		}
		public void DeleteUser(string id)
		{
			var user = (from p in _dbContext.DBUserSignUp where (p._id == id) select p).FirstOrDefaultAsync();
			if (user != null)
			{
				_dbContext.Remove(user);
				_dbContext.SaveChanges();
			}
			Dispose();
		}
		public List<DBUserSignUp> SearchUser(string id, string pass)
		{
			Algorithm al = new Algorithm();
			var encodepass = al.GenerateMD5(pass);
			var users =
				(from p in _dbContext.DBUserSignUp where (p._id == id && p._pass == encodepass) select p)
				.ToList();
			return users;
		}
		public void UpdateUser(string id, string idNew, string emailNew, string passNew, string repassNew)
		{
			Algorithm al = new Algorithm();
			var encodepass = al.GenerateMD5(passNew);
			var encoderepass = al.GenerateMD5(repassNew);
			DBUserSignUp users =
				(from p in _dbContext.DBUserSignUp where (p._id == id) select p).FirstOrDefault();
			if (users != null)
			{
				users._id = idNew;
				users._pass = encodepass;
				users._repass = encoderepass;
				users._email = emailNew;
				_dbContext.SaveChanges();
			}
		}

		public List<DBUserSignUp> CheckUserName(string id)
		{ 
			var users =
				(from p in _dbContext.DBUserSignUp where (p._id == id) select p)
				.ToList();
			return users;
		}
	}
}
