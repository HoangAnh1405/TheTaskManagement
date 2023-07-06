using META_TodoList.Models.Jwt_Model;
using META_TodoList.Models.User_Model;
using META_TodoList.Models.ToDoList_Model;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using META_TodoList.Services.EFDBcontext.User_EF_Service;
using META_TodoList.Services;
using META_TodoList.Data.cs.Entities;

namespace META_TodoList.Controllers
{
    [Route("User/{action}")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _userlogger;
        private readonly IUserService _userService;
        private readonly IProviderJwt _providerJwt;
        private readonly IToDoList _todolistService;
		public UserController(ILogger<UserController> userlogger, IUserService userService, IProviderJwt providerJwt, IToDoList todolistService)
        {
            _userlogger = userlogger;
            _userService = userService;
            _providerJwt = providerJwt;
            _todolistService = todolistService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> SISubmit([FromForm] string SIid, string SIpass)
        {

            List<DBUserSignUp> userDB = _userService.SearchUser(SIid, SIpass);
            if (userDB.Count() > 0)
            {
                var user = new UserSignIn(SIid, SIpass)
                {
                    _id = SIid,
                    _pass = SIpass,
                };

                string tokenForUser = _providerJwt.Generate(user);

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Role, "User"),
                    new Claim(ClaimTypes.Name, user._id),
                    };
                var userIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                });
                return RedirectToAction("UserIndex");
            }
            else
                return RedirectToAction("SubmitFail");

        }
        [Authorize]
        [HttpGet]
        public IActionResult UserIndex()
        {
            List<string> titleList = new List<string>();
            List<string> checkedtitleList = new List<string>();
            string userName = HttpContext.User.Identity.Name;
            List<DBToDoTitle> listtitle = _todolistService.getTitle(userName);
            foreach (var solution in listtitle)
            {
				if (solution._checkedtitle == "0")
                {
                    titleList.Add(solution._title);
                }
                else if (solution._checkedtitle == "1")
                {
                    checkedtitleList.Add(solution._title);
                }
            }
            ToDoTitle toDoTitle = new ToDoTitle(userName,titleList,checkedtitleList);
            return View("UserIndex",toDoTitle);
        }
        public async Task<IActionResult> SILogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn");
        }
        [HttpPost]
        public IActionResult Submit(string id, string email, string pass, string repass)
        {
            _userService.createNewUser(id, email, pass, repass);
            return View("Submit");
        }
		[HttpPost]
		public JsonResult Check([FromBody] string _id)
        {
            List<DBUserSignUp> usernameDB = _userService.CheckUserName(_id);
            if (usernameDB.Count() == 1)
            {  
                return new JsonResult(new { status = 0, message="ID Was Used", userid=_id});
			}
            else
			{
				return new JsonResult(new { status = 1, message = "ID Is Avalable", userid=_id });
			}
		}
		public IActionResult SignUp()
        {
			return View();
        }
		public IActionResult SubmitFail()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserUpdate(string id, string idNew, string emailNew, string passNew, string repassNew)
        {
            _userService.UpdateUser(id, idNew, emailNew, passNew, repassNew);
            return View("UserWork");
        }
    }
}
