using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Producer.Services
{
    public class ReadData<T>
    {
        public List<T>? ReadToObjectsList(string path)
        {
            string raw = File.ReadAllText(path);
            List<T>? result = JsonSerializer.Deserialize<List<T>>(raw);
            return result;
        }
    }
}
