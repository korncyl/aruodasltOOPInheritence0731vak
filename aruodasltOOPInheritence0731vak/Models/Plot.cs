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
    internal class Plot : RealEstate
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
        public int[] CheckBoxes { get; set; }
        public int[] AdditionalFeatures { get; set; }

        public Plot( string municipality, string settlement,string microdistrict,string street,string number, string area, bool checkRules,bool contactByEmail, bool chatTurnOff, string phono, string price, string rcnumber, string description, string link, string ddd, int[] checkBoxes, int[] additionalFeatures) : base()
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
            CheckBoxes = checkBoxes;
            Ddd = ddd;
            AdditionalFeatures = additionalFeatures;
        }

        public void fill()
        {
            Driver.Navigate().GoToUrl("https://www.aruodas.lt/ideti-skelbima/?obj=11&offer_type=1");
            ChooseLocationKaunas();
            PlotNo();
            Acceptrules();
            TurnOffFunctions();
            Phonoentry();
            PlotPrice();
            ChoosePurpose();
            ChooseAddFeatures();
            RC();
            PLotDescription();
            YoutubeLink();
            DddLInk();
            Photo();
     
            Driver.FindElement(By.Id("fieldFAreaOverAll")).SendKeys(Area);
        }

      
        public void ChooseLocation()
        {

            //Driver.Navigate().GoToUrl("https://www.aruodas.lt/ideti-skelbima/?obj=11&offer_type=1");
            ////*[@id="regionDropdown"]/li[1]/input
            ///Vilnius
            ///Savivaldybe
            int municipalitycount = Driver.FindElement(By.Id("regionDropdown")).FindElements(By.TagName("li")).Count;
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            int settlementcount = Driver.FindElement(By.Id("districts_461")).FindElements(By.TagName("li")).Count;
            int microdistrictcount = Driver.FindElement(By.Id("quartals_1")).FindElements(By.TagName("li")).Count;
            int streetcount = Driver.FindElement(By.Id("streets_1")).FindElements(By.TagName("li")).Count;

            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[3]/span[1]/input[2]")).Click();
            Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(this.Municipality);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"regionDropdown\"]/li[" + (municipalitycount + 1) + "]"))).Click();
                ////*[@id="regionDropdown"]/li[62]

          //  Thread.Sleep(2000);
          //  Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(Keys.Enter);
          //GYvenviete
            Driver.FindElement(By.Id("districtTitle")).Click();

            Driver.FindElement(By.XPath("//*[@id=\"districts_461\"]/li[1]/input")).SendKeys(this.Settlement);
            // Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"districts_461\"]/li[" + (settlementcount + 1) + "]"))).Click();

            // Mikrorajonas
            //                          //*[@id="quartalField"]/span[1]/span[2]
            Driver.FindElement(By.XPath("//*[@id=\"quartalField\"]/span[1]/span[2]")).Click();
            /// su Kaunu mikrorajono laukelis 4,[3] "dropdown-input-search-value".!!!!
            Driver.FindElements(By.ClassName("dropdown-input-search-value"))[2].SendKeys(this.Microdistrict);
