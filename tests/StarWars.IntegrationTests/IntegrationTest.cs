using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StarWars.Infrastructure.Data;
using System.Linq;
using System.Net.Http;

namespace StarWars.IntegrationTests
{
    public class IntegrationTest
    {
        protected readonly HttpClient _testClient;

        public IntegrationTest()
        {
            var factory = new WebApplicationFactory<Startup>().WithWebHostBuilder(builder =>
           {
               builder.ConfigureServices(services =>
               {
                   services.Remove((services.FirstOrDefault(s => s.ServiceType == typeof(AppDBContext))));
                   services.AddDbContext<AppDBContext>(options => { options.UseInMemoryDatabase("DBForTesting"); });

               });
           });

            _testClient = factory.CreateClient();
        }
    }
}
