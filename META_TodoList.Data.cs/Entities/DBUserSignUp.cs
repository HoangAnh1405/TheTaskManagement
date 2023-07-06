using META_TodoList.Models.ToDoList_Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace META_TodoList.Data.cs.Entities
{
	[Table("UserSignUp")]
	public class DBUserSignUp
	{

		public string? _id { get; set; }

		public string? _email { get; set; }

		public string? _pass { get; set; }

		public string? _repass { get; set; }

		public ICollection<DBToDoTitle> titles { get; } = new List<DBToDoTitle>();

	}
}
