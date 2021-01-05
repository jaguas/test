using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = new Client
            { 
                Name = request.Name
            };

            _context.Clients.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
