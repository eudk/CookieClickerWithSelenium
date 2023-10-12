using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Edge;

namespace CookieClickerWithSelenium
{
    
    [TestClass]
    public class UnitTest1
    {
        private static readonly string
            DriverDirectory =
                "C:\\webdrivers"; // change this to your own directory where you have the webdrivers for chrome, firefox and edge

        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            // _driver = new ChromeDriver(DriverDirectory);
            _driver = new FirefoxDriver(DriverDirectory); // firefox driver
            // _driver = new EdgeDriver(DriverDirectory); 
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose(); // close the browser after the test
        }

        [TestMethod]
        public void TestMethod1()
        {

            _driver.Navigate().GoToUrl("https://orteil.dashnet.org/cookieclicker/"); // go to cookie clicker website
            IWebElement buttonElement = _driver.FindElement(By.CssSelector(".fc-button.fc-cta-consent.fc-primary-button")); //consents to cookies
            buttonElement.Click();

            var buttonElement2 = _driver.FindElement(By.Id("langSelect-EN")); //selects english
            buttonElement2.Click();



            // Wait for 5 seconds
            System.Threading.Thread.Sleep(5000);
            // Then find the button and click it 10000 times
            var buttonElement3 = _driver.FindElement(By.Id("bigCookie"));
            for (int i = 0; i < 10000; i++)
            {
                buttonElement3.Click(); // click the cookie button
            }



        }
    }
}