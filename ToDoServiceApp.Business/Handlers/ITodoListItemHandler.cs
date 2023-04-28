using TodoServiceApp.Model.DTO;

namespace ToDoServiceApp.Business.Handlers
{
    public interface ITodoListItemHandler
    {
        IEnumerable<ToDoItem> GetList();

        IEnumerable<ToDoItem> GetItemsById(int id);
        void Insert(ToDoItem ItodoItem);

        void Delete(int id);

    }
}
