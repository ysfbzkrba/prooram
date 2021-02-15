using prooram.Domain.Common;

// using System.ComponentModel.DataAnnotations;

namespace prooram.Domain.Entities
{
    public class Category : AuditableEntity
    {
        // [Required]
        // [StringLength(maximumLength:100)]
        public string CategoryName { get; set; }

    }
}
