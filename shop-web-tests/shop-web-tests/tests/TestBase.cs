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
    public class TestBase
    {
        
        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
            //open home page
            app.Navigator.OpenHomePage();
            //login
            app.Auth.Login(new AccountData("tarby@mail.ru", "123123"));
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }

    }
}
