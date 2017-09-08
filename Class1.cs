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
    //[Parallelizable]
    public class FlipKartTest1
    {
        public String strURL;
        IWebDriver driver = new FirefoxDriver();
        IWebElement lnkSignup, lnkLogin, FlipkartLogo;

        //[TestFixtureSetUp]
        [SetUp]
        public void TestSetup()
        {
            strURL = "https://www.flipkart.com/";
            driver.Navigate().GoToUrl(strURL);
            System.Threading.Thread.Sleep(8000);
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(3000);
        }

        public void HomePageElementsVerification()
        {
            System.Threading.Thread.Sleep(4000);

            FlipkartLogo = driver.FindElement(By.XPath("//div/a/img[@alt='Flipkart']"));
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Flipkart Logo verification on Flipkart Home page");

            lnkSignup = driver.FindElement(By.XPath("//a[contains(text(),'Signup')]"));
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Flipkart 'Signup' link verification on Flipkart Home page");

            lnkLogin = driver.FindElement(By.XPath("//a[contains(text(),'Log In')]"));
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Flipkart 'Log In' link verification on Flipkart Home page");

         }

        //[Test]
        
        //public void A_RegisterUser()
        //{
        //    Console.WriteLine("Step 2: Click on Signup link text on Flipkart Home page");

        //    Console.WriteLine("Step 3: Enter");
        //}
        //[Test]
        
        public void B_LoginUser()
        {
            HomePageElementsVerification();
            Console.WriteLine("Step 2: Click on Log In link text on Flipkart Home page");
            lnkLogin.Click();
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Step 3: Click on LogIn button after entering valid 'Email/Mobile Number' and 'Password' on Log In pop up");

            IWebElement txtEmail = driver.FindElement(By.XPath("//input/..//span[contains(text(),'Enter Email/Mobile number')]"));
            txtEmail.SendKeys("deskstark@yahoo.com");
            System.Threading.Thread.Sleep(3000);

            IWebElement txtPassword = driver.FindElement(By.XPath("//input/..//span[contains(text(),'Enter Password')]"));
            System.Threading.Thread.Sleep(2000);
            txtPassword.Click();
            txtPassword.SendKeys("hello_7370");
            System.Threading.Thread.Sleep(3000);

            IWebElement btnLogin = driver.FindElement(By.XPath("//button[@type='submit']/..//span[contains(text(),'Login')]"));
            btnLogin.Click();
            System.Threading.Thread.Sleep(5000);

            string loggedintext = "My Account";
            IWebElement lnkLoggedinuser = driver.FindElement(By.XPath("//a[contains(text(),'" + loggedintext + "')]"));
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("'My Account' LinkedList text verification on Flipkart Home page");

        }

       // [Test]
        public void C_SearchResultsVerification()
        {
            HomePageElementsVerification();
            Console.WriteLine("Step 2: Search for any product, brand or etc and click on Search button");

            IWebElement txtSearchBox = driver.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']"));
            System.Threading.Thread.Sleep(3000);

            string enteredText = "redmi note 4";
            txtSearchBox.SendKeys(enteredText);
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("Entered Text is : " + enteredText);
            txtSearchBox.SendKeys(Keys.Tab);

            IWebElement btnSearch = driver.FindElement(By.XPath("//form[@action='/search']//button"));
            System.Threading.Thread.Sleep(2000);
            btnSearch.Click();
            System.Threading.Thread.Sleep(10000);

            try
            {
                IWebElement lblSearchedProductName = driver.FindElement(By.XPath("//h1//span[6]/..//span[contains(text(),'" + enteredText + "')]"));
                System.Threading.Thread.Sleep(2000);
                IWebElement lblSearchResult = driver.FindElement(By.XPath("//h1//span[6]"));
                string strsearchResults = lblSearchResult.GetAttribute("textContent");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine(strsearchResults + " search results found for entered text " + enteredText);
                System.Threading.Thread.Sleep(2000);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Result not fonund for entered text");
                throw;
            }

        }

       // [Test]
        public void MenuVerification()
        {
            HomePageElementsVerification();
            IList<IWebElement> HeaderMenus = driver.FindElements(By.XPath("//div[@id='container']//header/div[2]/div/ul/li"));
            System.Threading.Thread.Sleep(2000);
            int nHeader = HeaderMenus.Count;
            Console.WriteLine("Total number of header menus :" + nHeader);

            int nSubmenus = 0;
            for (int i = 1; i <= nHeader; i++)
            {
                IWebElement HeaderMenu = driver.FindElement(By.XPath("//div[@id='container']//header/div[2]/div/ul/li[" + i + "]/a"));
                System.Threading.Thread.Sleep(3000);
                string strHeaderMenu = HeaderMenu.GetAttribute("title");
                Console.WriteLine("Test");
                System.Threading.Thread.Sleep(3000);

                Actions action = new Actions(driver);
                action.MoveToElement(HeaderMenu).Perform();
                System.Threading.Thread.Sleep(4000);

                IList<IWebElement> SubMenus = driver.FindElements(By.XPath("//div[@id='container']//header/div[2]/div/ul/li[" + i + "]//a"));
                System.Threading.Thread.Sleep(3000);
                nSubmenus = SubMenus.Count;
                Console.WriteLine("Header Menu : " + strHeaderMenu + "  Number of submenus under " + strHeaderMenu + " are " + nSubmenus);
                System.Threading.Thread.Sleep(4000);
            }

        }


        //[TestFixtureTearDown]
       // [TearDown]
        public void teardown()
        {
            driver.Quit();
        }

    }
    
    //[TestFixture]
    //[Parallelizable]
    //public class FKTest2
    //{
    //    public String strURLn;
    //    IWebDriver drivern = new FirefoxDriver();
    //    IWebElement lnkSignupn, lnkLoginn, FlipkartLogon;

    //    [TestFixtureSetUp]
    //    public void TestSetupN()
    //    {
    //        strURLn = "https://www.flipkart.com/";
    //        drivern.Navigate().GoToUrl(strURLn);
    //        System.Threading.Thread.Sleep(8000);
    //        drivern.Manage().Window.Maximize();
    //        System.Threading.Thread.Sleep(3000);
    //    }
    //    public void HomePageElementsVerification()
    //    {
    //        System.Threading.Thread.Sleep(4000);

    //        FlipkartLogon = drivern.FindElement(By.XPath("//div/a/img[@alt='Flipkart']"));
    //        System.Threading.Thread.Sleep(2000);
    //        Console.WriteLine("Flipkart Logo verification on Flipkart Home page");

    //        lnkSignupn = drivern.FindElement(By.XPath("//a[contains(text(),'Signup')]"));
    //        System.Threading.Thread.Sleep(2000);
    //        Console.WriteLine("Flipkart 'Signup' link verification on Flipkart Home page");

    //        lnkLoginn = drivern.FindElement(By.XPath("//a[contains(text(),'Log In')]"));
    //        System.Threading.Thread.Sleep(2000);
    //        Console.WriteLine("Flipkart 'Log In' link verification on Flipkart Home page");

    //    }
    //    [Test]
    //    public void C_SearchResultsVerification()
    //    {
    //        HomePageElementsVerification();
    //        Console.WriteLine("Step 2: Search for any product, brand or etc and click on Search button");

    //        IWebElement txtSearchBox = drivern.FindElement(By.XPath("//input[@title='Search for Products, Brands and More']"));
    //        System.Threading.Thread.Sleep(3000);

    //        string enteredText = "redmi note 4";
    //        txtSearchBox.SendKeys(enteredText);
    //        System.Threading.Thread.Sleep(3000);
    //        Console.WriteLine("Entered Text is : " + enteredText);
    //        txtSearchBox.SendKeys(Keys.Tab);

    //        IWebElement btnSearch = drivern.FindElement(By.XPath("//form[@action='/search']//button"));
    //        System.Threading.Thread.Sleep(2000);
    //        btnSearch.Click();
    //        System.Threading.Thread.Sleep(10000);

    //        try
    //        {
    //            IWebElement lblSearchedProductName = drivern.FindElement(By.XPath("//h1//span[6]/..//span[contains(text(),'" + enteredText + "')]"));
    //            System.Threading.Thread.Sleep(2000);
    //            IWebElement lblSearchResult = drivern.FindElement(By.XPath("//h1//span[6]"));
    //            string strsearchResults = lblSearchResult.GetAttribute("textContent");
    //            System.Threading.Thread.Sleep(2000);
    //            Console.WriteLine(strsearchResults + " search results found for entered text " + enteredText);
    //            System.Threading.Thread.Sleep(2000);
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Result not fonund for entered text");
    //            throw;
    //        }

    //    }
    //    [TestFixtureTearDown]
    //    public void teardownn()
    //    {
    //        drivern.Quit();
    //    }
    //}
    
}
