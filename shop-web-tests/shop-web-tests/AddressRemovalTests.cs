﻿using System;
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
            //open home page
            OpenHomePage();
            //login
            Login(new AccountData("tarby@mail.ru", "123123"));
            GoToAddressList();
            DeleteAddress();
        }


        //Assert.AreEqual(getText, "MY ADDRESS");

    }
}

