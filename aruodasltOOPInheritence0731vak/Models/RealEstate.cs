using aruodasltOOPInheritence0731vak.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aruodasltOOPInheritence0731vak.Models
{
    internal class RealEstate
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }
        public string Municipality { get; set; }
        public string Settlement { get; set; }
        public string Microdistrict { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public RealEstate()
        {
            this.Driver = DriverClass.Driver;
            this.Wait = DriverClass.Wait;
        }
        public RealEstate(string municipality, string settlement, string microdistrict, string street, string number)
        {
            this.Driver = DriverClass.Driver;
            this.Wait = DriverClass.Wait;
            Municipality = municipality;
            Settlement = settlement;
            Microdistrict = microdistrict;
            Street = street;
            Number = number;
        }

        public void ChooseLocation()
        {
            Console.WriteLine("location choose");
            int pos = 3;
            LocationGeneration(0, 0, this.Municipality);
            Thread.Sleep(1000);
            LocationGeneration(1, 1, this.Settlement);
            try
            {
                LocationGeneration(2, 2, this.Microdistrict);
                Thread.Sleep(1000);
            }
            catch
            {
                pos = 2;
                Console.WriteLine("neradom 3cio");
            }
            LocationGeneration(3, pos, this.Street);

        }

        public void LocationGeneration(int xpath, int pos, string searchText)
        {
            string[] Xpaths = { "//*[@id=\"newObjectForm\"]/ul/li[3]/span[1]/span", "//*[@id=\"district\"]/span", "//*[@id=\"quartalField\"]/span[1]/span[2]", "//*[@id=\"streetField\"]/span[1]/span[2]" };
            Driver.FindElement(By.XPath(Xpaths[xpath])).Click();
            Console.WriteLine(pos);
            IWebElement containerElement = Driver.FindElements(By.ClassName("dropdown-input-values-address"))[pos];

            IList<IWebElement> elements = containerElement.FindElements(By.TagName("li"));



            if (elements.Count > 14)
            {
                containerElement.FindElement(By.TagName("input")).SendKeys(searchText);
                Thread.Sleep(1000);
                containerElement.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }
            else
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    if (elements[i].Text.Contains(searchText))
                    {
                        elements[i].Click();
                        break;
                    }
                }
            }
        }

    }
}
