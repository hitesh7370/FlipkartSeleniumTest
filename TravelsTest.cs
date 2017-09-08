using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;

namespace FlipkartTest1
{
    //[TestFixture]
    class TravelsTest
    {
        public String strURL;
        IWebDriver driver;

      // [SetUp]
        public void TestSetup()
        {
            driver = new FirefoxDriver();
            strURL = "http://www.phptravels.net/";
            driver.Navigate().GoToUrl(strURL);
            System.Threading.Thread.Sleep(8000);
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(3000);
        }

      //  [Test]
        public void logoverification()
        {
            IWebElement Logo_PHPTravels = driver.FindElement(By.XPath("//img[@class='logo' and @alt='PHPTRAVELS']"));
            Console.WriteLine("'PHPTravels' logo verification on PHPTravels Home page.");
            
        }


      //  [Test]
        public void menuverification()
        {
            IWebElement Logo_PHPTravels = driver.FindElement(By.XPath("//img[@class='logo' and @alt='PHPTRAVELS']"));
            Console.WriteLine("'PHPTravels' logo verification on PHPTravels Home page.");
        }

      //  [TestFixtureTearDown]        
        public void teardown()
        {
            driver.Quit();
        }
        


    }
}
