using System;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem\nChoose one of the option");

            //variables

           
            AddressBook ad = new AddressBook();


            bool b = true;

            while (b)
            {
                Console.WriteLine("\n1.Add contacts\n2.Edit Contact using name\n3.Delete Contact using name\n4.Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\nAdding a new Contact\n");
                        ad.AddContact();
                        break;
                    case 2:
                        Console.WriteLine("Edit Contact Using name\n");
                        Console.WriteLine("Enter First Name: ");
                        String fname = Console.ReadLine();

                        Console.WriteLine("Enter First Name: ");
                        String lname = Console.ReadLine();

                        bool isEdited = ad.EditContact(fname, lname);

                        if (isEdited)
                        {
                            Console.WriteLine("\nDetails Updated SuccessFully!!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nNo contact exits with this name\n");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Delete Contact Using name\n");
                        Console.WriteLine("Enter First Name: ");
                        String fName = Console.ReadLine();

                        Console.WriteLine("Enter First Name: ");
                        String lName = Console.ReadLine();

                        bool isDeleted = ad.DeleteContact(fName, lName);

                        if (isEdited)
                        {
                            Console.WriteLine("\nDetails Updated SuccessFully!!\n");
                        }
                        else
                        {
                            Console.WriteLine("\nNo contact exits with this name\n");
                        }
                        break;
                    default:
                        b = false;
                        break;
                }
            }
        }
    }
}
