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
    public class LoginHelper : HelperBase
    {
        public LoginHelper (IWebDriver driver) 
            : base(driver)
        {
            
        }

        public void Login(AccountData account)
        {
            driver.FindElement(By.ClassName("login")).Click();
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
            driver.FindElement(By.Name("passwd")).SendKeys(account.Password);
            driver.FindElement(By.XPath("//button[@id='SubmitLogin']")).Click();
            string getText = driver.FindElement(By.XPath("//h1")).Text;
            Assert.AreEqual(getText, "MY ACCOUNT");
        }
    }
}
