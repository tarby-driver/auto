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
    public class AddressRemovalTests : TestBase
    {
     
        [Test] //- for NUnit need to write Test
        public void AddressRemovalTest()
        {
            app.Navigator.GoToAddressList();
            app.AddressHelper.DeleteAddress("My Address");
            app.AddressHelper.DeleteAddress("Empty Company");
        }


        //Assert.AreEqual(getText, "MY ADDRESS");

    }
}

