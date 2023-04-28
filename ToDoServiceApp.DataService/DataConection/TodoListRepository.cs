using TodoServiceApp.Model.DTO;
using ToDoServiceApp.DataService.ModelsSql;

namespace ToDoServiceApp.DataService.DataConection
{
    public class TodoListRepository : ITodoListRepository<TodoObject>
    {
        private readonly ToDoContext _context;
        public TodoListRepository(ToDoContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            _context.TodoItems.RemoveRange(
                 _context.TodoItems.Where(objectToDo => objectToDo.IdTodoObject == id).ToList()
                );

            var objectTodo = _context.TodoObjects.FirstOrDefault(objectToDo => objectToDo.IdTodoObject == id);

            if (objectTodo != null)
            {
                _context.TodoObjects.Remove(objectTodo);
            }

            _context.SaveChanges();
        }

        public IEnumerable<TodoObject> GetByUser(string userName)
        {
            return _context.TodoObjects.Where(objectTodo => objectTodo.UserName.ToUpper() == userName.ToUpper());
        }

        public void Insert(TodoObject todoObject)
        {
            if (todoObject.IdTodoObject != 0)
            {
                var todoObjectData = _context.TodoObjects.FirstOrDefault(item => item.IdTodoObject == todoObject.IdTodoObject);
                if (todoObjectData != null)
                {
                    _context.TodoItems.RemoveRange(_context.TodoItems.Where(item => item.IdTodoObject == todoObject.IdTodoObject));

                    _context.TodoObjects.Remove(todoObjectData);
                }
            }
            _context.TodoObjects.Add(todoObject);
            _context.TodoItems.AddRange(todoObject.TodoItems);
            _context.SaveChanges();
        }
    }
}
