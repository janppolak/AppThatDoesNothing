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

            var reader = new EntityDataReader(GetRepository());
            reader.ListAllItems<Band>();

            var updater = new EntityDataWriter(InsertEntities());
            updater.InsertIntoDb(bands);

        }
        private static IRepository GetRepository()
        {
            return new Repository();
        }
        private static IRepository InsertEntities()
        {
            return new Repository();
        }

        // .gitignore i czyste repo w GH - done
        // zaimplementować update - done
        // dependecy injection
        // testy jednostkowe
    }
}
