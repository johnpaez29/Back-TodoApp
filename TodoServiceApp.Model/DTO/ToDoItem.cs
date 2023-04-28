using System.ComponentModel.DataAnnotations;

namespace TodoServiceApp.Model.DTO
{
    public class ToDoItem : BaseTodo
    {
        [Required]
        public int IdToDoItem { get; set; }

        [Required]
        public bool IsCheck { get; set; }
    }
}
