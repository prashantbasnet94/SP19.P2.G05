using System.Collections.Generic;
using System.Threading.Tasks;
using Alba;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SP19.P05.Common.Features.Authorization;
using SP19.P05.Tests.Helpers;
using SP19.P05.Web.Features.Authorization;

namespace SP19.P05.Tests
{
    // 383 students, you should add tests to help ensure your API is working as you expect
    [TestClass]
    public class UnitTestSample
    {
        [TestMethod]
        public async Task UserCanRegister()
        {
            using (var webServer = TestHelper.GetTestWeb())
            {
                var userDto = new CreateUserDto
                {
                    Email = "email@email.com",
                    Password = "Password123!",
                    Roles = new List<int> {1},
                    Username = "username"
                };
                var scenarioResult = await webServer.Scenario(x =>
                {
                    x.Post.Json(userDto).ToUrl("/api/Users");
                    x.StatusCodeShouldBeOk();
                });
                var resultDto = scenarioResult.ResponseBody.ReadAsJson<UserDto>();
                Assert.IsTrue(resultDto.Id > 0, "expected id to be assigned");
            }
        }
    }
}
