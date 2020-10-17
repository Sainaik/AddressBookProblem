using System;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class AddressBookProblem
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem\nChoose one of the option");

            //variables


            AddressBook ad = new AddressBook();


            bool choice1 = true;

            while (choice1)
            {
                Console.WriteLine("\n1.Add Contact \n2.View Contact By Name \n3.Edit Contact By name \n4.Exit");
                Console.WriteLine("\n5.Exit");

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
                        ad.AddContact();
                        break;
                    case 2:
                        ad.ViewContact();
                        break;
                    case 3:
                        ad.EditContact();
                        break;
                    default:
                        choice1 = false;
                        break;
                }
            }

            Console.WriteLine("Thanks for Using the Application!!");
        }
    }
}
