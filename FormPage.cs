using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsSelections
{
    public class FormPage : APage
    {
        const string PAGE_URL = "/form";

        private readonly By DatePicker = By.Id("formpage");

        public FormPage(IWebDriver driver) : base(driver)
        {
            ExpectedPageUrl = PAGE_URL;
        }

        public override PageTypes GetPageType()
        {
            if (AssertPage())
                return PageTypes.FormPage;
            else
                return base.GetPageType();
        }


    }
}
