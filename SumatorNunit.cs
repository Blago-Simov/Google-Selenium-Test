using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestSummatorofNumbers
{
    public class Sumatortests 
    {
        IWebDriver driver;
        const string pageUrl = "https://sum-numbers.blagosimov.repl.co/";
        IWebElement buttonReset;
        IWebElement firstNumberBox;
        IWebElement secondNumberBox;
        IWebElement buttonCalculate;
        IWebElement resultField;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(pageUrl);
            buttonReset = driver.FindElement(By.CssSelector("#resetButton"));
            firstNumberBox = driver.FindElement(By.CssSelector("input#number1"));
            secondNumberBox = driver.FindElement(By.CssSelector("input#number2"));
            buttonCalculate = driver.FindElement(By.CssSelector("#calcButton"));
            resultField = driver.FindElement(By.CssSelector("#result"));
        }
        

        [Test]
        public void Test_Add_TwoNumbers_Valid()
        {
          
            buttonReset.Click();
          
            firstNumberBox.SendKeys("15");
         
            secondNumberBox.SendKeys("7");
          
            buttonCalculate.Click();
          
            Assert.AreEqual("Sum: 22", resultField.Text);

        }
        [Test]
        public void Test_Add_TwoNumbers_Invalid()
        {
           
            buttonReset.Click();
           
            firstNumberBox.SendKeys("");
           
            secondNumberBox.SendKeys("7");
           
            buttonCalculate.Click();
           
            Assert.AreEqual("Sum: invalid input", resultField.Text);

        }
        [Test]
        public void Test_Add_TwoNumbers_ResetButton()
        {
            
            firstNumberBox.SendKeys("44");

            Assert.IsNotNull(firstNumberBox);
           
            secondNumberBox.SendKeys("55");

            Assert.IsNotNull(secondNumberBox);
          
            buttonCalculate.Click();
           
            buttonReset.Click();
            Assert.AreSame("",firstNumberBox.Text);
            Assert.AreSame("",secondNumberBox.Text);

        }

        
        [OneTimeTearDown]

        public void Shutdown()
        {
            driver.Quit();
        }
    }
}
