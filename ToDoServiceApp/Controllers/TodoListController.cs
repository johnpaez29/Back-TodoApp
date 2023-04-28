using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoServiceApp.Model.DTO;
using ToDoServiceApp.Business.Handlers;

namespace ToDoServiceApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListHandler _todoListHandler;

        public TodoListController(
            ITodoListHandler todoListHandler)
        {
            _todoListHandler = todoListHandler;
        }

        /// <summary>
        /// Get All ToDoObjects by userId
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "TodoList")]
        public Response Get(string userName)
        {
            try
            {
                return new Response
                {
                    Data = _todoListHandler.GetList(userName),
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

        [HttpPost(Name = "TodoList")]
        public Response Insert(ToDoObject toDoObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _todoListHandler.Insert(toDoObject);

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

        [HttpDelete(Name = "TodoList")]
        public Response Delete(int idTodoObject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _todoListHandler.Delete(idTodoObject);

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