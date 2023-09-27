using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V114.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aruodasltOOPInheritence0731vak.Models
{
    internal class Garage : RealEstate
    {
        public string Area { get; set; }
        public string Municipality { get; set; }
        public string Settlement { get; set; }
        public string Microdistrict { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }

        public bool CheckRules { get; set; }
        public bool ContactByEmail { get; set; }
        public bool ChatTurnOff { get; set; }
        public string Phono { get; set; }
        public string Price { get; set; }
        public string RCnumber { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Ddd { get; set; }
        public string ClickType { get; set; }



        public Garage( string municipality, string settlement,string microdistrict,string street,string number, string area, bool checkRules,bool contactByEmail, bool chatTurnOff, string phono, string price, string rcnumber, string description, string link, string ddd, string clickType) : base()
        {
            Municipality = municipality;
            Settlement = settlement;
            Area = area;
            CheckRules = true;
            ContactByEmail = true;
            ChatTurnOff = true;
            Phono = phono;
            Price = price;
            RCnumber = rcnumber;
            Description = description;
            Link = link;
            Microdistrict = microdistrict;
            Street = street;
            Number = number;
            ClickType = clickType;
            Ddd = ddd;
          
        }

        public void fill()
        {
            Driver.Navigate().GoToUrl("https://www.aruodas.lt/ideti-skelbima/?obj=13&offer_type=1");
            ChooseLocation();
            GarageNo();
            Acceptrules();
            TurnOffFunctions();
            Phonoentry();
            GaragePrice();
            RC();
            GarageDescription();
            YoutubeLink();
            DddLInk();
            Photo();
            Type();
     
            Driver.FindElement(By.Id("fieldFAreaOverAll")).SendKeys(Area);
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
      
        public void ChooseLocation()
        {
            int pos = 3;
            LocationGeneration( 0,0, this.Municipality);
            Thread.Sleep(1000);
            LocationGeneration( 1,1, this.Settlement);
            try
            {
                LocationGeneration(2, 2, this.Microdistrict);
                Thread.Sleep(1000);
            }
            catch {pos = 2;
                Console.WriteLine("neradom 3cio");
            }
            LocationGeneration( 3,pos, this.Street);

        }
        public void GarageNo()
        {
            Driver.FindElement(By.Name("FHouseNum")).SendKeys(this.Number);
        }
        public void Acceptrules()
        {
            if (CheckRules) {
                Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[42]/span[1]/div/div/label/span")).Click();
            }
        }
        public void TurnOffFunctions()
        {
            TurnOffChat();
            TurnOffEmail();
        }
        public void TurnOffChat()
        {
            
            if (ChatTurnOff)
            {
                Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[41]/div/div/div/label/span")).Click();
            }
        }

        public void TurnOffEmail()
        {
            if (ContactByEmail)
            {
                Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[40]/div/div/div/label/span")).Click();
            }
        }
        public void Phonoentry()
        {
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[38]/span[1]/input")).SendKeys(this.Phono);
        }
        public void GaragePrice()
        {
            Driver.FindElement(By.Id("priceField")).SendKeys(this.Price);
        }
        public void ChoosePurpose1()
        {
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[1]/label/span")).Click();
        }
        public void RC()
        {
            Driver.FindElement(By.Name("RCNumber")).SendKeys(this.RCnumber);
        }
        public void GarageDescription()
        {
            Driver.FindElement(By.Name("notes_lt")).SendKeys(this.Description);
        }
        public void YoutubeLink()
        {
            Driver.FindElement(By.Name("Video")).SendKeys(this.Link);
        }
        public void DddLInk()
        {
            Driver.FindElement(By.Name("tour_3d")).SendKeys(this.Ddd);
        }
        public void Photo()
        {
            IWebElement chooseFile = Driver.FindElement(By.XPath("//*[@id=\"uploadPhotoBtn\"]/input"));
            //chooseFile.Click();
            chooseFile.SendKeys("C:\\Users\\Kornelija\\Desktop\\2-leonardas-sip-garazas.jpg");
        }
        public void Type()
        {
            Console.WriteLine("type " + ClickType.Length);
           
                switch (ClickType)
                {
                case "Mūrinis":
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[1]/div[2]")).Click();
                        break;
                case "Geležinis":
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[2]/div[2]")).Click();
                        break;
                case "Požeminis":
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[3]/div[2]")).Click();
                        break;
                case "Daugiaaukštis":
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[4]/div[2]")).Click();
                        break;
                case "Kita":
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[5]/div[2]")).Click();
                        break;
                }
           

        }
    }
}
