using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FieldsSelections
{
    public class NavigationTests
    {
        const String TestUrl = "https://formy-project.herokuapp.com";
        IWebDriver? driver;

        public NavigationTests()
        {

        }

        [SetUp]
        public void Setup()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void SwitchPageTest()
        {
            if (driver != null)
            {
                driver.Url = TestUrl;

                APage currentPage = new MainPage(driver);

                currentPage = currentPage.SelectNavigationMenuItem(NavigationMenu.NavMainChoices.Components);

                System.Threading.Thread.Sleep(200);
                currentPage = currentPage.ComponentDropdownSelect(NavigationMenu.NavComponentsDropdownChoices.RadioButton);
                System.Threading.Thread.Sleep(200);
                currentPage = currentPage.ComponentDropdownSelect(NavigationMenu.NavComponentsDropdownChoices.CheckBox);
                System.Threading.Thread.Sleep(200);
                currentPage = currentPage.ComponentDropdownSelect(NavigationMenu.NavComponentsDropdownChoices.DatePicker);
                System.Threading.Thread.Sleep(200);
                currentPage = currentPage.SelectNavigationMenuItem(NavigationMenu.NavMainChoices.Form);
                System.Threading.Thread.Sleep(1000);
                
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
                driver.Quit();
        }
    }

    public class RadioButtonsTests
    {
        const String TestUrl = "https://formy-project.herokuapp.com/radiobutton";
        IWebDriver? driver;

        public RadioButtonsTests()
        {

        }

        [SetUp]
        public void Setup()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void RadioButtons()
        {
            if (driver != null)
            {
                driver.Url = TestUrl;

                RadioButtonsPage MyRadioButtonsPage = new RadioButtonsPage(driver);

                Assert.AreEqual(MyRadioButtonsPage.GetPageType(), APage.PageTypes.RadioButtonsPage);

                MyRadioButtonsPage.ClickButtons();

                //System.Threading.Thread.Sleep(3000);
            }
        }  

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
                driver.Quit();
        }
    }
    public class CheckBoxesTests
    {
        const String TestUrl = "https://formy-project.herokuapp.com/checkbox";
        IWebDriver? driver;

        public CheckBoxesTests()
        {

        }

        [SetUp]
        public void Setup()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void CheckBoxes()
        {
            if (driver != null)
            {
                driver.Url = TestUrl;

                CheckBoxesPage MyCheckBoxesPage = new CheckBoxesPage(driver);

                Assert.AreEqual(MyCheckBoxesPage.GetPageType(), APage.PageTypes.CheckBoxesPage);

                MyCheckBoxesPage.ClickButtons();

                //System.Threading.Thread.Sleep(3000);
            }
        }  

        [TearDown]
        public void CloseBrowser()
        {
            if (driver != null)
                driver.Quit();
        }
    }
}