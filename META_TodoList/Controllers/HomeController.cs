using META_TodoList.Models.Jwt_Model;
using META_TodoList.Models.Message_Model;
using META_TodoList.Models.User_Model;
using META_TodoList.Setup;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using static Dapper.SqlMapper;


namespace META_TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _homelogger;
        public HomeController(ILogger<HomeController> homelogger)
        {
            _homelogger = homelogger;
        }
        public IActionResult Index()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

        }
		public IActionResult AboutUs()
		{
			return View();
		}
		public IActionResult Contact()
		{
			return View();
		}
		public IActionResult HowClientThink()
		{
			return View();
		}
		public IActionResult Product()
		{
			return View();
		}
		public IActionResult TellmeMore()
		{
			return View();
		}
	}
}