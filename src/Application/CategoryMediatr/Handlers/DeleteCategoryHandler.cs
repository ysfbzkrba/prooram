using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MediatR;
using prooram.Application.CategoryMediatr.Commands;
using prooram.Application.Common.Interfaces;


namespace prooram.Application.CategoryMediatr.Handlers
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {

            var category = await _context.Categories.FindAsync(request.Id);
            _context.Categories.Remove(category);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
