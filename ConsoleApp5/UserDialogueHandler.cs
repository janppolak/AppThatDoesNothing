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
    public class UserDialogueHandler
    {
        public static int ReadInt(string message)
        {
            var isCorrect = true;
            int userInputInt;
            do
            {
                Console.WriteLine(message);
                isCorrect = int.TryParse(Console.ReadLine(), out userInputInt);
            } while (!isCorrect || userInputInt > 3 || userInputInt < 1);
            return userInputInt;
        }
        public static void ListItemsFromDb(EntityDataDisplayer reader)
        {
            reader.ListAllItems<Band>();
            Console.WriteLine();
        }

        public static void InsertNewItemToDb(IRepository repository)
        {
            Console.WriteLine("Enter a band name: ");
            var name = Console.ReadLine();
            Console.WriteLine("Enter band rating: ");
            int.TryParse(Console.ReadLine(), out var rating);
            Console.WriteLine("Enter a band genre: ");
            var genreInput = Console.ReadLine();
            Genre genreResult = (Genre)Enum.Parse(typeof(Genre), genreInput);
            var newBand = new Band { Name = name, Rating = rating, GenreEnum = genreResult };
            repository.Insert(newBand);
            Console.WriteLine($"The item {newBand.Name} has been inserted successfully!\n");

        }
        public static void DeleteItemFromDb(EntityDataDisplayer reader, IRepository repository)
        {
            reader.ListAllItems<Band>();
            Console.WriteLine("Choose id of record you want to delete: ");
            int.TryParse(Console.ReadLine(), out var entityToBeDeleted);
            var bands = repository.GetAll<Band>();
            List<long> ids = new List<long>();
            foreach (var item in bands)
            {
                ids.Add(item.Id);
            }
            if (!ids.Contains(entityToBeDeleted))
            {
                Console.WriteLine($"There is no item with id: {entityToBeDeleted}!");
            }
            else
            {
                var band = repository.Get<Band>(entityToBeDeleted);
                repository.Delete(band);
                Console.WriteLine($"The item {band.Name} has been deleted successfully!");
            }
            reader.ListAllItems<Band>();
            Console.WriteLine();
        }
        private static IRepository GetRepository()
        {
            return new Repository();
        }
    }
}
