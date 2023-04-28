namespace ToDoServiceApp.DataService.ModelsSql;

public partial class TodoItem
{
    public int IdTodoItem { get; set; }

    public string Name { get; set; } = null!;

    public int IdTodoObject { get; set; }

    public bool IsCheck { get; set; }

    public virtual TodoObject IdTodoObjectNavigation { get; set; } = null!;
}
