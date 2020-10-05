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

            bool des = true;
            while (des)
            {
                string pattern = @"[0-9]{10}";
                Regex r = new Regex(pattern);
                Console.WriteLine("Enter phone number: ");
                String phno = Console.ReadLine();

                if (!r.IsMatch(phno))
                {
                    Console.WriteLine("Enter a valid phone number ");
                    des = true;
                }
                else
                {
                    details.Add(phno);
                    des = false;
                }
            }

            bool des2 = true;
            while (des2)
            {

                string pattern = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"
;
                Regex r2 = new Regex(pattern);

                Console.WriteLine("Enter email: ");
                String email = Console.ReadLine();

                if (!r2.IsMatch(email))
                {
                    Console.WriteLine("Enter a valid email");

                }
                else
                {
                    details.Add(email);
                    des2 = false;
                }
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
                    Console.WriteLine("The contact with give name exists, continue to add edit detais....\n");

                    Console.WriteLine("Choose the detail you want to edit:-\n1.First Name\n2.Last Name 3.Address\n4.City\n5.State\n6.PhoneNumber\n7.Email\n8.zip\n ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter First Name: ");
                            con.FirstName = Console.ReadLine();
                            break;
                        case 2:
                            Console.WriteLine("Enter Last Name: ");
                            con.LastName = Console.ReadLine();
                            break;
                        case 3:
                            Console.WriteLine("Enter Address: ");
                            con.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.WriteLine("Enter city: ");
                            con.City = Console.ReadLine();
                            break;
                        case 5:
                            Console.WriteLine("Enter Address: ");
                            con.State = Console.ReadLine();
                            break;
                        
                        case 6:
                            bool des = true;
                            while (des)
                            {
                                string pattern = @"[0-9]{10}";
                                Regex r = new Regex(pattern);
                                Console.WriteLine("Enter phone number: ");
                                String phno = Console.ReadLine();

                                if (!r.IsMatch(phno))
                                {
                                    Console.WriteLine("Enter a valid phone number ");
                                    des = true;
                                }
                                else
                                {
                                    con.PhoneNumber = phno;
                                    des = false;
                                }
                            }
                            break;
                        case 7:
                            bool des2 = true;
                            while (des2)
                            {

                                string pattern = @"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$"
;
                                Regex r2 = new Regex(pattern);

                                Console.WriteLine("Enter email: ");
                                String email = Console.ReadLine();

                                if (!r2.IsMatch(email))
                                {
                                    Console.WriteLine("Enter a valid email");
                                    
                                }
                                else
                                {
                                    con.Email = email;
                                    des2 = false;
                                }
                            }
                            break;
                        case 8:
                            Console.WriteLine("Enter Zip: ");
                            con.Zip = Console.ReadLine();
                            break;

                    }

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


        public bool ViewContacts()
        {
            bool viewed = false;

            foreach(Contact con in contactsList)
            {
                con.ToString();
                viewed = true;
            }

            return viewed;
        }

    }
}
