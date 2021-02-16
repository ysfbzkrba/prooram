using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.Queries
{
    using MediatR;
    using prooram.Application.CategoryMediatr.DTO;

    public class GetCategoryQuery : IRequest<EditCategoryDTO>
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }
}
