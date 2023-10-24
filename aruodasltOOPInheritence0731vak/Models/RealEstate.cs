using aruodasltOOPInheritence0731vak.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        public string Area { get; set; }
        public string RCnumber { get; set; }
        public bool CheckRules { get; set; }
        public bool ChatTurnOff { get; set; }
        public bool ContactByEmail { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string Phono { get; set; }
        public string D3Link { get; set; }
        public string Link { get; set; }
        public RealEstate()
        {
            this.Driver = DriverClass.Driver;
            this.Wait = DriverClass.Wait;
        }
        public RealEstate(string municipality, string settlement, string microdistrict, string street, string number, string area, string rCnumber, bool checkRules, bool chatTurnOff, bool contactByEmail, string description, string price, string phono, string d3Link, string link)
        {
            this.Driver = DriverClass.Driver;
            this.Wait = DriverClass.Wait;
            Municipality = municipality;
            Settlement = settlement;
            Microdistrict = microdistrict;
            Street = street;
            Number = number;
            Area = area;
            RCnumber = rCnumber;
            CheckRules = checkRules;
            ChatTurnOff = chatTurnOff;
            ContactByEmail = contactByEmail;
            Description = description;
            Price = price;
            Phono = phono;
            D3Link = d3Link;
            Link = link;
        }
        public void fill()
        {
            ChooseLocation();
            ItemNo();
            ItemArea();
            RC();
            AcceptClikableRules(CheckRules, 3);
            AcceptClikableRules(ChatTurnOff, 4);
            AcceptClikableRules(ContactByEmail, 5);
            ItemDescription();
            ItemPrice();
            PhoNoEntry();
            D3Link();
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
        public void ItemNo()
        {
            Driver.FindElement(By.Name("FHouseNum")).SendKeys(this.Number);
        }
        public void ItemArea()
        {
            Driver.FindElement(By.Id("fieldFAreaOverAll")).SendKeys(Area);
        }

        public void RC()
        {
            Driver.FindElement(By.Name("RCNumber")).SendKeys(this.RCnumber);
        }
        //public void Acceptrules()
        //{
        //    if (CheckRules)
        //    {
        //        IList<IWebElement> lis = Driver.FindElement(By.ClassName("new-object-from")).FindElements(By.TagName("li"));

        //        lis[lis.Count - 5].FindElement(By.ClassName("input-style-checkbox")).FindElement(By.TagName("span")).Click();
        //        lis[lis.Count - 4].FindElement(By.ClassName("input-style-checkbox")).FindElement(By.TagName("span")).Click();
        //        lis[lis.Count - 3].FindElement(By.ClassName("input-style-checkbox")).FindElement(By.TagName("span")).Click();
        //    }
        //}
        //public void TurnOffChat()
        //{

        //    if (ChatTurnOff)
        //    {
        //        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[41]/div/div/div/label/span")).Click();
        //    }
        //}
        public void AcceptClikableRules(bool cb, int no)
        {

            if (cb)
            {
                IList<IWebElement> lis = Driver.FindElement(By.ClassName("new-object-from")).FindElements(By.TagName("li"));
                lis[lis.Count - no].FindElement(By.ClassName("input-style-checkbox")).FindElement(By.TagName("span")).Click();
            }
        }
        public virtual void ItemDescription()
        {
            Driver.FindElement(By.Name("notes_lt")).SendKeys(this.Description);
        }
        public void ItemPrice()
        {
            Driver.FindElement(By.Id("priceField")).SendKeys(this.Price);
        }
        public void PhoNoEntry()
        {
            Driver.FindElement(By.Name("phone")).SendKeys(this.Phono);
        }
        public void D3Link()
        {
            Driver.FindElement(By.Name("tour_3d")).SendKeys(this.D3Link);
        }
        public void YoutubeLink()
        {
            Driver.FindElement(By.Name("Video")).SendKeys(this.Link);
        }
    }
}
