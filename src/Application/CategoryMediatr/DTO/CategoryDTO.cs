using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prooram.Application.CategoryMediatr.DTO
{
    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
