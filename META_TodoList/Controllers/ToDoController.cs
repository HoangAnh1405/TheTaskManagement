using META_TodoList.Models.Jwt_Model;
using META_TodoList.Models.ToDoList_Model;
using META_TodoList.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace META_TodoList.Controllers
{
    [Route("/ToDo/{action}")]

    public class ToDoController : Controller
    {
        private readonly ILogger<UserController> _todologger;
        private readonly IToDoList _todolist;
        public ToDoController(ILogger<UserController> todologger, IToDoList todolist)
        {
            _todologger = todologger;
            _todolist = todolist;
        }
        [HttpPost("/ToDo/CreateTitle")]
        public IActionResult CreateTitle([FromBody] string text)
        {
            string userName = HttpContext.User.Identity.Name;
            _todolist.createTitle(userName,text);
            return Ok();
        }
        [HttpPost("/ToDo/DeleteTitle")]
        public IActionResult DeleteTitle([FromBody] string deletetitle)
        {
            string userName = HttpContext.User.Identity.Name;
            _todolist.deleteTitle(userName, deletetitle);
            return Ok();
        }
        [HttpPost("/ToDo/CheckTitle")]
        public IActionResult CheckTitle([FromBody] string checktitle)
        {
            string userName = HttpContext.User.Identity.Name;
            _todolist.checkTitle(userName,checktitle);
            return Ok();
        }
    }
}
