using System.Threading;
using System.Threading.Tasks;

using MediatR;
using prooram.Application.CategoryMediatr.Commands;
using prooram.Application.Common.Interfaces;


namespace prooram.Application.CategoryMediatr.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCategoryHandler(IApplicationDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await _context.Categories.FindAsync(request.Id);
            category.CategoryName = request.CategoryName;

            _context.Categories.Update(category);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
