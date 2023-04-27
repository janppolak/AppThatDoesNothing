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

            var reader = new EntityDataReader(GetRepository());
            reader.ListAllItems<Band>();

            //bands.SelectBestBands();

            // zaimplementować update
            // dependecy injection
            // testy jednostkowe
            // .gitignore i czyste repo w GH
        }

        private static IRepository GetRepository()
        {
            return new Repository();
        }
    }
}
