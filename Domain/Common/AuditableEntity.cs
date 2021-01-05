using System;

namespace Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        public string CreateBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
