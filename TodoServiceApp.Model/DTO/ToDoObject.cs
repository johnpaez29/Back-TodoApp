using System.ComponentModel.DataAnnotations;

namespace TodoServiceApp.Model.DTO
{
    public class ToDoObject : BaseTodo
    {
        [Required]
        public int IdTodoObject { get; set; }
        [Required]
        public string? UserName { get; set; }
        public IEnumerable<ToDoItem>? Items { get; set; }
    }
}
