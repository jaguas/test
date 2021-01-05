using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Clients.Queries.ExportClients
{
    public class ClientRecord : IMapFrom<Client>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
