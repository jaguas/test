using Application.Clients.Commands.CreateClient;
using Application.Clients.Commands.DeleteClient;
using Application.Clients.Commands.UpdateClient;
using Application.Clients.Queries.ExportClients;
using Application.Clients.Queries.GetClients;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Controllers
{
    public class ClientsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> GetClients()
        {
            return await Mediator.Send(new GetClientsQuery());
        }

        [HttpGet("csv")]
        public async Task<FileResult> Export()
        {
            var vm = await Mediator.Send(new ExportClientsQuery());
            return File(vm.Content, vm.ContextType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateClientCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateClientCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteClientCommand { Id = id });
            return NoContent();
        }
    }
}
