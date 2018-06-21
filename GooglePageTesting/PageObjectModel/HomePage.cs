using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;

namespace GooglePageTesting.PageObjectModel
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public ResultPage Search(string str)
        {
            IWebElement element = driver.FindElement(By.Name("q"));
            element.SendKeys(str);
            element.Submit();
            return new ResultPage(driver);
        }
    }
}
