using MediatR;
using prooram.Application.Category.Queries;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using prooram.Application.Category.DTO;
using prooram.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace prooram.Application.Category.Handlers
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IList<CategoryDTO>>
    {
        private IApplicationDbContext _context;
        public GetAllCategoriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<CategoryDTO>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.Categories
                    .Select(x=> new CategoryDTO
                    {
                        Id=x.Id,
                        CategoryName=x.CategoryName,
                        Created=x.Created,
                        CreatedBy=x.CreatedBy,
                        Modified=x.Modified,
                        ModifiedBy=x.ModifiedBy
                    }).ToListAsync(cancellationToken);

            return categories;
        }
    }
}


// QUERY AND DTOS ARE MESSED UP ==> admin area could not be added
