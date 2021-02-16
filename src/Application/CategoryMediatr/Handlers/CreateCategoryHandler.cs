using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using prooram.Application.CategoryMediatr.Commands;
using prooram.Application.Common.Interfaces;


namespace prooram.Application.CategoryMediatr.Handlers
{
    using prooram.Domain.Entities;
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = new Category  // Category is also a namespace in Application.Category. so using is added after namespace in class.
            {
                CategoryName = request.CategoryName
            };


            _context.Categories.Add(category);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
