using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Domain.Wrapper;
using Domain.Emtities;

namespace TodoWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController
    {
        private TodoServices _services;
        public TodoController()
        {
            _services = new TodoServices();
        }
        [HttpPost("AddNewTodo")]
        public async Task<Response<Todo>> AddTodo(Todo todo)
        {
            return await _services.AddTodo(todo); 
        }
        [HttpGet("GetAllTodos")]
        public async Task<Response<List<Todo>>> GetTodo()
        {
            string name = Status.InPostrress.ToString();

            return await _services.GetTodo();
        }
    [HttpPut("UpdateTodo")]
    public async Task<Response<Todo>> UpdateTodo(Todo todo)
    {
        return await _services.UpdateTodo(todo); 
    }
    [HttpDelete("DeleteTodo")]
    public async Task<Response<string>> DeleteTodo(int id)
    {
        return await _services.DeleteTodo(id); 
    }
    [HttpGet]
    public async Task<Response<List<TodoDto>>> GetTodoWithStatusName()
    {
        return await _services.GetTodoWithStatusName(); 
    }



    }
