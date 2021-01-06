using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.Firefox;
//using OpenQA.Selenium.Support.UI;


namespace ShopWebTests
{
    //[TestClass] - for NUnit need to write TestFixture
    [TestFixture]
    public class AddressCreationTests : TestBase
    {
    
        [Test] //- for NUnit need to write Test
        public void AdressCreationTest()
        {
            //open home page
            app.Navigator.OpenHomePage();
            //login
            app.Auth.Login(new AccountData("tarby@mail.ru", "123123"));
            app.Navigator.GoToAddressList();
            //create new adress
            //CreateAdress(new AddressData("First Name", "Last Name", "Florida"));
            AddressData address = new AddressData("First Name");
            address.LastName = "Last Name";
            address.DropdownState = "Florida";
            app.AddressHelper.CreateAdress(address);
            //return to adress page
        }

       //Assert.AreEqual(getText, "MY ADDRESS");

    }
}

