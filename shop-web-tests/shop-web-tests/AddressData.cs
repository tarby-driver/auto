using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebTests
{
    class AddressData
    {
        private string firstName;
        private string lastName;
        private string dropdownState;

        public AddressData(string firstName)
        {
            this.firstName = firstName;
        }

        public AddressData(string firstName, string lastName, string dropdownState)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dropdownState = dropdownState; 
        }
        
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return firstName;
            }
            set
            {
                lastName = value;
            }
        }

        public string DropdownState
        {
            get
            {
                return dropdownState;
            }
            set
            {
                dropdownState = value;
            }
        }
    }
}
