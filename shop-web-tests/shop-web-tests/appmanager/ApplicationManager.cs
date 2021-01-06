using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ShopWebTests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        private IAlert alert;
        private SelectElement select; // new SelectElement;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;

        protected LoginHelper loginHelper;
        protected NavigationHelper navigator;
        protected AddressHelper addressHelper;

        public ApplicationManager()
        {
            loginHelper = new LoginHelper(driver);
            navigator = new NavigationHelper(driver, baseURL);
            addressHelper = new AddressHelper(driver);
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                //Ignore if unavle to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }

        public AddressHelper AddressHelper
        {
            get
            {
                return addressHelper;
            }
        }
    }
}
