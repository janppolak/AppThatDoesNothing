using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp5
{
    public class JsonSaver
    {
        public static string SerializeToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static void SaveFileAsJson(string serialized)
        {
            var path = @"c:\users\janek\desktop\fuckinnew.json";
            File.WriteAllText(path, serialized);
        }
    }
}
