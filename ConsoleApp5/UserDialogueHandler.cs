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
        public static long ReadInt(string message, long minValue, long maxValue)
        {
            long userInputLong;
            do
            {
                Console.Write(message);
                long.TryParse(Console.ReadLine(), out userInputLong);

                if (userInputLong > maxValue || userInputLong < minValue)
                {
                    Console.WriteLine($"Invalid input. Enter number between {minValue} and {maxValue}. \n");
                }

            } while (userInputLong > maxValue || userInputLong < minValue);
            return userInputLong;
        }
        public static void ListItemsFromDb(EntityDataDisplayer reader)
        {
            reader.ListAllItems<Band>();
            Console.WriteLine();
        }

        public static void InsertNewItemToDb(IRepository repository)
        {
            Console.Write("Enter band name: ");
            var name = Console.ReadLine();

            var message = "Enter band rating: ";
            var rating = ReadInt(message, 1, 100);

            Console.Write("Enter band genre: ");
            var genreInput = Console.ReadLine();
            Genre genreResult = (Genre)Enum.Parse(typeof(Genre), genreInput);

            var newBand = new Band { Name = name, Rating = rating, GenreEnum = genreResult };
            repository.Insert(newBand);
            Console.WriteLine($"The item {newBand.Name} has been inserted successfully!\n");

        }
        public static void DeleteItemFromDb(EntityDataDisplayer reader, IRepository repository)
        {
            var message = "Choose id of record you want to delete: ";
            var entityToBeDeleted = ReadInt(message, 1, long.MaxValue);

            var bands = repository.GetAll<Band>();

            if (bands.Select(b => b.Id).Contains(entityToBeDeleted) == false)
            {
                Console.WriteLine($"There is no item with id: {entityToBeDeleted}!\n");
            }
            else
            {
                var band = repository.Get<Band>(entityToBeDeleted);
                repository.Delete(band, b => b.IsDeleted = true);
                Console.WriteLine($"The item {band.Name} has been deleted successfully! \n");
            }

        }
        public static void UpdateItemInDb(EntityDataDisplayer reader, IRepository repository)
        {
            var message = "Choose id of record you want to update: ";
            var entityToBeUpdated = ReadInt(message, 1, long.MaxValue);

            var bands = repository.GetAll<Band>();

            if (bands.Select(b => b.Id).Contains(entityToBeUpdated) == false)
            {
                Console.WriteLine($"There is no item with id: {entityToBeUpdated}!");
            }
            else
            {
                var band = repository.Get<Band>(entityToBeUpdated);
                repository.Update(band, b => b.Rating += 1);
                Console.WriteLine($"The item {band.Name} has been updated successfully! \n");
                reader.ListAllItems<Band>();
            }
            Console.WriteLine();

        }

    }
}
