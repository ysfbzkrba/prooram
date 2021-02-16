using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.Commands
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }

    }
}