//            Driver.FindElement(By.Id("quartalTitle")).SendKeys(this.Microdistrict);
            //  Thread.Sleep(2000);
            ////*[@id="quartals_1"]/li[1]/input
            //                                                    //*[@id="quartals_1"]/li[3]
            Console.WriteLine("//*[@id=\"quartals_1\"]/li["+ (microdistrictcount + 1)+ "]");
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"quartals_1\"]/li["+ (microdistrictcount + 1)+ "]"))).Click();

            //Gatve
            Driver.FindElement(By.XPath("//*[@id=\"streetField\"]/span[1]/span[2]")).Click();
            Driver.FindElements(By.ClassName("dropdown-input-search-value"))[5].SendKeys(this.Street);
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"streets_1\"]/li[" + (streetcount + 1) +"]"))).Click();


            ////*[@id="districts_461"]/li[88]
            //Thread.Sleep(10);
            //Driver.FindElement(By.XPath("//*[@id=\"districts_461\"]/li[1]/input")).SendKeys(Keys.Enter);

            //Kaunas
            //Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[3]/span[1]/span")).Click();
            //Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(this.Municipality);
            // Thread.Sleep(2000);
            //Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(Keys.Enter);

            //Driver.FindElement(By.XPath("//*[@id=\"district\"]/span")).Click();
            //Driver.FindElement(By.ClassName("drop-down-value-row")).Click();

            //Siauliai

        }
        public void ChooseLocationKaunas()
        {
            int municipalitycount = Driver.FindElement(By.Id("regionDropdown")).FindElements(By.TagName("li")).Count;
           // int settlementcount = Driver.FindElement(By.ClassName("dropdown-input-values-address")).FindElements(By.TagName("li")).Count;
          //  int microdistrictcount = Driver.FindElement(By.ClassName("dropdown-input-search-value")).FindElements(By.TagName("li")).Count;
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[3]/span[1]/span")).Click();
            Driver.FindElement(By.XPath("//*[@id=\"regionDropdown\"]/li[1]/input")).SendKeys(this.Municipality);
            //                                                      //////*[@id="regionDropdown"]/li[63]
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"regionDropdown\"]/li[" + (municipalitycount + 1) + "]"))).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//*[@id=\"district\"]/span")).Click();
           IWebElement districtUl = Driver.FindElements(By.ClassName("dropdown-input-values-address"))[1];
            IList<IWebElement> DisctictLis = districtUl.FindElements(By.TagName("li"));
            if(DisctictLis.Count > 15)
            {
                Console.WriteLine(">10");
                districtUl.FindElement(By.TagName("input")).SendKeys(this.Settlement);
                Thread.Sleep(1000);
                districtUl.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }
            else
            {
                Console.WriteLine("<=10");
                for (int i = 0; i < DisctictLis.Count; i++)
                {
                    if (DisctictLis[i].Text.Contains(this.Settlement))
                    {
                        DisctictLis[i].Click();
                        break;
                    }
                }
            }

            //  wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"regionDropdown\"]/li[" + (settlementcount) + "]"))).Click();
            //Driver.FindElement(By.XPath("//*[@id=\"districts_43\"]/li")).Click();

            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//*[@id=\"quartalField\"]/span[1]/span[2]")).Click();
            IWebElement quartaltUl = Driver.FindElements(By.ClassName("dropdown-input-values-address"))[2];
            IList<IWebElement> quartaLis = quartaltUl.FindElements(By.TagName("li"));
            if (quartaLis.Count > 15)
            {
                quartaltUl.FindElement(By.TagName("input")).SendKeys(this.Microdistrict);
                Thread.Sleep(1000);
                quartaltUl.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }
            else
            {
                for (int i = 0; i < quartaLis.Count; i++)
                {
                    if (quartaLis[i].Text.Contains(this.Microdistrict))
                    {
                        quartaLis[i].Click();
                        break;
                    }
                }
            }


            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//*[@id=\"streetField\"]/span[1]/span[2]")).Click();
            IWebElement streettUl = Driver.FindElements(By.ClassName("dropdown-input-values-address"))[3];
            IList<IWebElement> streetLis = streettUl.FindElements(By.TagName("li"));
            if (streetLis.Count > 15)
            {
                streettUl.FindElement(By.TagName("input")).SendKeys(this.Street);
                Thread.Sleep(1000);
                streettUl.FindElement(By.TagName("input")).SendKeys(Keys.Enter);
            }
            else
            {
                for (int i = 0; i < streetLis.Count; i++)
                {
                    if (streetLis[i].Text.Contains(this.Street))
                    {
                        streetLis[i].Click();
                        break;
                    }
                }
            }

            //   Driver.FindElements(By.ClassName("dropdown-input-search-value"))[2].FindElement(By.TagName("input")).SendKeys(this.Microdistrict);
            //                                                     //*[@id="quartals_6"]/li[2]
            //   wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"quartals_6\"]/li["+ (microdistrictcount + 1 ) + "]"))).Click();
        }
        public void PlotNo()
        {
            Driver.FindElement(By.Name("FHouseNum")).SendKeys(this.Number);
        }
        public void Acceptrules()
        {
            if (CheckRules) {
                Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[38]/span[1]/div/div/label/span")).Click();
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
                Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[37]/div/div/div/label/span")).Click();
            }
        }

        public void TurnOffEmail()
        {
            if (ContactByEmail)
            {
                Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[36]/div/div/div/label/span")).Click();
            }
        }
        public void Phonoentry()
        {
            Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[34]/span[1]/input")).SendKeys(this.Phono);
        }
        public void PlotPrice()
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
        public void PLotDescription()
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
            chooseFile.SendKeys("C:\\Users\\Kornelija\\Desktop\\inzinerine_geodezija-274.jpg");
        }
        public void ChoosePurpose()
        {
            for(int i = 0; i< CheckBoxes.Length; i++)
            {
                switch(CheckBoxes[i])
                {
                    case 1 : //"Namų valda"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[1]/label/span")).Click();
                        //driver spaudziam namu valda;
                        break;
                    case 2:  //"Sklypas soduose"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[4]/label/span")).Click();
                        //driver spaudžiam misku ukio
                        break;
                    case 3:  //"Sandėliavimo"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[7]/label/span")).Click();
                        break;
                    case 4:  //"Kita"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[10]/label/span")).Click();
                        break;
                    case 5:  //"Daugiabučių statyba"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[2]/label/span")).Click();
                        break;
                    case 6:  //"Miškų ūkio"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[5]/label/span")).Click();
                        break;
                    case 7:  //"Komercinė"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[8]/label/span")).Click();
                        break;
                    case 8: //"Žemės ūkio"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[3]/label/span")).Click();
                        break;
                    case 9:  //"Pramonės"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[6]/label/span")).Click();
                            break;
                    case 10:  //"Rekreacinė"
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[16]/div/div[9]/label/span")).Click();
                        break;
                }
            }
        }
        public void ChooseAddFeatures()
        {
            Driver.FindElement(By.ClassName("bigObjBtn")).Click();
            for (int i = 0; i < AdditionalFeatures.Length; i++)
            {
                switch (AdditionalFeatures[i])
                {
                    case 1: // Elektra
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[1]/label/span")).Click();
                        break;
                    case 2: // Kraštinis sklypas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[4]/label/span")).Click();
                        break;
                    case 3: //Geodeziniai matavimai
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[7]/label/span")).Click();
                        break;
                    case 4: // Domina keitimas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div/div/label/span")).Click();
                        break;
                    case 5: // Varžytinės/aukcionas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[23]/div/div/div/label/span")).Click();
                        break;
                    case 6: //Dujos
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[2]/label/span")).Click();
                        break;
                    case 7: //Greta miško
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[5]/label/span")).Click();
                        break;
                    case 8: //Su pakrante
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[8]/label/span")).Click();
                        break;
                    case 9: //Vanduo
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[3]/label/span")).Click();
                        break;
                    case 10: //Be pastatų
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[6]/label/span")).Click();
                        break;
                    case 11: //Asfaltuotas privažiavimas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[20]/div/div[9]/label/span")).Click();
                        break;

                }
            }
        }
    }
}
