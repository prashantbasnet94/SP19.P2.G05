using System.Collections.Generic;
using Alba;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration.Memory;
using SP19.P05.Web;

namespace SP19.P05.Tests.Helpers
{
    public static class TestHelper
    {
        public static SystemUnderTest GetTestWeb()
        {
            return SystemUnderTest.ForStartup<Startup>(Configure);
        }

        private static IWebHostBuilder Configure(IWebHostBuilder x)
        {
            x.ConfigureAppConfiguration(y =>
            {
                var connection = AssemblySetup.GetConnection();
                y.Add(new MemoryConfigurationSource
                {
                    InitialData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("ConnectionStrings:DataContext", connection),
                        new KeyValuePair<string, string>("Logging:LogLevel:Microsoft", "Warning")
                    }
                });
            });
            return x;
        }
    }
}