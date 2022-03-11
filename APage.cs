using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FieldsSelections
{

    public abstract class APage
    {
        public enum PageTypes { APage, MainPage, FormPage, RadioButtonsPage, CheckBoxesPage, DatePickerPage }
        public virtual string ExpectedPageUrl
        {
            get ;
            protected set ;
        }

        public IWebDriver driver { get; }

        private NavigationMenu NavMenu;

        public APage(IWebDriver driver)
        {
            this.driver = driver;
            ExpectedPageUrl = "";
            NavMenu = new NavigationMenu(this);
        }

        public virtual bool AssertPage()
        {
            return AssertPage(ExpectedPageUrl);
        }

        private bool AssertPage(string pageRelativeUrl)
        {
            string url = driver.Url;
            if (!driver.Url.EndsWith(pageRelativeUrl))
            {
                System.Threading.Thread.Sleep(50);
                if (!driver.Url.EndsWith(pageRelativeUrl))
                    return false;
            }
            return true;
        }

        public virtual PageTypes GetPageType()
        {
            throw new Exception("Conditions to assert the page type are not met or a Page Object Model is not set on the correct page.");
        }

        public virtual APage SelectNavigationMenuItem(NavigationMenu.NavMainChoices MainMenuChoice)
        {
            return NavMenu.MainNavBarSelect(MainMenuChoice);
        }

        public virtual APage ComponentDropdownSelect(NavigationMenu.NavComponentsDropdownChoices NavChoice)
        {
            return NavMenu.ComponentDropdownSelect(NavChoice);
        }
    }

}
