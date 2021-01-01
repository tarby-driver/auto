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
    //[TestClass] - for NUnit need to write TestFixture
    [TestFixture]
    public class AdressCreationTests
    {
        private IWebDriver driver;
        private IAlert alert;
        private SelectElement select; // new SelectElement;
        private StringBuilder verificationErrors;
        private string baseURL;
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

        [Test] //- for NUnit need to write Test
        public void AdressCreationTest()
        {
            //open home page
            OpenHomePage();
            //login
            Login(new AccountData("tarby@mail.ru", "123123"));
            GoToAddressList();
            DeleteAddress();
            //go to adress create
            //CreateAdress(new AddressData("First Name", "Last Name", "Florida"));
            AddressData address = new AddressData("First Name");
            address.LastName = "Last Name";
            address.DropdownState = "Florida";
            //create new adress
            //return to adress page
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
        }


        private void Login(AccountData account)
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
            driver.FindElement(By.Name("passwd")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
            string getText = driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual(getText, "MY ACCOUNT");
        }

        private void CreateAdress(AddressData address)
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

        private void DeleteAddress()
        {
            driver.FindElement(By.XPath("//h3[text()='My Address']//..//..//a[@title='Delete']")).Click();

            // Switch the control of 'driver' to the Alert from main Window
            IAlert alert = driver.SwitchTo().Alert();
            // '.Text' is used to get the text from the Alert
            string alertText = alert.Text;
            Console.WriteLine("Alert text is " + alertText);
            // '.Accept()' is used to accept the alert '(click on the Ok button)'

            alert.Accept();
        }

        private void GoToAddressList()
        {
            driver.FindElement(By.ClassName("icon-building")).Click();
            string getText = driver.FindElement(By.ClassName("page-subheading")).Text;

        }

        //Assert.AreEqual(getText, "MY ADDRESS");

    }
}

