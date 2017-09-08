using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;

namespace FlipkartTest1
{
    [TestFixture]
    [Parallelizable]
    class AmazonTcs
    {

        public String strURL;
        //IWebDriver driver = new FirefoxDriver();
        IWebDriver driver; 
        //IWebElement lnkSignup, lnkLogin, FlipkartLogo;
        

        
        [SetUp]
        public void TestSetup()
        {
            driver = new ChromeDriver(@"C:\");
            strURL = "http://www.amazon.in/";
            driver.Navigate().GoToUrl(strURL);
            System.Threading.Thread.Sleep(8000);
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(3000);
        }


       [Test]
        public void verifyLogo()
        {
            IWebElement Amazonlogo = driver.FindElement(By.XPath("//div[@id='nav-logo']"));
            Console.WriteLine("Amazon logo verifiaction in Amazon Home page.");

        }


        [Test]
        public void MenuVerification()
        {
            IWebElement Amazonlogo = driver.FindElement(By.XPath("//a[@id='nav-your-amazon']"));
            Console.WriteLine("'Yor Amazon.in' link verifiaction in Amazon Home page.");

        }


       [TearDown]
        public void teardown()
        {
            driver.Quit();
        }

    }
}
