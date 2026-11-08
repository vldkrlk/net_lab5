using net_lab5.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab5.Classes
{
    public class JSONFileReader : IFileLoader
    {
        public async Task<List<T>> LoadAsync<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                return System.Text.Json.JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            else
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
        }
    }
}
