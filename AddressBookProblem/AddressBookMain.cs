using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class AddressBookMain
    {
       static Dictionary<String, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem\nChoose one of the option");

            bool loop1 = true;

            while (loop1)
            {
                Console.WriteLine("\n1.Add AddressBook \n2.View AddressBooks \n3.Exit ");
                int choice1 = 0;
                try
                {
                    choice1 = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid Input!! Try again");

                }
                AddressBook addressBook = new AddressBook();
                string addressBookName = null;
                switch (choice1)
                {
                    case 1:
                        Console.WriteLine("\nAdding a new AddessBook");

                        Console.WriteLine("Enter name for New AddessBook:");

                        addressBookName = Console.ReadLine();

                        bool  isKeyAvailable = false;

                        foreach(KeyValuePair<string,AddressBook> keyValue in addressBookDictionary)
                        {
                            if(keyValue.Key.Equals(addressBookName))
                            {
                                isKeyAvailable = true;
                            }
                        }
                        if(isKeyAvailable)
                        {
                            Console.WriteLine("AddessBook Name is available, try other name\n");
                            break;

                        }
                        
                        bool loop2 = true;

                        while (loop2)
                        {
                            Console.WriteLine("\n1.Add a Contact \n2.View Contact By Name \n3.Edit Contact By name");
                            Console.WriteLine("4.Delete Contact By Name \n5.Exit ");
                            int choice = 0;
                            try
                            {
                                choice = Convert.ToInt32(Console.ReadLine());
                            }
                            catch
                            {
                                Console.WriteLine("Invalid Input!! Try again");

                            }

                            switch (choice)
                            {
                                case 1:
                                    Console.WriteLine("\nAdding a new Contact\n");
                                    addressBook.AddContact();
                                    break;
                                case 2:
                                    addressBook.ViewContact();
                                    break;
                                case 3:
                                    addressBook.EditContact();
                                    break;
                                case 4:
                                    addressBook.DeleteContact();
                                    break;

                                default:
                                    loop2 = false;
                                    break;
                            }
                        }
                        addressBookDictionary.Add(addressBookName, addressBook);
                        break;
                    case 2:
                        Console.WriteLine("Available AddressBooks: ");

                        foreach(KeyValuePair<String,AddressBook> keyValue in addressBookDictionary)
                        {
                            Console.WriteLine("AddressBook Name: " + keyValue.Key);
                        }
                        break;

                        default:
                        loop1 = false;
                        break;
                 
                }
            }
            Console.WriteLine("Thanks for Using the Application!!");

        } 
            
    }
}