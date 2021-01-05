using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Clients.Queries.GetClients
{
    public class ClientDto : IMapFrom<Client>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
