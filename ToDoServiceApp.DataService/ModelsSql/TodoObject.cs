namespace ToDoServiceApp.DataService.ModelsSql;

public partial class TodoObject
{
    public int IdTodoObject { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public virtual ICollection<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}
