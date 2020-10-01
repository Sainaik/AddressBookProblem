using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class Contact
    {
        String firstName, lastName, address, city, state, email;
        String zip, phoneNumber;
        public Contact(String firstName, String lastName, String address, String city, String state, string zip, string phoneNumber, String email)
        {

            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;

            Console.WriteLine("Hola!! New Contact is created");
        }
    }
}
