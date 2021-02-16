using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.Handlers
{
    using MediatR;
    using prooram.Application.CategoryMediatr.DTO;
    using prooram.Application.CategoryMediatr.Queries;
    using prooram.Application.Common.Interfaces;
    using System.Threading;

    public class DetailsCategoryHandler : IRequestHandler<DetailsCategoryQuery, DetailsCategoryDTO>
    {
        private readonly IApplicationDbContext _context;

        public DetailsCategoryHandler(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<DetailsCategoryDTO> Handle(DetailsCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            var dto = new DetailsCategoryDTO
            {
                Id = category.Id, 
                CategoryName = category.CategoryName,
                Modified =category.Modified,
                ModifiedBy = category.ModifiedBy,
                Created = category.Created,
                CreatedBy = category.CreatedBy
            };

            return dto;
        }
    }
}
