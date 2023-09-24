using System.Threading.Tasks;
using AMS.Models.TokenAuth;
using AMS.Web.Controllers;
using Shouldly;
using Xunit;

namespace AMS.Web.Tests.Controllers
{
    public class HomeController_Tests: AMSWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}