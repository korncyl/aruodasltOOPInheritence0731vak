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
  
        public string Photo { get; set; }
        public int[] CheckBoxes { get; set; }
        public int[] AdditionalFeatures { get; set; }

        public Plot( string municipality, string settlement,string microdistrict,string street,string number, string area, bool checkRules,bool contactByEmail, bool chatTurnOff, string phono, string price, string rcnumber, string description, string link, string ddd, int[] checkBoxes, int[] additionalFeatures, string photo)
            : base(municipality, settlement, microdistrict, street, number,area, rcnumber, checkRules, chatTurnOff, contactByEmail, description, price, phono, ddd, link)
        {

            Description = description;
            Link = link;
            CheckBoxes = checkBoxes;
            Photo = photo;
            AdditionalFeatures = additionalFeatures;
        }

        public void fill()
        {
            Driver.Navigate().GoToUrl("https://www.aruodas.lt/ideti-skelbima/?obj=11&offer_type=1");
            base.fill();
            ChooseAddFeatures();
            UploadPhoto();
        }

        public void UploadPhoto()
        {
            IWebElement chooseFile = Driver.FindElement(By.ClassName("bigObjBtn"));
            chooseFile.SendKeys(Photo);
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
