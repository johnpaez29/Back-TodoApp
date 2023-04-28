using TodoServiceApp.Model.DTO;
using ToDoServiceApp.DataService.DataConection;
using ToDoServiceApp.DataService.ModelsSql;

namespace ToDoServiceApp.Business.Handlers
{
    public class ToDoListHandler : ITodoListHandler
    {
        public readonly ITodoListRepository<TodoObject> _todoListRepository;
        public readonly ITodoListItemHandler _todoListItemHandler;

        public ToDoListHandler(
            ITodoListRepository<TodoObject> todoListRepository,
            ITodoListItemHandler todoListItemHandler)
        {
            _todoListRepository = todoListRepository;
            _todoListItemHandler = todoListItemHandler;
        }

        public void Delete(int id)
        {
            _todoListRepository.Delete(id);
        }

        public IEnumerable<ToDoObject> GetList(string userName)
        {
            var list = _todoListRepository.GetByUser(userName).ToList();
            return list.Select(list => new ToDoObject
            {
                IdTodoObject = list.IdTodoObject,
                Name = list.Name,
                UserName = list.UserName,
                Items = _todoListItemHandler.GetItemsById(list.IdTodoObject)
            });
        }

        public void Insert(ToDoObject Itodo)
        {
            TodoObject todoObject = new TodoObject
            {
                IdTodoObject = Itodo.IdTodoObject,
                Name = Itodo.Name ?? string.Empty,
                UserName = Itodo.UserName ?? string.Empty,
                TodoItems = MapItems((Itodo.Items ?? Enumerable.Empty<ToDoItem>()).Where(item => !string.IsNullOrEmpty(item.Name)), Itodo.IdTodoObject)
            };

            _todoListRepository.Insert(todoObject);
        }

        private static ICollection<TodoItem> MapItems(IEnumerable<ToDoItem> ToDoItems, int idTodoObject)
        {
            return ToDoItems.Select(item => new TodoItem 
            { 
                IdTodoObject = idTodoObject,
                Name = item.Name ?? string.Empty,
                IsCheck = item.IsCheck
            }).ToList();
        }
    }
}
