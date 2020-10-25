using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AddressBookProblem
{
    class AddressBookMain
    {
        static Dictionary<String, AddressBook> addressBookDictionary = new Dictionary<string, AddressBook>();
        static List<AddressBook> addressBooksList = new List<AddressBook>();


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem\nChoose one of the option");

            bool loop1 = true;

            while (loop1)
            {
                Console.WriteLine("\n1.Add AddressBook \n2.View AddressBooks");
                Console.WriteLine("3.Searching Contact by City or State\n4.Add AdrdressBook to the IO File\n5.Read AdrdressBook from the IO File ");
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

                        bool isKeyAvailable = false;

                        foreach (KeyValuePair<string, AddressBook> keyValue in addressBookDictionary)
                        {
                            if (keyValue.Key.Equals(addressBookName))
                            {
                                isKeyAvailable = true;
                            }
                        }
                        if (isKeyAvailable)
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
                        addressBooksList.Add(addressBook);

                        break;
                    case 2:
                        Console.WriteLine("Available AddressBooks: ");

                        foreach (KeyValuePair<String, AddressBook> keyValue in addressBookDictionary)
                        {
                            Console.WriteLine("AddressBook Name: " + keyValue.Key);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Your Searching Contact by City or State");
                        AddressBookMain.ContactsByCityOrState();
                        break;
                    case 4:
                        Console.WriteLine("Adding AddressBook into IO File");

                        AddressBookMain.AddAddressBookToFileIO();
                        break;
                    case 5:
                        Console.WriteLine("Read AddressBook from IO File");

                        AddressBookMain.ReadAddressBookToFileIO();
                        break;

                    default:
                        loop1 = false;
                        break;



                }
            }
            Console.WriteLine("Thanks for Using the Application!!");

        }


        static void ContactsByCityOrState()
        {

            Console.WriteLine("\n1.Select by city \n2.Select by State");

            int choice3 = 0;

            try
            {
                choice3 = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Input!! Try again");

            }


            if (choice3 == 1)
            {
                int count = 0;
                Console.WriteLine("Your Searching Contact by City");
                Console.WriteLine("Enter the City");
                string city = Console.ReadLine();

                foreach (AddressBook addressBook in addressBooksList)
                {
                    foreach (Contact contact in addressBook.contactsList)
                    {
                        if (contact.City.Equals(city))
                        {
                            count++;
                            Console.WriteLine("Name : " + contact.FirstName + " City: " + contact.City);
                        }
                    }
                }

                Console.WriteLine($"No of Contacts in the City: {city} are {count}");

            }
            else
            {
                Console.WriteLine("Your Searching Contact by State");
                Console.WriteLine("Enter the State");
                string state = Console.ReadLine();
                int count = 0;
                foreach (AddressBook addressBook in addressBooksList)
                {
                    foreach (Contact contact in addressBook.contactsList)
                    {
                        if (contact.State.Equals(state))
                        {
                            count++;
                            Console.WriteLine("Name : " + contact.FirstName + " " + contact.LastName + " City: " + contact.City);
                        }
                    }
                }
                Console.WriteLine($"No of Contacts in the State: {state} are {count}");

            }
        }


        public static void AddAddressBookToFileIO()
        {

            Console.WriteLine("Adding AddressBook to A File");
            bool isWriten = false;
            string path = @"C:\Users\saiku\source\repos\AddressBookProblem\AddressBookContacts\";
            bool exit = false;
            while (isWriten == false && exit == false)
            {
                Console.WriteLine("Enter the AddressBook Name");
                string addressBookName = Console.ReadLine();

                foreach (KeyValuePair<string, AddressBook> addressBookdict in addressBookDictionary)
                {
                    if (addressBookdict.Key.Equals(addressBookName))
                    {
                        path += addressBookName + ".txt";
                        Console.WriteLine($"File path :{path}");
                        FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(fileStream, addressBookdict.Value);
                        Console.WriteLine($"AddressBook {addressBookName} is added successfully to the File");
                        fileStream.Close();
                        isWriten = true;
                    }
                }

                if (isWriten == false)
                {
                    Console.WriteLine("Invalid AddressBook Name! Try again!!");
                    Console.WriteLine("Enter 'yes' or 'y' to exit");
                    string exitt = Console.ReadLine();
                    if (exitt.Equals("yes") || exitt.Equals("y"))
                    {
                        exit = true;
                    }
                }


            }
        }


        public static void ReadAddressBookToFileIO()
        {

            Console.WriteLine("Your reading AddressBook from A File");
            bool isRead = false;
            string path = @"C:\Users\saiku\source\repos\AddressBookProblem\AddressBookContacts\";
            bool exit = false;
            while (isRead == false && exit == false)
            {
                Console.WriteLine("Enter the AddressBook Name");
                string addressBookName = Console.ReadLine();
                path += addressBookName + ".txt";
                Console.WriteLine($"File path :{path}");

                if (File.Exists(path))
                {
                    FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    AddressBook addressBook = (AddressBook)binaryFormatter.Deserialize(fileStream);
                    Console.WriteLine("AddressBook contacts can be viewed");
                    addressBook.ViewContact();

                    fileStream.Close();
                    isRead = true;
                }


                if (isRead == false)
                {
                    Console.WriteLine("Invalid AddressBook Name! Try again!!");
                    Console.WriteLine("Enter 'yes' or 'y' to exit");
                    string exitt = Console.ReadLine();
                    if (exitt.Equals("yes") || exitt.Equals("y"))
                    {
                        exit = true;
                    }
                }
            }


        }
    }




}
