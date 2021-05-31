using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace NUnitTestSummatorofNumbers
{
    public class SumatorDataDrivenTests
        
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
        
        //Test valid integer
        [TestCase("15","7","Sum: 22")]
        [TestCase("15", "7", "Sum: 22")]
        [TestCase("", "55", "Sum: invalid input")]
        //Test valid decimal 
        [TestCase("35.5", "7.5", "Sum: 43")]
        [TestCase("11.4", "12.4", "Sum: 23.8")]
        [TestCase("", "55.4", "Sum: invalid input")]

        public void Tests_Summator(string num1,string num2,string expectedresult)
        {
          
            buttonReset.Click();
          
          if(num1!= "")
            {
                firstNumberBox.SendKeys(num1);
            }
            if (num2 != "")
            {
                secondNumberBox.SendKeys(num2);
            }
            buttonCalculate.Click();
            var actualresult = resultField.Text;
            Assert.AreEqual(expectedresult, actualresult);

        }
        
        
        [OneTimeTearDown]

        public void Shutdown()
        {
            driver.Quit();
        }
    }
}
