using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string Email { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }

        public Contact(String firstName, String lastName, String address, String city, String state, string zip, string phoneNumber, String email)
        {

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.Zip = zip;
            this.PhoneNumber = phoneNumber;
            this.Email = email;

            Console.WriteLine("Hola! New Contact is created\n ");
        }

        public void ToString()
        {
            Console.WriteLine("Name: " + this.FirstName + " " + this.LastName + "\nAddress: " + this.Address + " " + this.City + " " + this.State+"\n");
        }
    }
}