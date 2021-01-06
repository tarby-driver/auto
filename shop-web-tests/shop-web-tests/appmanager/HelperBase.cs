﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace ShopWebTests
{
    public class HelperBase
    {
        protected IWebDriver driver;

        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}