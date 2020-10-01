using System;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem\n Enter the details of the contact");

            //variables

            String firstName, lastName, address, city, state, email;
            String zip, phoneNumber;

            Console.WriteLine("Enter First Name: ");
            firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            lastName = Console.ReadLine();

            Console.WriteLine("Enter Address: ");
            address = Console.ReadLine();

            Console.WriteLine("Enter city: ");
            city = Console.ReadLine();

            Console.WriteLine("Enter state: ");
            state = Console.ReadLine();

            Console.WriteLine("Enter zip: ");
            zip = Console.ReadLine();



            string pattern = @"[0-9]{10}";
            Regex r = new Regex(pattern);

            Console.WriteLine("Enter phone number: ");
            phoneNumber = Console.ReadLine();

            if (!r.IsMatch(phoneNumber))
            {
                Console.WriteLine("Enter a valid phone number ");
                System.Environment.Exit(1);
            }

            pattern = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"
;
            Regex r2 = new Regex(pattern);

            Console.WriteLine("Enter email: ");
            email = Console.ReadLine();

            if (!r2.IsMatch(email))
            {
                Console.WriteLine("Enter a valid email");
                System.Environment.Exit(1);
            }

            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
        }
    }
}
