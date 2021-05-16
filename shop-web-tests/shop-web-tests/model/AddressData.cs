using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopWebTests
{
    public class AddressData
    {
        private string firstName;
        private string lastName;
        private string dropdownState;
        private string alias;
        private string company;


        public AddressData(string firstName)
        {
            this.firstName = firstName;
        }

        public AddressData(string firstName, string lastName, string dropdownState, string alias, string company)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dropdownState = dropdownState;
            this.alias = alias;
            this.company = company;
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

        public string Alias
        {
            get
            {
                return alias;
            }
            set
            {
                alias = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
    }
}
