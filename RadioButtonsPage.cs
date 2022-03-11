using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsSelections
{
    public class RadioButtonsPage : APage
    {
        const string PAGE_URL = "/radiobutton";

        private readonly By RadioButton1 = By.Id("radio-button-1");
        private readonly By RadioButton2 = By.CssSelector("input[value='option2']");
        private readonly By RadioButton3 = By.CssSelector("input[value='option3']");

        public RadioButtonsPage(IWebDriver driver) : base(driver)
        {
            ExpectedPageUrl = PAGE_URL;
        }

        public override PageTypes GetPageType()
        {
            if (AssertPage())
                return PageTypes.RadioButtonsPage;
            else
                return base.GetPageType();
        }

        private void ClickButton(By Button)
        {
            driver.FindElement(Button).Click();
        }
        public void ClickButtons()
        {
            ClickButton(RadioButton1);
            System.Threading.Thread.Sleep(500);
            ClickButton(RadioButton2);
            System.Threading.Thread.Sleep(500);
            ClickButton(RadioButton3);
        }
    }
}
