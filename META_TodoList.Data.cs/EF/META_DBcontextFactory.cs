using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace META_TodoList.Data.cs.EF
{
	public class META_DBcontextFactory : IDesignTimeDbContextFactory<META_DBcontext>
	{
		public META_DBcontext CreateDbContext(string[] args)
		{
			IConfigurationRoot config = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsetting.json").Build();

			var connectionString = config.GetConnectionString("EFconnectStringDB");

			var optionsBuilder = new DbContextOptionsBuilder<META_DBcontext>();
			optionsBuilder.UseSqlServer(connectionString);
			//optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			return new META_DBcontext(optionsBuilder.Options);
		}
	}
}
