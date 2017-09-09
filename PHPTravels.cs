using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Threading;


namespace FlipkartTest1
{
    [TestFixture]
    [Parallelizable]
    public class PHPTravelsTest1
    {
        IWebDriver driver; 
     
   //This is Test addition of few lines
        //Line 1
        //Line 2
        
        public string strURL;
        int Stepno;

        [SetUp]
        public void testSetup()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver(@"C:\");
            strURL = "http://phptravels.net/";
            printConsolemsg("Go to URL" + strURL + ".", Stepno);
            driver.Navigate().GoToUrl(strURL);
            Thread.Sleep(7000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            Stepno = 1;
            printConsolemsg("Open Browser.", Stepno);
            


            
        }

        public void printConsolemsg(string msg, int stno)
        {
            Console.WriteLine("Step " + stno + ". " + msg);
            Stepno += 1;

        }

        [Test]
        public void HomePageElementsVerification()
        {
            printConsolemsg("Verify the elements on PHPTravels Home page.", Stepno);

            IWebElement Logo_PHPTravels = driver.FindElement(By.XPath("//img[@class='logo' and @alt='PHPTRAVELS']"));
            Console.WriteLine("'PHPTravels' logo verification on PHPTravels Home page.");

            IList<IWebElement> MenuElements = driver.FindElements(By.XPath("//ul[contains(@class,'navbar-left')]/li[starts-with(@class,'go-right')]/a"));
            for (int i = 1; i <= MenuElements.Count; i++)
            {
                string MenuItem = driver.FindElement(By.XPath("//ul[contains(@class,'navbar-left')]/li[starts-with(@class,'go-right')][" + i + "]/a")).Text;
                Console.WriteLine("'" + MenuItem + "' Menu verification on PHPTravels Home page.");

            }

            IWebElement Ccy_Dropdown = driver.FindElement(By.XPath("//select[@id='currency']"));
            Console.WriteLine("'Currency' dropdown verification on PHPTravels Home page.");

            IList<IWebElement> RHS_Dropdowns = driver.FindElements(By.XPath("//ul[contains(@class,'navbar-right')]/li/a"));
            for (int j = 1; j <= RHS_Dropdowns.Count; j++)
            {
                string RHS_DDL_Name = driver.FindElement(By.XPath("//ul[contains(@class,'navbar-right')]/li[" + j + "]/a")).Text;
                Console.WriteLine("'" + RHS_DDL_Name + "' dropdown verification on PHPTravels Home page.");

            }

        }

        [Test]
        public void SignupwithoutAnyDetails()
        {
            HomePageElementsVerification();

            IWebElement MyAccount_Lnk = driver.FindElement(By.XPath("//a[contains(text(),'My Account')]"));
            Console.WriteLine("'My Account' link verification on PHPTravels Home page.");

            printConsolemsg("Click on the 'My Account' link on PHPTravels Home page.", Stepno);
            MyAccount_Lnk.Click();
            Thread.Sleep(3000);

            IWebElement Signup_Lnk = driver.FindElement(By.XPath("//a[contains(text(),'Sign Up')]"));
            Console.WriteLine("'Sign Up' link verification under 'My Account' link menu on PHPTravels Home page.");
            printConsolemsg("Click on the 'Sign Up' link under 'My Account' link menu on PHPTravels Home page.", Stepno);

            Signup_Lnk.Click();
            Thread.Sleep(3000);

            IWebElement Signup_PageHeader = driver.FindElement(By.XPath("//div[@class='panel-heading'][contains(text(),'Sign Up')]"));
            Console.WriteLine("'Sign Up' header text verification on PHPTravels Sign Up page.");

            IWebElement Signup_btn = driver.FindElement(By.XPath("//button[@type='submit'][contains(text(),'Sign Up')]"));
            Console.WriteLine("'Sign Up' button verification on PHPTravels Sign Up page.");

            printConsolemsg("Click on 'Sign Up' button without entering any details", Stepno);
            Signup_btn.Click();
            Thread.Sleep(4000);

            IList<IWebElement> Signup_ErrMsgs = driver.FindElements(By.XPath("//div[@class='alert alert-danger']/p"));

            for (int i = 1; i <= Signup_ErrMsgs.Count; i++)
            {
                string strSignupErrmsg = driver.FindElement(By.XPath("//div[@class='alert alert-danger']/p[" + i + "]")).Text;
                Console.WriteLine("'" + strSignupErrmsg + "' error text message verification on PHPTravels Sign Up page.");
            }


        }

        [Test]
        public void LoginwithoutAnyDetails()
        {
            HomePageElementsVerification();

            IWebElement MyAccount_Lnk = driver.FindElement(By.XPath("//a[contains(text(),'My Account')]"));
            Console.WriteLine("'My Account' link verification on PHPTravels Home page.");

            printConsolemsg("Click on the 'My Account' link on PHPTravels Home page.", Stepno);
            MyAccount_Lnk.Click();
            Thread.Sleep(3000);

            IWebElement Login_Lnk = driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
            Console.WriteLine("'Login' link verification under 'My Account' link menu on PHPTravels Home page.");
            printConsolemsg("Click on the 'Login' link under 'My Account' link menu on PHPTravels Home page.", Stepno);

            Login_Lnk.Click();
            Thread.Sleep(3000);

            IWebElement Email_Txtbox = driver.FindElement(By.XPath("//input[@type='email']"));
            Console.WriteLine("'Email' textbox verification on PHPTravels Login page.");

            IWebElement Password_Txtbox = driver.FindElement(By.XPath("//input[@type='password']"));
            Console.WriteLine("'Password' textbox verification on PHPTravels Login page.");

            IWebElement Login_btn = driver.FindElement(By.XPath("//button[@type='submit'][contains(@class,'loginbtn')]"));
            Console.WriteLine("'Login' button verification on PHPTravels Login page.");

            printConsolemsg("Click on the 'Login' button without entering any details on PHPTravels Login page.", Stepno);
            Login_btn.Click();
            Thread.Sleep(3000);

            string strLoingErrmsg = driver.FindElement(By.XPath("//div[@class='resultlogin']/div[@class='alert alert-danger']")).Text;
            Console.WriteLine("'" + strLoingErrmsg + "' error text message verification on PHPTravels Login page.");


        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            //printConsolemsg("Browser Close.", Stepno);
            //Thread.Sleep(3000);
        }

    }


