using Application.Clients.Queries.ExportClients;
using CsvHelper.Configuration;
using System.Globalization;

namespace Infrastructure.Files.Maps
{
    public class ClientRecordMap : ClassMap<ClientRecord>
    {
        public ClientRecordMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
        }
    }
}
