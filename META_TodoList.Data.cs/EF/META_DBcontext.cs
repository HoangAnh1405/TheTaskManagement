using META_TodoList.Data.cs.Configurations;
using META_TodoList.Data.cs.Entities;
using META_TodoList.Models.ToDoList_Model;
using Microsoft.EntityFrameworkCore;

namespace META_TodoList.Data.cs.EF
{
    public class META_DBcontext : DbContext
    {

		public META_DBcontext(DbContextOptions<META_DBcontext> options) : base(options) { }
		public META_DBcontext(string connectionString) : base(GetOptions(connectionString))
		{
		}

		public static META_DBcontext CreateContexFromDbConnStr(string connectionString)
		{
			return new META_DBcontext(connectionString);
		}

		private static DbContextOptions GetOptions(string connectionString)
		{
			return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
			//return MySqlDbContextOptionsBuilderExtensions.UseMySql(new DbContextOptionsBuilder(), connectionString).Options;
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// DATA Fluent API 
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
			modelBuilder.ApplyConfiguration(new UserSignUpConfiguration());
			modelBuilder.ApplyConfiguration(new ToDoTitleConfiguration());
			// DATA Seeding 

		}
		public DbSet<DBUserSignUp> DBUserSignUp { get; set; }

		public DbSet<DBToDoTitle> DBToDoTitle { get; set; }
	}
}