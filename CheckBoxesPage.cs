using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsSelections
{
    public class CheckBoxesPage : APage
    {
        const string PAGE_URL = "/checkbox";

        private readonly By CheckBox1 = By.CssSelector("input[value='checkbox-1']");
        private readonly By CheckBox2 = By.CssSelector("input[value='checkbox-2']");
        private readonly By CheckBox3 = By.CssSelector("input[value='checkbox-3']");

        public CheckBoxesPage(IWebDriver driver) : base(driver)
        {
            ExpectedPageUrl = PAGE_URL;
        }

        public override PageTypes GetPageType()
        {
            if (AssertPage())
                return PageTypes.CheckBoxesPage;
            else
                return base.GetPageType();
        }

        private void ClickButton(By Button)
        {
            driver.FindElement(Button).Click();
        }
        public void ClickButtons()
        {
            ClickButton(CheckBox1);
            System.Threading.Thread.Sleep(500);
            ClickButton(CheckBox2);
            System.Threading.Thread.Sleep(500);
            ClickButton(CheckBox3);
        }
    }
}
