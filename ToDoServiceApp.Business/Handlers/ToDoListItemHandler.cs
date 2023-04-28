using TodoServiceApp.Model.DTO;
using ToDoServiceApp.DataService.DataConection;
using ToDoServiceApp.DataService.ModelsSql;

namespace ToDoServiceApp.Business.Handlers
{
    public class ToDoListItemHandler : ITodoListItemHandler
    {
        private readonly ITodoListItemRepository<TodoItem> _todoListItemRepository;
        public ToDoListItemHandler(ITodoListItemRepository<TodoItem> todoListItemRepository)
        {
            _todoListItemRepository = todoListItemRepository;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToDoItem> GetItemsById(int id)
        {
            return _todoListItemRepository.GetItemsById(id)
                .Select(item => 
                    new ToDoItem 
                    { 
                        Name = item.Name,
                        IsCheck = item.IsCheck,
                        IdToDoItem = item.IdTodoItem
                    });
        }

        public IEnumerable<ToDoItem> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(ToDoItem ItodoItem)
        {
            throw new NotImplementedException();
        }
    }
}
