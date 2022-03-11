using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FieldsSelections
{
    public class NavigationMenu
    {
        public enum NavMainChoices { Logo, Form, Components, Unknown }
        public enum NavComponentsDropdownChoices { RadioButton, CheckBox, DatePicker, Unknown }

        private APage currentPage;
        protected IWebDriver driver;
        private Dictionary<NavMainChoices, string> NavMainChoicesDictionary = new Dictionary<NavMainChoices, string>();
        private Dictionary<NavComponentsDropdownChoices, string> NavComponentsDropdownChoicesDictionary = new Dictionary<NavComponentsDropdownChoices, string>();

        private readonly By LogoBy = By.Id("logo");
        private readonly By NavigationBarBy = By.Id("navbarNavDropdown");
        private readonly By ComponentsSubMenuItemsBy = By.CssSelector("a.dropdown-item");

        public NavigationMenu(APage page)
        {
            currentPage = page;
            driver = page.driver;
            NavMainChoicesDictionary.Add(NavMainChoices.Logo, "");
            NavMainChoicesDictionary.Add(NavMainChoices.Form, "Form");
            NavMainChoicesDictionary.Add(NavMainChoices.Components, "Components");
            NavComponentsDropdownChoicesDictionary.Add(NavComponentsDropdownChoices.RadioButton, "Radio Button");
            NavComponentsDropdownChoicesDictionary.Add(NavComponentsDropdownChoices.CheckBox, "Checkbox");
            NavComponentsDropdownChoicesDictionary.Add(NavComponentsDropdownChoices.DatePicker, "Datepicker");
        }
        public APage MainNavBarSelect(NavMainChoices NavMainChoice)
        {
            APage aPage = currentPage;
            IWebElement choice = null;

            IWebElement NavBar = driver.FindElement(NavigationBarBy);
            switch (NavMainChoice)
            {
                case NavMainChoices.Logo:
                    driver.FindElement(LogoBy).Click();
                    aPage = currentPage.GetPageType().Equals(APage.PageTypes.MainPage) ? currentPage : new MainPage(driver);
                    break;
                case NavMainChoices.Form:
                    choice = GetMainMenuChoice(NavMainChoice);
                    choice.Click();
                    //aPage = new FormPage(driver);  //TODO: add a FormPage class
                    break;
                case NavMainChoices.Components:
                    choice = GetMainMenuChoice(NavMainChoice);
                    choice.Click();
                    aPage = this.currentPage;
                    break;
                case NavMainChoices.Unknown:
                    throw new Exception("Unknown choice selected in the main menu.");
                    break;
                default:
                    break;
            }
            return aPage;
        }
        public APage ComponentDropdownSelect(NavComponentsDropdownChoices NavChoice)
        {
            // Find the element corresponding to the menu choice then click on it
            ReadOnlyCollection<IWebElement> MenuChoices;
            do
            {
                currentPage = MainNavBarSelect(NavMainChoices.Components);
                System.Threading.Thread.Sleep(50);
                MenuChoices = driver.FindElements(ComponentsSubMenuItemsBy);
            } while (MenuChoices.First().Text.Equals(""));

            string lookedForText = NavComponentsDropdownChoicesDictionary[NavChoice];
            IWebElement ChosenMenuItem = (MenuChoices.Where(choice => choice.Text.Equals(lookedForText))).First();
            ChosenMenuItem.Click();

            switch (NavChoice)
            {
                case NavComponentsDropdownChoices.RadioButton:
                    currentPage = new RadioButtonsPage(driver);
                    break;
                case NavComponentsDropdownChoices.CheckBox:
                    currentPage = new CheckBoxesPage(driver);
                    break;
                case NavComponentsDropdownChoices.DatePicker:
                    currentPage = new DatePickerPage(driver);
                    break;
                case NavComponentsDropdownChoices.Unknown:
                default:
                    break;
            }
            // Check we are on the right page
            if (!currentPage.AssertPage())
            {
                string actualUrl = driver.Url;
                throw new Exception("Navigation did not end up on the expected page. Expected Url ending: " + currentPage.ExpectedPageUrl + ". Actual Url: " + actualUrl);
            }
            //System.Threading.Thread.Sleep(3000);
            return currentPage;
        }


        private IWebElement GetMainMenuChoice(NavMainChoices NavMainChoice)
        {
            ReadOnlyCollection<IWebElement> MainMenuChoices = driver.FindElements(By.CssSelector("#navbarNavDropdown a.nav-link"));
            IWebElement ChosenMenuItem = (MainMenuChoices.Where(choice => choice.Text.Equals(NavMainChoicesDictionary[NavMainChoice]))).First();
            return ChosenMenuItem;
        }
    }
}
