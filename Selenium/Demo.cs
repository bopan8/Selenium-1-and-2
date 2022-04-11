using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Selenium
{
    class Demo
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void test()
        {
            driver.Url = "https://www.bing.com/"; 
            driver.Manage().Window.Maximize();
            var el = driver.FindElement(By.Id("sb_form_q"));
            el.SendKeys("Facebook");
            el.SendKeys(Keys.Return);

            Assert.AreEqual("Facebook - Search", driver.Title);

            driver.FindElement(By.LinkText("Facebook - Log In or Sign Up")).Click();
            var listOfElements = driver.FindElement(By.XPath("//*[@data-cookiebanner=\"accept_button\"]"));
            listOfElements.Click();

            WebElement email = (WebElement)driver.FindElement(By.Id("email"));
            email.SendKeys("hello@gmail.com");
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
