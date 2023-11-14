using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoApp.Dtos.TodoItem;

namespace todoApp.Services.TodoItemsService
{
    public interface ITodoItemsService
    {
        Task<ServiceResponse<List<GetTodoItemDto>>> GetTodoItems();
        Task<ServiceResponse<GetTodoItemDto>> GetTodoItem(int id);
        Task<ServiceResponse<List<GetTodoItemDto>>> AddTodoItem(AddTodoItemDto newTodoItem);
        Task<ServiceResponse<GetTodoItemDto>> UpdateTodoItem(UpdateTodoItemDto updatedTodoItem);
        Task<ServiceResponse<GetTodoItemDto>> DeleteTodoItem(int id);
    }
}