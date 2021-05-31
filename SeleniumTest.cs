using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace NUnitTestSummatorofNumbers
{
    public class GoogleSeleniumTest
        
    {
        IWebDriver driver;
        const string pageUrl = "https://google.com";
        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(pageUrl);
            
        }

        [Test]
        public void 	Automated_Google_Search_For_Selenium()
        {

           
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            driver.SwitchTo().Frame(0);
            var agreeButton = driver.FindElement(By.CssSelector("#introAgreeButton"));
            agreeButton.Click();

            driver.SwitchTo().Window(driver.WindowHandles[0]);
            Thread.Sleep(2000);
            var searchGoogleBox = driver.FindElement(By.CssSelector("input[name = q]"));
            searchGoogleBox.Click();
            searchGoogleBox.SendKeys("selenium");
            searchGoogleBox.SendKeys(Keys.Enter);
            
            var seleniumWebdriverPage = driver.FindElement
                (By.CssSelector("#rso > div > div:nth-child(1) > div > div.yuRUbf > a > h3"));
            seleniumWebdriverPage.Click();
            
            Assert.AreEqual("SeleniumHQ Browser Automation", driver.Title);
            
        }
        [OneTimeTearDown]

        public void Shutdown()
        {
            driver.Quit();
        }
    }
}
