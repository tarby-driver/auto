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
            Login();
            //go to adress create
            CreateAdress();
            //create new adress
            //return to adress page
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/index.php");
        }


        private void Login()
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Name("email")).SendKeys("tarby@mail.ru");
            driver.FindElement(By.Name("passwd")).SendKeys("123123");
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
            string getText = driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual(getText, "MY ACCOUNT");
        }

        private void CreateAdress()
        {
            driver.FindElement(By.ClassName("icon-building")).Click();
            string getText = driver.FindElement(By.ClassName("page-subheading")).Text;
            driver.FindElement(By.XPath("//h3[text()='My address']//..//..//a[@title='Delete']")).Click();

            //Assert.AreEqual(getText, "MY ADDRESS");

        }
    }
}