    [TestFixture]
    [Parallelizable]
    public class PHPTravelsTest2
    {
        IWebDriver driver;

        public string strURL;
        int Stepno;

        [SetUp]
        public void testSetup()
        {
            //driver = new FirefoxDriver();
            driver = new ChromeDriver(@"C:\");
            strURL = "http://phptravels.net/";
            printConsolemsg("Go to URL" + strURL + ".", Stepno);
            driver.Navigate().GoToUrl(strURL);
            Thread.Sleep(7000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            Stepno = 1;
            printConsolemsg("Open Browser.", Stepno);

        }

        public void printConsolemsg(string msg, int stno)
        {
            Console.WriteLine("Step " + stno + ". " + msg);
            Stepno += 1;

        }

               
        [Test]
        public void LoginwithoutAnyDetails()
        {
            HomePageElementsVerification();

            IWebElement MyAccount_Lnk = driver.FindElement(By.XPath("//a[contains(text(),'My Account')]"));
            Console.WriteLine("'My Account' link verification on PHPTravels Home page.");

            printConsolemsg("Click on the 'My Account' link on PHPTravels Home page.", Stepno);
            MyAccount_Lnk.Click();
            Thread.Sleep(3000);

            IWebElement Login_Lnk = driver.FindElement(By.XPath("//a[contains(text(),'Login')]"));
            Console.WriteLine("'Login' link verification under 'My Account' link menu on PHPTravels Home page.");
            printConsolemsg("Click on the 'Login' link under 'My Account' link menu on PHPTravels Home page.", Stepno);

            Login_Lnk.Click();
            Thread.Sleep(3000);

            IWebElement Email_Txtbox = driver.FindElement(By.XPath("//input[@type='email']"));
            Console.WriteLine("'Email' textbox verification on PHPTravels Login page.");

            IWebElement Password_Txtbox = driver.FindElement(By.XPath("//input[@type='password']"));
            Console.WriteLine("'Password' textbox verification on PHPTravels Login page.");

            IWebElement Login_btn = driver.FindElement(By.XPath("//button[@type='submit'][contains(@class,'loginbtn')]"));
            Console.WriteLine("'Login' button verification on PHPTravels Login page.");

            printConsolemsg("Click on the 'Login' button without entering any details on PHPTravels Login page.", Stepno);
            Login_btn.Click();
            Thread.Sleep(3000);

            string strLoingErrmsg = driver.FindElement(By.XPath("//div[@class='resultlogin']/div[@class='alert alert-danger']")).Text;
            Console.WriteLine("'" + strLoingErrmsg + "' error text message verification on PHPTravels Login page.");


        }
        public void HomePageElementsVerification()
        {
            printConsolemsg("Verify the elements on PHPTravels Home page.", Stepno);

            IWebElement Logo_PHPTravels = driver.FindElement(By.XPath("//img[@class='logo' and @alt='PHPTRAVELS']"));
            Console.WriteLine("'PHPTravels' logo verification on PHPTravels Home page.");

            IList<IWebElement> MenuElements = driver.FindElements(By.XPath("//ul[contains(@class,'navbar-left')]/li[starts-with(@class,'go-right')]/a"));
            for (int i = 1; i <= MenuElements.Count; i++)
            {
                string MenuItem = driver.FindElement(By.XPath("//ul[contains(@class,'navbar-left')]/li[starts-with(@class,'go-right')][" + i + "]/a")).Text;
                Console.WriteLine("'" + MenuItem + "' Menu verification on PHPTravels Home page.");

            }

            IWebElement Ccy_Dropdown = driver.FindElement(By.XPath("//select[@id='currency']"));
            Console.WriteLine("'Currency' dropdown verification on PHPTravels Home page.");

            IList<IWebElement> RHS_Dropdowns = driver.FindElements(By.XPath("//ul[contains(@class,'navbar-right')]/li/a"));
            for (int j = 1; j <= RHS_Dropdowns.Count; j++)
            {
                string RHS_DDL_Name = driver.FindElement(By.XPath("//ul[contains(@class,'navbar-right')]/li[" + j + "]/a")).Text;
                Console.WriteLine("'" + RHS_DDL_Name + "' dropdown verification on PHPTravels Home page.");

            }

        }


        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            //printConsolemsg("Browser Close.", Stepno);
            //Thread.Sleep(3000);
        }

    }





}
