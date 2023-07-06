using META_TodoList.Data.cs.EF;
using META_TodoList.Data.cs.Entities;
using META_TodoList.Models.ToDoList_Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Web.Helpers;

namespace META_TodoList.Services.EFDBcontext.ToDoList_EF_Service
{
    public class ToDoListEF : IToDoList, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbString;
        private readonly META_DBcontext _dbContext;
        public ToDoListEF(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbString = _configuration.GetConnectionString("EFDBConn");
            _dbContext = META_DBcontext.CreateContexFromDbConnStr(_dbString);
        }
        public void checkTitle(string id, string title)
        {
            var checkedtitle = "1";
            List<DBToDoTitle> result = (from p in _dbContext.DBToDoTitle where (p.User_Id == id && p._title == title) select p).ToList();
            if (result != null)
            {
                foreach (var item in result)
                {
                    if (item._checkedtitle == checkedtitle)
                    {
                        Dispose();
                    }
                    else
                        try
                        {
                            item._checkedtitle = checkedtitle;
                            _dbContext.SaveChanges();
                        }
                        catch ( Exception e)
                        {
                            continue;
                        } 
                }
            }
        }

        public void createTitle(string id, string title)
        {
            string checktitle = "0";
            var titleDB = new DBToDoTitle()
            {
                User_Id = id,
                _title = title,
                _checkedtitle = checktitle
            };
            _dbContext.DBToDoTitle.Add(titleDB);
            // Thực hiện cập nhật thay đổi trong DbContext lên Server
            _dbContext.SaveChanges();
            Dispose();
        }

        public void deleteTitle(string id, string title)
        {
            DBToDoTitle titleDB = (from p in _dbContext.DBToDoTitle where (p.User_Id == id && p._title == title) select p).SingleOrDefault();
            if (titleDB != null)
            {
                _dbContext.Remove(titleDB);
                _dbContext.SaveChanges();
                Dispose();

            }
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
        public List<DBToDoTitle> getTitle(string id)
        {
            List<DBToDoTitle> titleList = (from p in _dbContext.DBToDoTitle where (p.User_Id == id) select p).ToList();
            _dbContext.SaveChanges();
            Dispose();
            return titleList;
        }
    }
}
