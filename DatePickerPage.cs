using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsSelections
{
    public class DatePickerPage : APage
    {
        const string PAGE_URL = "/datepicker";

        private readonly By DatePicker = By.Id("datepicker");

        public DatePickerPage(IWebDriver driver) : base(driver)
        {
            ExpectedPageUrl = PAGE_URL;
        }

        public override PageTypes GetPageType()
        {
            if (AssertPage())
                return PageTypes.DatePickerPage;
            else
                return base.GetPageType();
        }


    }
}
