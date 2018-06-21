using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GooglePageTesting.PageObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace GooglePageTesting
{
    public class TestClass : IDisposable
    {
        IWebDriver driver = new ChromeDriver();

        [Fact]
        public void WhenWeAreSearchingAutomatedTestingInfoThenFirstFieldContainsWordAutomated()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            HomePage home = new HomePage(driver);
            home.Search("automated testing info");
            var elements = driver.FindElements(By.ClassName("bkWMgd"));
            foreach (var elem in elements)
            {
                Assert.Contains("automated", elem.Text );
            }
        }

        [Fact]
        public void WhenWeOpenGoogleTheTitleIsGoogle()
        {
            driver.Navigate().GoToUrl("http://www.google.com.ua");
            Assert.Equal("Google", driver.Title);
        }

        public void Dispose()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
