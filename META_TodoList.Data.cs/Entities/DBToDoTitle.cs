using META_TodoList.Data.cs.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace META_TodoList.Models.ToDoList_Model
{
    [Table("ToDoTitle")]
    public class DBToDoTitle
    {

		public string _id { get; set; }
        public string _title { get; set; }

        public string _checkedtitle { get; set; }
        
        public string User_Id { get; set; }
        public DBUserSignUp users { get; set; } = null!;

	}
}
