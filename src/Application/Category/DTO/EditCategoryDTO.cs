using System;

namespace prooram.Application.Category.DTO
{
    public class EditCategoryDTO
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
