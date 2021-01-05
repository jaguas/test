using Application.Common.Interfaces;
using CsvHelper;
using Infrastructure.Files.Maps;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Infrastructure.Files
{
    public class CsvFileBuilder<T> : ICsvFileBuilder<T>
    {
        public byte[] BuildFile(IEnumerable<T> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.RegisterClassMap<ClientRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
