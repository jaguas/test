using Application.Common.Interfaces;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients.Queries.ExportClients
{
    public class ExportClientsQuery : IRequest<ExportClientsVm>
    {
    }

    public class ExpostClientsQueryHandler : IRequestHandler<ExportClientsQuery, ExportClientsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder<ClientRecord> _fileBuilder;

        public ExpostClientsQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder<ClientRecord> fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportClientsVm> Handle(ExportClientsQuery request, CancellationToken cancellationToken)
        {
            var vm = new ExportClientsVm();

            var records = await _context.Clients
                .ProjectTo<ClientRecord>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            vm.Content = _fileBuilder.BuildFile(records);
            vm.ContextType = "text/csv";
            vm.FileName = "Client.csv";

            return await Task.FromResult(vm);
        }
    }
}
