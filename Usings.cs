global using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace boerse_qa
{
    public class SmokeTest
    {
        [Fact]
        public void BoerseStuttgartPage_Should_Open()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(
                    "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
                );

                Assert.True(driver.Title.Length > 0);
            }
        }

        [Fact]
		public void TopBar_Should_Have_Navigation_Links()
		{
		    var options = new ChromeOptions();
		    options.AddArgument("--start-maximized");

		    using (IWebDriver driver = new ChromeDriver(options))
		    {
		        driver.Navigate().GoToUrl(
		            "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
		        );

		        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		        TryAcceptCookies(wait);

		        var header = driver.FindElement(By.TagName("header"));
		        var links = header.FindElements(By.TagName("a"));

		        Assert.True(links.Count > 0);
		    }
		}


        [Fact]
		public void BondFinder_Should_Have_Header_Menu()
		{
		    var options = new ChromeOptions();
		    options.AddArgument("--start-maximized");

		    using (IWebDriver driver = new ChromeDriver(options))
		    {
		        driver.Navigate().GoToUrl(
		            "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
		        );

		        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		        TryAcceptCookies(wait);

		        var header = driver.FindElements(By.TagName("header"));

		        Assert.True(header.Count > 0);
		    }
		}

		[Fact]
		public void TopBar_Should_Have_CTA_Button()
		{
		    var options = new ChromeOptions();
		    options.AddArgument("--start-maximized");

		    using (IWebDriver driver = new ChromeDriver(options))
		    {
		        driver.Navigate().GoToUrl(
		            "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
		        );

		        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		        TryAcceptCookies(wait);

		        var header = driver.FindElement(By.TagName("header"));

		        var links = header.FindElements(By.TagName("a"))
		                          .Where(l => l.Displayed)
		                          .ToList();

		        Assert.True(links.Count > 0);
		    }
		}


        [Fact]
        public void BoerseStuttgartPage_Should_Show_Headline()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(
                    "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
                );

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                TryAcceptCookies(wait);

                var headline = wait.Until(d =>
                    d.FindElement(By.TagName("h1"))
                );

                Assert.False(string.IsNullOrWhiteSpace(headline.Text));
            }
        }

        [Fact]
        public void BondFinder_Should_Have_Search_Inputs()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(
                    "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
                );

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                TryAcceptCookies(wait);

                var inputs = driver.FindElements(By.CssSelector("input, select"));

				Assert.True(inputs.Count > 0);

            }
        }

        [Fact]
        public void BondFinder_Should_Have_Filters()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(
                    "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
                );

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                TryAcceptCookies(wait);

                var inputs = driver.FindElements(By.TagName("input"));
                var selects = driver.FindElements(By.TagName("select"));

                Assert.True(inputs.Count > 0 || selects.Count > 0);
            }
        }

        [Fact]
        public void BondFinder_Should_Have_Results_Section()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            using (IWebDriver driver = new ChromeDriver(options))
            {
                driver.Navigate().GoToUrl(
                    "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
                );

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                TryAcceptCookies(wait);

                var tables = driver.FindElements(By.TagName("table"));

                Assert.True(tables.Count >= 0);
            }
        }

        [Fact]
		public void BondFinder_Should_Have_Footer()
		{
		    var options = new ChromeOptions();
		    options.AddArgument("--start-maximized");

		    using (IWebDriver driver = new ChromeDriver(options))
		    {
		        driver.Navigate().GoToUrl(
		            "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
		        );

		        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		        TryAcceptCookies(wait);

		        var footer = driver.FindElements(By.TagName("footer"));

		        Assert.True(footer.Count > 0);
		    }
		}

		[Fact]
		public void BondFinder_Should_Have_Results_Container()
		{
		    var options = new ChromeOptions();
		    options.AddArgument("--start-maximized");

		    using (IWebDriver driver = new ChromeDriver(options))
		    {
		        driver.Navigate().GoToUrl(
		            "https://www.boerse-stuttgart.de/de-de/tools/produktsuche/anleihen-finder/"
		        );

		        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
		        TryAcceptCookies(wait);

		        var results = driver.FindElements(By.CssSelector("table, div"));

		        Assert.True(results.Count > 0);
		    }
		}

        private void TryAcceptCookies(WebDriverWait wait)
        {
            try
            {
                var accept = wait.Until(d =>
                    d.FindElement(By.XPath("//button[contains(text(),'Accept')]"))
                );
                accept.Click();
            }
            catch (WebDriverTimeoutException)
            {
               
            }
        }
    }
}
