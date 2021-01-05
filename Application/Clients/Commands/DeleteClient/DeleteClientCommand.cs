using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteClientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Clients.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Client), request.Id);
            }

            _context.Clients.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
