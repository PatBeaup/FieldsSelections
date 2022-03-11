using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldsSelections
{
    public class MainPage : APage
    {
        const string PAGE_URL = "formy-project.herokuapp.com/";

        public MainPage(IWebDriver driver) : base(driver) {
            ExpectedPageUrl = PAGE_URL;
        }

        public override PageTypes GetPageType()
        {
            if (AssertPage())
                return PageTypes.MainPage;
            else
                return base.GetPageType();
        }
    }
}
