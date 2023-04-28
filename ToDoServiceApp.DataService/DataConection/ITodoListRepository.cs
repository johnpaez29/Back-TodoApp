using ToDoServiceApp.DataService.ModelsSql;

namespace ToDoServiceApp.DataService.DataConection
{
    public interface ITodoListRepository<T>
    {
        IEnumerable<T> GetByUser(string userName);
        void Delete(int id);
        void Insert(TodoObject todoObject);
    }
}
