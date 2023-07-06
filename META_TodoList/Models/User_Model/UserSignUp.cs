using System.Web;
using META_TodoList.Controllers;
using META_TodoList.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace META_TodoList.Models.User_Model
{
	[Table("UserSignUp")]
	public class UserSignUp
	{
		[Key]
		[Required]
		public string? _id { get; set; }

		[Required]
		[StringLength(50)]
		public string? _email { get; set; }

		[StringLength(50)]
		public string? _pass { get; set; }

		[StringLength(50)]
		public string? _repass { get; set; }

		[StringLength(50)]
		public string? _submit { get; set; }


	}
}
