using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bands = CollectionCreator.CreateBandList();
            var bestBand = CollectionExtensions.SelectBestBand(bands);
            CollectionExtensions.DisplayItems(bestBand);
            var serialized = JsonSaver.SerializeToJson(bestBand);
            JsonSaver.SaveFileAsJson(serialized);


        }




    }
}
