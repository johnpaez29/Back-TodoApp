using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoServiceApp.Model.DTO;
using ToDoServiceApp.Business.Handlers;

namespace ToDoServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListItemController : ControllerBase
    {

        private readonly ITodoListItemHandler _todoListItem;

        public TodoListItemController(
            ITodoListItemHandler todoListItem)
        {
            _todoListItem = todoListItem;
        }

        [HttpGet(Name = "TodoListItem")]
        public Response Get()
        {
            try
            {
                return new Response
                {
                    Data = _todoListItem.GetList(),
                    Error = string.Empty,
                    Status = (int)HttpStatusCode.OK
                };

            }
            catch (Exception e)
            {
                return new Response
                {
                    Error = e.Message,
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpPost(Name = "TodoListItem")]
        public Response Insert(ToDoItem toDoObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _todoListItem.Insert(toDoObject);

                    return new Response
                    {
                        Status = (int)HttpStatusCode.OK
                    };
                }
                return new Response
                {
                    Status = (int)HttpStatusCode.BadRequest
                };

            }
            catch (Exception e)
            {
                return new Response
                {
                    Error = e.Message,
                    Status = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
