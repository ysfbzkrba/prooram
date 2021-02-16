using MediatR;
using System;

namespace prooram.Application.CategoryMediatr.Commands
{
    public class UpdateCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }

    }
}
