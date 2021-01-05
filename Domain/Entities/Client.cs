using Domain.Common;

namespace Domain.Entities
{
    public class Client : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
