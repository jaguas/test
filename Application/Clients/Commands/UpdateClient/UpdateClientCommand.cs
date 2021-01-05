using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            entity.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
