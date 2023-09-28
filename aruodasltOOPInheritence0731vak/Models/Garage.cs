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
        public string ClickType2 { get; set; }
        public int FillCar { get; set; }
        public int[] AdditionalFeatures { get; set; }
        public int[] AdditionalFeatures2 {  get; set; }
        public bool GarageType { get; set; }
        public bool AutoPlace { get; set; }


        public Garage(string municipality, string settlement, string microdistrict, string street, string number, string area, bool checkRules, bool contactByEmail, bool chatTurnOff, string phono, string price, string rcnumber, string description, string link, string ddd, string clickType,string clickType2, int fillCar, int[] additionalFeatures,int[] additionalFeatures2, bool garageType, bool autoPlace) 
            : base( municipality,  settlement,  microdistrict,  street,  number)
        {
           
            Area = area;
            CheckRules = checkRules;
            ContactByEmail = contactByEmail;
            ChatTurnOff = chatTurnOff;
            Phono = phono;
            Price = price;
            RCnumber = rcnumber;
            Description = description;
            Link = link;
            ClickType = clickType;
            ClickType2 = clickType2;
            Ddd = ddd;
            FillCar = fillCar;
            AdditionalFeatures = additionalFeatures;
            AdditionalFeatures2 = additionalFeatures2;
            GarageType = garageType;
            AutoPlace = autoPlace;
        }

        public void fill()
        {
            Console.WriteLine("fill part");
            Driver.Navigate().GoToUrl("https://www.aruodas.lt/ideti-skelbima/?obj=13&offer_type=1");
            Console.WriteLine("open url");
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
            FitsCar();
            ByFunctionality();


            Driver.FindElement(By.Id("fieldFAreaOverAll")).SendKeys(Area);
        }
        
     
        public void GarageNo()
        {
            Driver.FindElement(By.Name("FHouseNum")).SendKeys(Number);
        }
        public void Acceptrules()
        {
            if (CheckRules)
            {
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
        public void Type2()
        {
            switch (ClickType2)
            {
                case "Požeminėje aikštelėje":
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[17]/div/div[1]/div[2]")).Click();
                    break;
                case "Antžeminėje aikštelėje":
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[17]/div/div[2]/div[2]")).Click();
                    break;
                case "Daugiaaukštėje aikštelėje":
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[17]/div/div[3]/div[2]")).Click();
                    break;
                case "Kita":
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[17]/div/div[4]/div[2]")).Click();
                    break;
            }
        }
        public void FitsCar()
        {
            switch (FillCar)
            {
                case 1:
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[18]/div/div[1]/div[2]")).Click();
                    break;
                case 2:
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[18]/div/div[2]/div[2]")).Click();
                    break;
                case 3:
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[18]/div/div[3]/div[2]")).Click();
                    break;
                case 4:
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[18]/div/div[4]/div[2]")).Click();
                    break;
                default:
                    Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[18]/div/span/input")).SendKeys(FillCar + "");
                    break;
            }
        }
        public void ChooseAddFeatures()
        {
            Driver.FindElement(By.ClassName("bigObjBtn")).Click();
            for (int i = 0; i < AdditionalFeatures.Length; i++)
            {
                switch (AdditionalFeatures[i])
                {
                    case 1: // Apsauga
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div[1]/label/span")).Click();
                        break;
                    case 2: // Rūsys
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div[4]/label/span")).Click();
                        break;
                    case 3: //Domina keitimas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[26]/div/div/div/label/span")).Click();
                        break;
                    case 4: // Varžytinės/aukcionas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[27]/div/div/div/label/span")).Click();
                        break;
                    case 5: // Autimatiniai vartai
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div[2]/label/span")).Click();
                        break;
                    case 6: //Vanduo
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div[5]/label/span")).Click();
                        break;
                    case 7: //Duobė
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div[3]/label/span")).Click();
                        break;
                    case 8: //Šildymas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[22]/div/div[6]/label/span")).Click();
                        break;

                }
            }
        }
        public void ChooseAddFeatures2()
        {
            Driver.FindElement(By.ClassName("bigObjBtn")).Click();
            for (int i = 0; i < AdditionalFeatures2.Length; i++)
            {
                switch (AdditionalFeatures2[i])
                {
                    case 1: // Apsauga
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[1]/label/span")).Click();
                        break;
                    case 2: // Užraktas                   
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[4]/label/span")).Click();
                        break;
                    case 3: //Su sandėliuku
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[7]/label/span")).Click();
                        break;
                    case 4: // Domina keitimas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[26]/div/div/div/label/span")).Click();
                        break;
                    case 5: // Varžytinės/aukcionas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[27]/div/div/div/label/span")).Click();
                        break;
                    case 6: //Automatiniai vartai
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[2]/label/span")).Click();
                        break;
                    case 7: //Aptverta
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[5]/label/span")).Click();
                        break;
                    case 8: //Šildymas
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[3]/label/span")).Click();
                        break;
                    case 9: //Po stogu
                        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[24]/div/div[6]/label/span")).Click();
                        break;

                }
            }
        }
     

        public void ByFunctionality()
        {
             if (GarageType)
             {
                Driver.FindElement(By.XPath("//*[@id=\"parking_checkbox\"]/div/label")).Click();
                 Type();
                 ChooseAddFeatures();
             }
             else if (AutoPlace)
             {
                Driver.FindElement(By.XPath("//*[@id=\"whole_building_checkbox\"]/div/label/span")).Click();
                Type2();
                 ChooseAddFeatures2();
             }
        }
        
    }
}
