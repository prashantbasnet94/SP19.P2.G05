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
using SP19.P2.Web;
using SP19.P2.Web.Controllers;

namespace SP19.P02.Tests
{
    [TestClass]
    public class ApiTests
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            using (var test = new SqlConnection(GetConnection().Replace("SP19-P2-Testing","master")))
            {
                test.Open();
                var command = new SqlCommand("DROP DATABASE IF EXISTS [SP19-P2-Testing]", test);
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

        private static IWebHostBuilder Configure(IWebHostBuilder x)
        {
            x.ConfigureAppConfiguration(y =>
            {
                var connection = GetConnection();
                y.Add(new MemoryConfigurationSource
                {
                    InitialData = new List<KeyValuePair<string, string>>
                    {
                        {
                            new KeyValuePair<string, string>("ConnectionStrings:DataContext", connection)
                        }
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
                connection = "Server=localhost,1433;Database=SP19-P2-Testing;User Id=sa;Password=Password123!;";
            }
            else
            {
                connection = "Server=(localdb)\\mssqllocaldb;Database=SP19-P2-Testing;Trusted_Connection=True";
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

        private static async Task AssertPass(SystemUnderTest webServer, string url)
        {
            var result = await webServer.GetAsJson<string[]>(url);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 2);
        }
    }
}
