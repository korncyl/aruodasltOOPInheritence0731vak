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
       
      
        
        
        
        
       
        
        
        
        public string Photo { get; set; }
        public string ClickType { get; set; }
        public string ClickType2 { get; set; }
        public int FillCar { get; set; }
        public int[] AdditionalFeatures { get; set; }
        public int[] AdditionalFeatures2 {  get; set; }
        public bool GarageType { get; set; }
        public bool AutoPlace { get; set; }


        public Garage(string municipality, string settlement, string microdistrict, string street, string number, string area, bool checkRules, bool contactByEmail, bool chatTurnOff, string phono, string price, string rcnumber, string description, string link, string ddd, string clickType,string clickType2, int fillCar, int[] additionalFeatures,int[] additionalFeatures2, bool garageType, bool autoPlace, string photo) 
            : base( municipality,  settlement,  microdistrict,  street,  number, area, rcnumber, checkRules, chatTurnOff, contactByEmail, description, price, phono, ddd, link)
        {
           
            
            
            
          
            
            
            
            
            
            ClickType = clickType;
            ClickType2 = clickType2;
            Photo = photo;
            FillCar = fillCar;
            AdditionalFeatures = additionalFeatures;
            AdditionalFeatures2 = additionalFeatures2;
            GarageType = garageType;
            AutoPlace = autoPlace;
        }

        public void fill()
        {
            Driver.Navigate().GoToUrl("https://www.aruodas.lt/ideti-skelbima/?obj=13&offer_type=1");
            base.fill();
            //Console.WriteLine("fill part");
            //Console.WriteLine("open url");

            //ChooseLocation();
            //IteamNo();
            //Acceptrules();
            //TurnOffFunctions();
            //Phonoentry();
            //GaragePrice();
            //RC();
            //GarageDescription();
            //YoutubeLink();
            //DddLInk();
            UploadPhoto();
            FitsCar();
            ByFunctionality();
            //IteamArea();
            

            
        }

        public override void ItemDescription()
        {
            Driver.FindElement(By.ClassName("lang-en-label")).Click();
            Driver.FindElement(By.Name("notes_en")).SendKeys(this.Description);
        }
        //public void GarageNo()
        //{
        //    Driver.FindElement(By.Name("FHouseNum")).SendKeys(Number);
        //}

        //public void TurnOffFunctions()
        //{
        //    //TurnOffChat();
        //    TurnOffEmail();
        //}


        //public void TurnOffEmail()
        //{
        //    if (ContactByEmail)
        //    {
        //        Driver.FindElement(By.XPath("//*[@id=\"newObjectForm\"]/ul/li[40]/div/div/div/label/span")).Click();
        //    }
        //}






        public void UploadPhoto()
        {                                                        //"//*[@id=\"uploadPhotoBtn\"]/input"
            IWebElement chooseFile = Driver.FindElement(By.XPath("//*[@id=\"uploadPhotoBtn\"]/input"));
            //chooseFile.Click();
            chooseFile.SendKeys(Photo);
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
