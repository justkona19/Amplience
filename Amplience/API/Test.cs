using Amplience.API.Model;
using NUnit.Framework;
using Amplience.API.Utilities;
using RestSharp;
using Amplience.Model;

namespace Amplience.API
{
    public class Tests
    {
        static string url = "https://api.github.com";
        static string id = "6wl";
        IRestResponse<GitHubUserDetails> User = Services.GetUserDetails(url, id);

        [Test]
        public void verifyResponseCode()
        {
            var userStatusCode = (int)User.StatusCode;
            Assert.That(userStatusCode, Is.EqualTo(200));
        }

        [Test]
        public void VerifyHeaders()
        {
            var headers = User.Headers;
        }

        [Test]
        public void VerifyUserCredentials()
        {
            var credentials = User.Data;
            Assert.Multiple(() =>
            {
                Assert.That(credentials.company, Is.EqualTo(GitHubTestUser.Company));
                Assert.That(credentials.name, Is.EqualTo(GitHubTestUser.Name));
                Assert.That(credentials.followers, Is.EqualTo(GitHubTestUser.Followers));
                Assert.That(credentials.following, Is.EqualTo(GitHubTestUser.Following));
                Assert.That(credentials.id, Is.EqualTo(GitHubTestUser.ID));
                Assert.That(credentials.public_gists, Is.EqualTo(GitHubTestUser.PublicGists));
                Assert.That(credentials.public_repos, Is.EqualTo(GitHubTestUser.PublicRepos));
                Assert.That(credentials.location, Is.EqualTo(GitHubTestUser.Location));

            });
        }
    }
}





