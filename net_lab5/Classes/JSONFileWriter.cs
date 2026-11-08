using net_lab5.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab5.Classes
{
    public class JSONFileWriter : IFIleSaver
    {
        public async Task SaveAsync<T>(string filePath, List<T> data)
        {
            string? directoryPath = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string json = System.Text.Json.JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(filePath, json);
        }
    }
}
