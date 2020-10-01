using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AddressBookProblem
{
    class AddressBook
    {
        public List<Contact> contactsList;

        public AddressBook()
        {
            contactsList = new List<Contact>();
        }

        // to fetch Contact details
        private List<string> GetDetails()
        {
            List<String> details = new List<string>();

            Console.WriteLine("Enter First Name: ");
            details.Add(Console.ReadLine());

            Console.WriteLine("Enter Last Name: ");
            details.Add(Console.ReadLine());

            Console.WriteLine("Enter Address: ");
            details.Add(Console.ReadLine());

            Console.WriteLine("Enter city: ");
            details.Add(Console.ReadLine());

            Console.WriteLine("Enter state: ");
            details.Add(Console.ReadLine());

            Console.WriteLine("Enter zip: ");
            details.Add(Console.ReadLine());

            string pattern = @"[0-9]{10}";
            Regex r = new Regex(pattern);

            Console.WriteLine("Enter phone number: ");
            details.Add(Console.ReadLine());

            if (!r.IsMatch(details[6]))
            {
                Console.WriteLine("Enter a valid phone number ");
                System.Environment.Exit(1);
            }

            pattern = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"
;
            Regex r2 = new Regex(pattern);

            Console.WriteLine("Enter email: ");
            details.Add(Console.ReadLine());

            if (!r2.IsMatch(details[7]))
            {
                Console.WriteLine("Enter a valid email");
                System.Environment.Exit(1);
            }

            return details;

        }
        // to Adding contact

        public Contact AddContact()
        {
            List<String> details = GetDetails();

            Contact contact = new Contact(details[0], details[1], details[2], details[3], details[4], details[5], details[6], details[7]);

            contactsList.Add(contact);

            return contact;

        }

        // edit contact
        public bool EditContact(string fname, string lname)
        {
            bool isEdited = false;

            foreach (Contact con in this.contactsList)
            {
                if (con.FirstName.Equals(fname) && con.LastName.Equals(lname))
                {
                    List<String> details = GetDetails();

                    con.FirstName = details[0];
                    con.LastName = details[1];
                    con.Address = details[2];
                    con.City = details[3];
                    con.State = details[4];
                    con.Zip = details[5];
                    con.PhoneNumber = details[6];
                    con.Email = details[7];

                    isEdited = true;
                    break;
                }

            }

            return isEdited;
        }



        public bool DeleteContact(string fname, string lname)
        {
            bool isDeleted = false;

            foreach (Contact con in this.contactsList)
            {
                if (con.FirstName.Equals(fname) && con.LastName.Equals(lname))
                {

                    this.contactsList.Remove(con);
        
                    isDeleted = true;
                    break;
                }

            }

            return isDeleted;
        }

    }
}
