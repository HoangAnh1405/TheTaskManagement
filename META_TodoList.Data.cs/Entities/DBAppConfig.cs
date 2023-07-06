using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace META_TodoList.Data.cs.Entities
{
	[Table("AppConfig")]
	public class DBAppConfig
	{
		public int key { get; set; }
		public int value { get; set; }
	}
}
