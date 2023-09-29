using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aruodasltOOPInheritence0731vak.Helpers;
using aruodasltOOPInheritence0731vak.Models;
using OpenQA.Selenium.Support.UI;

namespace aruodasltOOPInheritence0731vak.Tests
{
    internal class PlotTests
    {
        public static IWebDriver Driver;

        [Test]
        public void SellPlotListingTest()
        {
            Plot p = new Plot("Vilnius", "Vilniaus", "Antakalnis", "Alantos","15", "50", true, true, true, "863664521", "25000", "1991-0008-5014", "Parduodamas gyvenamosios paskirties sklypas 50a., draugiska kaiminyste, esfaltuotas kelias iki sklypo",
                "https://www.youtube.com/watch?v=AN0lSytPFRo", "https://www.youtube.com/watch?v=jfC71hOeV4A", new int [] { 1, 2, 7, 8, 9 },
                new int[] {1,5,7,9}, "C:\\Users\\Kornelija\\Desktop\\inzinerine_geodezija-274.jpg");
            p.fill();

        }
        [Test]
        public void SellPlotListingTestKaunas()
        {
            Plot p = new Plot("Kaunas", "Kauno", "Aleksotas","Algirdo","15", "50", true, true, true, "863664521", "25000", "1991-0008-5014", "Parduodamas gyvenamosios paskirties sklypas 50a., draugiska kaiminyste, esfaltuotas kelias iki sklypo",
                "https://www.youtube.com/watch?v=AN0lSytPFRo", "https://www.youtube.com/watch?v=jfC71hOeV4A", new int[] { 4,5,6 },
                new int[] { 2,4,6,8}, "C:\\Users\\Kornelija\\Desktop\\inzinerine_geodezija-274.jpg");
            p.fill();

        }
        [Test]
        public void SellPlotListingTestSiauliai()
        {
            Plot p = new Plot("Šiauliai", "Žaliūkių", "Centras", "Aitvarų", "15", "50", true, true, true, "863664521", "25000", "1991-0008-5014", "Parduodamas gyvenamosios paskirties sklypas 50a., draugiska kaiminyste, esfaltuotas kelias iki sklypo",
                "https://www.youtube.com/watch?v=AN0lSytPFRo", "https://www.youtube.com/watch?v=jfC71hOeV4A", new int[] { 4, 5, 6 },
                new int[] { 2, 4, 6, 8 }, "C:\\Users\\Kornelija\\Desktop\\inzinerine_geodezija-274.jpg");
            p.fill();

        }
       
        [OneTimeSetUp]
        public void Initialize()
        {
            if (DriverClass.Driver is not null)
            {
                return;
            }
            DriverClass.Driver = new ChromeDriver();
            DriverClass.Wait = new WebDriverWait(DriverClass.Driver, TimeSpan.FromSeconds(5));

            Driver = DriverClass.Driver;
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            Driver.Manage().Window.Maximize();
            AcceptCookies();
            Login();
        }

        [OneTimeTearDown]

        public void Cleanup()
        {
            // driver.Quit();
        }

        public void AcceptCookies()
        {
            Driver.Navigate().GoToUrl("https://www.aruodas.lt/");
            Driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
        }
        public void Login()
        {
            Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div[2]/div[1]/div[1]/div/div[2]/div")).Click();
            Driver.FindElement(By.Id("userName")).SendKeys("cylikaite.k@gmail.com");
            Driver.FindElement(By.Id("password")).SendKeys("paprastas");
            Driver.FindElement(By.Id("loginAruodas")).Click();

        }
    }

}
