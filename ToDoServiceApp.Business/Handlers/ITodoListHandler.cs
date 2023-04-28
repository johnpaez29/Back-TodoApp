using TodoServiceApp.Model.DTO;
using ToDoServiceApp.DataService.ModelsSql;

namespace ToDoServiceApp.Business.Handlers
{
    public interface ITodoListHandler
    {
        IEnumerable<ToDoObject> GetList(string userName);

        void Delete(int id);

        void Insert(ToDoObject Itodo);

    }
}
