using META_TodoList.Models.ToDoList_Model;

namespace META_TodoList.Services
{
    public interface IToDoList
    {
        void createTitle(string id, string title);
        void deleteTitle(string id, string title);
        void checkTitle(string id, string title);
        List<DBToDoTitle> getTitle(string id);

    }
}
