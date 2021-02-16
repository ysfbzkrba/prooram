using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using prooram.Application.CategoryMediatr.DTO;

namespace prooram.Application.CategoryMediatr.Queries
{
    public class GetAllCategoriesQuery : IRequest<IList<CategoryDTO>>
    {
        
    }
}
