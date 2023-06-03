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

            var repository = GetRepository();

            var reader = new EntityDataDisplayer(repository);
            reader.ListAllItems<Band>();


        }
        private static IRepository GetRepository()
        {
            return new Repository();
        }
    }
}
