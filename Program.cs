using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Dapper.Contrib.Extensions;
using ConsoleApp5.Model;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var bands = CollectionCreator.CreateBandList();
            //var bestBands = CollectionCreator.SelectBestBands(bands);
            //CollectionCreator.DisplayItems(bestBands);
            //var serialized = JsonSaver.SerializeToJson(bestBands);
            //JsonSaver.SaveFileAsJson(serialized);

            //bands.InsertIntoDb();
            var bandsFromDb = Repository.GetAll<Band>();

            foreach (var band in bandsFromDb)
            {
                Console.WriteLine(band);
            }

            //bands.SelectBestBands();

            // zaimplementować update
            // dependecy injection
            // testy jednostkowe
        }




    }
}
