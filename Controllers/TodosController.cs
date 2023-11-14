using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace todoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoItemsService _todoItemsService;

        public TodosController(ITodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetTodoItemDto>>>> GetListOfTodos()
        {
            return Ok(await _todoItemsService.GetTodoItems());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoItemDto>>> GetSingleTodo(int id)
        {
            return Ok(await _todoItemsService.GetTodoItem(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetTodoItemDto>>>> AddTodoItem(AddTodoItemDto newTodoItem)
        {
            return Ok(await _todoItemsService.AddTodoItem(newTodoItem));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetTodoItemDto>>>> UpdateTodoItem(UpdateTodoItemDto updatedTodoItem)
        {
            var response = await _todoItemsService.UpdateTodoItem(updatedTodoItem);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTodoItemDto>>> DeleteTodoItem(int id)
        {
            var response = await _todoItemsService.DeleteTodoItem(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}