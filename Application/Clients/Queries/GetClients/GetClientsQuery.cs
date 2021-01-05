using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients.Queries.GetClients
{
    public class GetClientsQuery : IRequest<List<ClientDto>>
    {
    }

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, List<ClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Clients
                    .AsNoTracking()
                    .ProjectTo<ClientDto>(_mapper.ConfigurationProvider)
                    .OrderBy(c => c.Name)
                    .ToListAsync(cancellationToken);
        }
    }
}
