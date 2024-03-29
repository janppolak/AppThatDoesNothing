﻿using System;
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
            var repository = GetRepository();
            var reader = new EntityDataDisplayer(repository);
            var message = "Choose action:  \n1 - to display all items from the database \n2 - to insert a new record to the database \n3 - to delete item from the database \n4 - to update record in the database \n";

            while (true)
            {
                switch (UserDialogueHandler.ReadInt(message, 1, 4))
                {
                    case 1:
                        UserDialogueHandler.ListItemsFromDb(reader);
                        break;

                    case 2:
                        UserDialogueHandler.InsertNewItemToDb(repository);
                        break;

                    case 3:
                        UserDialogueHandler.DeleteItemFromDb(reader, repository);
                        break;

                    case 4:
                        UserDialogueHandler.UpdateItemInDb(reader, repository);
                        break;
                }
            }
        }
        private static IRepository GetRepository()
        {
            return new Repository();
        }

    }
}
