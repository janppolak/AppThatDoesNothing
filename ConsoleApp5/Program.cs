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
            var bands = CollectionCreator.CreateBandList();
            //var bestBands = CollectionCreator.SelectBestBands(bands);
            //CollectionCreator.DisplayItems(bestBands);
            //var serialized = JsonSaver.SerializeToJson(bestBands);
            //JsonSaver.SaveFileAsJson(serialized);

            var repository = GetRepository();

            //repository.InsertMany(bands);

            //var reader = new EntityDataReader(repository);
            //reader.ListAllItems<Band>();
            var band = repository.Get<Band>(2);
            Console.WriteLine(band);

        }
        private static IRepository GetRepository()
        {
            return new Repository();
        }

        // .gitignore i czyste repo w GH - done
        // zaimplementować update - done
        // dependecy injection
        // testy jednostkowe
    }
}
