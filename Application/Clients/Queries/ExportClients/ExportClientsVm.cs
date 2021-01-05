namespace Application.Clients.Queries.ExportClients
{
    public class ExportClientsVm
    {
        public string FileName { get; set; }
        public string ContextType { get; set; }
        public byte[] Content { get; set; }
    }
}
