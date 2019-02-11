using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Alba;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SP19.P03.Web;
using SP19.P03.Web.Controllers;

namespace SP19.P03.Tests
{
    // ~~~~~~~~~~~~~ dear 383 students, don't muck with this stuff - it isn't broken

    [TestClass]
    public class ApiTests
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            using (var test = new SqlConnection(GetConnection().Replace("SP19-P03-Testing","master")))
            {
                test.Open();
                var command = new SqlCommand("DROP DATABASE IF EXISTS [SP19-P03-Testing]", test);
                command.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public async Task WebStarts_SimpleEndpointAccessbiel()
        {
            using (var webServer = SystemUnderTest.ForStartup<Startup>(Configure))
            {
                var result = await webServer
                    .GetAsJson<string[]>("/api/values");

                Assert.IsNotNull(result);
                Assert.IsTrue(result.Length == 2);
            }
        }

        [TestMethod]
        public void DataContext_IsOneDeclared()
        {
            var type = typeof(ValuesController).Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(DbContext))).ToList();
            Assert.IsTrue(type.Count > 0, "You don't have a datacontext delcared yet");
            Assert.IsFalse(type.Count > 1, "You have more than one data context created");
            Assert.IsTrue(type[0].Name == "DataContext", "You need to call it 'DataContext' not " + type[0].Name);
        }

        [TestMethod]
        public async Task DataContext_Registered()
        {
            await RunWebTest("/api/DataContextTests/EnsureRegistered");
        }

        [TestMethod]
        public async Task DataContext_HasUsers()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/User");
        }

        [TestMethod]
        public async Task DataContext_HasRoles()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/Role");
        }

        [TestMethod]
        public async Task DataContext_HasCustomer()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/Customer");
        }

        [TestMethod]
        public async Task DataContext_HasPaymentOption()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/PaymentOption");
        }

        [TestMethod]
        public async Task DataContext_HasReceipt()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/Receipt");
        }

        [TestMethod]
        public async Task DataContext_HasLineItem()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/LineItem");
        }

        [TestMethod]
        public async Task DataContext_HasTable()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/Table");
        }

        [TestMethod]
        public async Task DataContext_HasTableFoodItem()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/TableFoodItem");
        }

        [TestMethod]
        public async Task DataContext_HasTableBill()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/TableBill");
        }

        [TestMethod]
        public async Task DataContext_HasMenu()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/Menu");
        }

        [TestMethod]
        public async Task DataContext_HasMenuItem()
        {
            await RunWebTest("/api/DataContextTests/EnsureSet/Menu");
        }

        [TestMethod]
        public async Task CustomerEndpoints_HasController()
        {
            await AssertEndpointPresent("Customer", 
                new PathAssertion("GET", true, "customer", false, false),
                new PathAssertion("POST", false, "customer", false, true));
        }
        
        [TestMethod]
        public async Task CustomerPaymentOptions_HasController()
        {
            await AssertEndpointPresent("CustomerPaymentOption",
                new PathAssertion("GET", true, "CustomerPaymentOption", true, false),
                new PathAssertion("POST", false, "CustomerPaymentOption", false, true),
                new PathAssertion("DELETE", false, "CustomerPaymentOption", true, false));
        }

        [TestMethod]
        public async Task Users_HasController()
        {
            await AssertEndpointPresent("User",
                new PathAssertion("POST", false, "User", false, true));
        }

        [TestMethod]
        public async Task Menus_HasController()
        {
            await AssertEndpointPresent("Menu",
                new PathAssertion("GET", true, "Menu", false, false),
                new PathAssertion("POST", false, "Menu", false, true),
                new PathAssertion("PUT", false, "Menu", false, true),
                new PathAssertion("DELETE", false, "Menu", true, false));
        }

        [TestMethod]
        public async Task MenuItems_HasController()
        {
            await AssertEndpointPresent("MenuItem",
                new PathAssertion("GET", true, "MenuItem", true, false),
                new PathAssertion("POST", false, "MenuItem", false, true),
                new PathAssertion("PUT", false, "MenuItem", false, true),
                new PathAssertion("DELETE", false, "MenuItem", true, false));
        }

        [TestMethod]
        public async Task Tables_HasController()
        {
            await AssertEndpointPresent("Table",
                new PathAssertion("GET", true, "Table", false, false),
                new PathAssertion("POST", false, "Table", false, true),
                new PathAssertion("PUT", false, "Table", false, true),
                new PathAssertion("DELETE", false, "Table", true, false));
        }

        [TestMethod]
        public async Task TableBills_HasController()
        {
            await AssertEndpointPresent("TableBill",
                new PathAssertion("GET", true, "Table", false, false),
                new PathAssertion("POST", false, "Table", false, true),
                new PathAssertion("PUT", false, "Table", false, true),
                new PathAssertion("DELETE", false, "Table", true, false),
                new AddCustomerAssertion());
        }

        [TestMethod]
        public async Task TableFoodItems_HasController()
        {
            await AssertEndpointPresent("TableFoodItem",
                new PathAssertion("GET", true, "TableFoodItem", true, false),
                new PathAssertion("POST", false, "TableFoodItem", false, true),
                new PathAssertion("PUT", false, "TableFoodItem", false, true),
                new PathAssertion("DELETE", false, "TableFoodItem", true, false));
        }

        private static IWebHostBuilder Configure(IWebHostBuilder x)
        {
            x.ConfigureAppConfiguration(y =>
            {
                var connection = GetConnection();
                y.Add(new MemoryConfigurationSource
                {
                    InitialData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("ConnectionStrings:DataContext", connection)
                    }
                });
            });
            return x;
        }

        private static string GetConnection()
        {
            string connection;
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                connection = "Server=localhost,1433;Database=SP19-P03-Testing;User Id=sa;Password=Password123!;";
            }
            else
            {
                connection = "Server=(localdb)\\mssqllocaldb;Database=SP19-P03-Testing;Trusted_Connection=True";
            }
            return connection;
        }

        private static async Task RunWebTest(string testUrl)
        {
            using (var webServer = SystemUnderTest.ForStartup<Startup>(Configure))
            {
                await AssertPass(webServer, testUrl);
            }
        }

        private async Task AssertEndpointPresent(string endpointName, params PathAssertion[] pathAssertions)
        {
            using (var webServer = SystemUnderTest.ForStartup<Startup>(Configure))
            {
                SwaggerDescriptor result;
                try
                {
                    var rawData = await webServer.Scenario(x=>x.Get.Url("/swagger/v1/swagger.json").Accepts("application/json"));
                    var text = rawData.ResponseBody.ReadAsText().Replace("$ref","ref");// this is extra silly, $ref is reserved for newtonsoft magic
                    result = JsonConvert.DeserializeObject<SwaggerDescriptor>(text);
                }
                catch (Exception e)
                {
                    throw new Exception("You do not have swagger configured", e);
                }
                Assert.AreEqual("2.0", result.Swagger, "You do not have swagger configured");

                var path = GetMatchingPaths(endpointName, result.Paths);
                foreach (var pathAssertion in pathAssertions)
                {
                    pathAssertion.AssertPass(endpointName, path);
                }
            }
        }

        private static Operation[] GetMatchingPaths(string endpointName, IDictionary<string, Operation> resultPaths)
        {
            var result = resultPaths
                .Where(x => x.Key.ToLowerInvariant().Contains("/"+endpointName.ToLowerInvariant()))
                .Select(x=>x.Value)
                .ToArray();
            if (result.Length < 1)
            {
                Assert.Fail($"Expected you to have a controller related to '{endpointName}'");
            }
            return result;
        }

        private static async Task AssertPass(ISystemUnderTest webServer, string url)
        {
            var result = await webServer.GetAsJson<string[]>(url);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 2);
        }
    }
}
