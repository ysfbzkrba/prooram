using MediatR;
using System;

namespace prooram.Application.CategoryMediatr.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }

    }
}
