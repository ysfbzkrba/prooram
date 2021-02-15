using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using prooram.Application.Category.DTO;

namespace prooram.Application.Category.Queries
{
    public class GetAllCategoriesQuery : IRequest<IList<CategoryDTO>>
    {
        
    }
}
