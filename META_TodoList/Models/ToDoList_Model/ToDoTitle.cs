namespace META_TodoList.Models.ToDoList_Model
{
    public class ToDoTitle
    {
        public string? _id { get; set; }
        public List<string>? _title { get; set; }

        public List<string>? _checkedtitle { get; set; }
       public ToDoTitle(string? id, List<string>? title, List<string>? checkedtitle)
        {
            _id = id;
            _title = title;
            _checkedtitle = checkedtitle;
        }
    }
}
