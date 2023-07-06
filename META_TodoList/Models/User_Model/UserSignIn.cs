using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace META_TodoList.Models.User_Model
{
    public class UserSignIn
    {
        [BindProperty]
        public string _id { get; set; }
        public string _pass { get; set; }

        public UserSignIn(string id, string pass)
        {
            _id = id;
            _pass = pass;
        }
    }
}
