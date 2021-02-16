using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.Handlers
{
    using MediatR;
    using prooram.Application.CategoryMediatr.DTO;
    using prooram.Application.CategoryMediatr.Queries;
    using prooram.Application.Common.Interfaces;
    using System.Threading;

    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, EditCategoryDTO>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryHandler(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<EditCategoryDTO> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            var dto = new EditCategoryDTO { Id = category.Id, CategoryName=category.CategoryName };

            return dto;
        }
    }
}
