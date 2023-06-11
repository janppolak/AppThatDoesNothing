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
            var isCorrect = true;
            int userInput;
            var repository = GetRepository();
            var reader = new EntityDataDisplayer(repository);
            

            do
            {
                Console.WriteLine("Choose action:  \n1 - to display all items from the database \n2 - to insert a new new record to the database \n3 - to delete item from the database");
                isCorrect = int.TryParse(Console.ReadLine(), out userInput);
            }while(!isCorrect);

            switch (userInput)
            {
                case 1:
                    if (!reader.ListAllItems<Band>().Any())
                    {
                        Console.WriteLine("The list is empty!");
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter a band name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Enter band rating: ");
                    int.TryParse(Console.ReadLine(), out var rating);
                    Console.WriteLine("Enter a band genre: ");
                    var genre = Console.ReadLine();

                    var newBand = new Band { Name = name, Rating = rating};
                    repository.Insert(newBand);

                    break;
                case 3:
                    reader.ListAllItems<Band>();
                    Console.WriteLine("Choose index of record you want to delete: ");
                    int.TryParse(Console.ReadLine(), out var entityToBeDeleted);
                    var band = repository.Get<Band>(entityToBeDeleted);
                    repository.Delete(band);
                    Console.WriteLine($"The item {band.Name} has been deleted successfully!");
                    reader.ListAllItems<Band>();
                    break;
            }

        }
        private static IRepository GetRepository()
        {
            return new Repository();
        }
    }
}
