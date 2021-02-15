using System;

namespace prooram.Domain.Common
{
    public class AuditableEntity
    {
        public AuditableEntity()  => this.Id = Guid.NewGuid(); 
        
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? Modified { get; set; }
        public string ModifiedBy { get; set; }
    }
}
