using ToDoServiceApp.DataService.ModelsSql;

namespace ToDoServiceApp.DataService.DataConection
{
    public class TodoListItemRepository : ITodoListItemRepository<TodoItem>
    {
        private readonly ToDoContext _context;
        public TodoListItemRepository(ToDoContext context)
        {
            _context = context;
        }

        public void Add(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TodoItem item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItem> GetItemsById(int id)
        {
            return _context.TodoItems.Where(item => item.IdTodoObject == id);
        }
    }
}
