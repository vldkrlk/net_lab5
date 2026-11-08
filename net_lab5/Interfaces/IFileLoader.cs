using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_lab5.Interfaces
{
    public interface IFileLoader
    {
        Task<List<T>> LoadAsync<T>(string filePath);
    }
}
