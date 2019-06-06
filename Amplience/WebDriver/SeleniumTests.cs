using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Amplience.WebDriver.PageObject;
using Amplience.API.Model;
using OpenQA.Selenium.Remote;

namespace Amplience.WebDriver
{
    public class SeleniumTests
    {
        public static RemoteWebDriver driver;
        string url = "https://api.github.com/users/6wl";

        [SetUp]
        public void SetUp()
        {
           driver = new ChromeDriver(Environment.CurrentDirectory); 
           driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void Selenium()
        {
            var gituser = new GitUserPageObjects();
            Assert.Multiple(() =>
            {
                Assert.That(gituser.GetFrontEndUserDetails("company"), Is.EqualTo(GitHubTestUser.Company));
                Assert.That(gituser.GetFrontEndUserDetails("name"), Is.EqualTo(GitHubTestUser.Name));
                Assert.That(gituser.GetFrontEndUserDetails("followers"), Is.EqualTo(GitHubTestUser.Followers));
                Assert.That(gituser.GetFrontEndUserDetails("following"), Is.EqualTo(GitHubTestUser.Following));
                Assert.That(gituser.GetFrontEndUserDetails("id"), Is.EqualTo(GitHubTestUser.ID));
                Assert.That(gituser.GetFrontEndUserDetails("public_gists"), Is.EqualTo(GitHubTestUser.PublicGists));
                Assert.That(gituser.GetFrontEndUserDetails("public_repos"), Is.EqualTo(GitHubTestUser.PublicRepos));
                Assert.That(gituser.GetFrontEndUserDetails("location"), Is.EqualTo(GitHubTestUser.Location));

            });

        }

    }
}
