using System;

namespace prooram.Application.CategoryMediatr.Queries
{
    using MediatR;
    using prooram.Application.CategoryMediatr.DTO;

    public class DetailsCategoryQuery : IRequest<DetailsCategoryDTO>
    {
        public Guid Id { get; set; }

    }
}
