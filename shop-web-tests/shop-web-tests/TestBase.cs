using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ShopWebTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        private IAlert alert;
        private SelectElement select; // new SelectElement;
        private StringBuilder verificationErrors;
        protected string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://automationpractice.com/";
            verificationErrors = new StringBuilder();

        }

        [TearDown]
        public void TeardownTest()
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

        protected void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
        }

        protected void Login(AccountData account)
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
            driver.FindElement(By.Name("passwd")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
            string getText = driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual(getText, "MY ACCOUNT");
        }

        protected void GoToAddressList()
        {
            driver.FindElement(By.ClassName("icon-building")).Click();
            string getText = driver.FindElement(By.ClassName("page-subheading")).Text;

        }

        protected void CreateAdress(AddressData address)
        {
            driver.FindElement(By.XPath("//a[@title='Add an address']")).Click();
            driver.FindElement(By.Id("firstname")).Clear();
            driver.FindElement(By.Id("firstname")).SendKeys(address.FirstName);
            driver.FindElement(By.Id("lastname")).Clear();
            driver.FindElement(By.Id("lastname")).SendKeys(address.LastName);
            driver.FindElement(By.Id("address1")).SendKeys("Address");
            driver.FindElement(By.Id("city")).SendKeys("City");

            SelectElement selectState = new SelectElement(driver.FindElement(By.Id("id_state")));
            selectState.SelectByText(address.DropdownState);

            driver.FindElement(By.Id("postcode")).SendKeys("12345");
            driver.FindElement(By.Id("phone")).SendKeys("12345678");

            driver.FindElement(By.Id("alias")).Clear();
            driver.FindElement(By.Id("alias")).SendKeys("My Address");

            driver.FindElement(By.Id("submitAddress")).Click();

        }

        protected void DeleteAddress()
        {
            driver.FindElement(By.XPath("//h3[text()='My Address']//..//..//a[@title='Delete']")).Click();

            // Switch the control of 'driver' to the Alert from main Window
            IAlert alert = driver.SwitchTo().Alert();
            // '.Text' is used to get the text from the Alert
            string alertText = alert.Text;
            Console.WriteLine("Alert text is " + alertText);
            // '.Accept()' is used to accept the alert '(click on the Ok button)'
            Thread.Sleep(2000);
            alert.Accept();
        }
    }
}
