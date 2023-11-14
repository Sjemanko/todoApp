global using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;


namespace todoApp.Services.TodoItemsService
{
    public class TodoItemsService : ITodoItemsService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TodoItemsService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetTodoItemDto>>> AddTodoItem(AddTodoItemDto newTodoItem)
        {
            var serviceResponse = new ServiceResponse<List<GetTodoItemDto>>();
            try
            {
                var todoItem = _mapper.Map<TodoItem>(newTodoItem);
                await _context.TodoItems.AddAsync(todoItem);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.TodoItems.Select(t => _mapper.Map<GetTodoItemDto>(t)).ToListAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoItemDto>> GetTodoItem(int id)
        {
            var serviceResponse = new ServiceResponse<GetTodoItemDto>();
            try
            {
                var dbTodoItem = await _context.TodoItems.FirstAsync(t => t.Id == id);
                serviceResponse.Data = _mapper.Map<GetTodoItemDto>(dbTodoItem);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTodoItemDto>>> GetTodoItems()
        {
            var dbTodoItems = await _context.TodoItems.ToListAsync();
            var serviceResponse = new ServiceResponse<List<GetTodoItemDto>>
            {
                Data = dbTodoItems.Select(t => _mapper.Map<GetTodoItemDto>(t)).ToList()
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTodoItemDto>> UpdateTodoItem(UpdateTodoItemDto updatedTodoItem)
        {
            var serviceResponse = new ServiceResponse<GetTodoItemDto>();
            try
            {
                var todoItem = await _context.TodoItems.FirstAsync(t => t.Id == updatedTodoItem.Id);

                // _mapper.Map<TodoItem>(updatedTodoItem);
                _mapper.Map(updatedTodoItem, todoItem);

                // todoItem.Content = updatedTodoItem.Content;
                // todoItem.IsDone = updatedTodoItem.IsDone;

                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<GetTodoItemDto>(todoItem);
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
        public async Task<ServiceResponse<GetTodoItemDto>> DeleteTodoItem(int id)
        {
            var serviceResponse = new ServiceResponse<GetTodoItemDto>();
            try
            {
                var todoItem = await _context.TodoItems.FirstAsync(t => t.Id == id);

                _context.TodoItems.Remove(todoItem);

                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetTodoItemDto>(todoItem);
                serviceResponse.Message = $"TodoItem with id {todoItem.Id} has been deleted.";

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
        }
    }
}