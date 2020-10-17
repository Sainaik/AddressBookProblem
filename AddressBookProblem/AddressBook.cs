using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class AddressBook
    {
        static ValidationContext context;
        static List<ValidationResult> result = new List<ValidationResult>();
        static bool isValid;

        public List<Contact> contactsList;

        public AddressBook()
        {
            contactsList = new List<Contact>();
        }


        static void Validate(Contact contact, string fieldName)
        {

            Type userType = contact.GetType();

            MethodInfo method = userType.GetMethod("set_" + fieldName);

            string input;

            while (true)
            {
                //getting input from user
                input = Console.ReadLine();

                //invoke the setter method to intialise variables

                method.Invoke(contact, new object[] { input });

                isValid = Validator.TryValidateObject(contact, context, result, true);

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

        // to fetch Contact details

        private Contact GetDetails()
        {
            Contact contact = new Contact();

            context = new ValidationContext(contact, null, null);

            Console.WriteLine("Enter your First Name");
            Validate(contact, "FirstName");


            Console.WriteLine("\nEnter your Last Name");
            Validate(contact, "LastName");


            Console.WriteLine("\nEnter your Address");
            Validate(contact, "Address");

            Console.WriteLine("\nEnter your City");
            Validate(contact, "City");

            Console.WriteLine("\nEnter your State");
            Validate(contact, "State");

            Console.WriteLine("\nEnter your Zip");
            Validate(contact, "Zip");

            Console.WriteLine("\nEnter your EmailId");
            Validate(contact, "EmailId");


            Console.WriteLine("\nEnter your Phone Number");
            Validate(contact, "PhoneNumber");

            return contact;
        }

        // to Adding contact

        public void AddContact()
        {
            Contact contact = GetDetails();

            contactsList.Add(contact);

        }

        // edit contact
        public void EditContact()
        {
            Console.WriteLine("Enter First Name: ");
            String firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            String lastName = Console.ReadLine();

            bool isEdited = false;

            foreach (Contact contact in this.contactsList)
            {
                if (contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
                {
                    Console.WriteLine("Select the detail to be Edited");
                    Console.WriteLine("1.First Name");
                    Console.WriteLine("2.Last Name");
                    Console.WriteLine("3.Address");
                    Console.WriteLine("4.City");
                    Console.WriteLine("5.State");
                    Console.WriteLine("6.Zip");
                    Console.WriteLine("7.Email ID");
                    Console.WriteLine("8.Phone Number");


                    while (true)
                    {
                        int choice;
                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine());

                            switch (choice)
                            {
                                case 1:
                                    Validate(contact, "FirstName");
                                    break;
                                case 2:
                                    Validate(contact, "LastName");
                                    break;
                                case 3:
                                    Validate(contact, "Address");
                                    break;
                                case 4:
                                    Validate(contact, "City");
                                    break;
                                case 5:
                                    Validate(contact, "State");
                                    break;
                                case 6:
                                    Validate(contact, "Zip");
                                    break;
                                case 7:
                                    Validate(contact, "EmailId");
                                    break;
                                case 8:
                                    Validate(contact, "PhoneNumber");
                                    break;
                                default:
                                    break;


                            }

                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Invalid Input..Enter a digit");
                        }

                    }

                    isEdited = true;
                }

            }
            if (isEdited)
            {
                Console.WriteLine("\nDetails Updated SuccessFully!!\n");
            }
            else
            {
                Console.WriteLine("\nNo contact exits with this name\n");
            }

            
        }


        public void ViewContact()
        {
            Console.WriteLine("Enter First Name: ");
            String firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name: ");
            String lastName = Console.ReadLine();

            bool isShown = false;

            foreach (Contact contact in this.contactsList)
            {
                if (contact.FirstName.Equals(firstName) && contact.LastName.Equals(lastName))
                {
                    contact.ShowDetails();
                    isShown = true;
                    break;
                }
            }

            if (isShown == false )
            {
                Console.WriteLine("\nNo contact exits with this name\n");
            }
        }
    }
}
