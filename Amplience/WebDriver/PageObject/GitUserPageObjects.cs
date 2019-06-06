using System;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Amplience.WebDriver.PageObject
{
    public class GitUserPageObjects
    {
        private RemoteWebDriver _driver;
        public GitUserPageObjects()
        {
            _driver = SeleniumTests.driver;
        }


        public IWebElement element => _driver.FindElementByXPath(".//*[@style= 'word-wrap: break-word; white-space: pre-wrap;']");


        public string GetFrontEndUserDetails(string key)
        {
            dynamic json = JsonConvert.DeserializeObject(element.Text);
            return (string)json[key];
        }
    }
}
