using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{

    class AddressBookMain
    {
        static ValidationContext context;
        static List<ValidationResult> result = new List<ValidationResult>();
        static bool isValid;

        static void Validate(AddressBook addressBook, string fieldName)
        {

            Type userType = addressBook.GetType();

            MethodInfo method = userType.GetMethod("set_" + fieldName);

            string input;

            while (true)
            {
                //getting input from user
                input = Console.ReadLine();

                //invoke the setter method to intialise variables

                method.Invoke(addressBook, new object[] { input });

                isValid = Validator.TryValidateObject(addressBook, context, result, true);

                //valdating the input
                if (!isValid)
                {
                    Console.WriteLine(result[result.Count - 1].ErrorMessage);
                    Console.WriteLine("Please Enter your " + fieldName + " Again!!");
                }
                else
                {
                    break;
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book Problem!");

            AddressBook addressBook = new AddressBook();

            context = new ValidationContext(addressBook, null, null);


            Console.WriteLine("Enter your First Name");
            Validate(addressBook, "FirstName");


            Console.WriteLine("\nEnter your Last Name");
            Validate(addressBook, "LastName");


            Console.WriteLine("\nEnter your Address");
            Validate(addressBook, "Address");

            Console.WriteLine("\nEnter your City");
            Validate(addressBook, "City");

            Console.WriteLine("\nEnter your State");
            Validate(addressBook, "State");

            Console.WriteLine("\nEnter your Email");
            Validate(addressBook, "EmailId");

            Console.WriteLine("\nEnter your Zip");
            Validate(addressBook, "Zip");


            Console.WriteLine("\nEnter your Phone Number");
            Validate(addressBook, "PhoneNumber");



        }
    }
}
