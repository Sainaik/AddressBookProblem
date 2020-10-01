using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProblem
{
    class AddressBook
    {
        public AddressBook(String firstName, String lastName, String address, String city, String state, string zip, string phoneNumber, String email)
        {
            Contact add = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
        }
    }
}
