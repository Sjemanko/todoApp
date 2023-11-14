using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todoApp
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoItem, GetTodoItemDto>();
            CreateMap<AddTodoItemDto, TodoItem>();
            CreateMap<UpdateTodoItemDto, TodoItem>();
            CreateMap<DeleteTodoItemDto, TodoItem>();
        }
    }
}