using E_Learn.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Learn.Infrastructure.IoC
{
    public class DependecyInjection
    {

        private WebApplicationBuilder _builder;
        private string? connectionString;


        public DependecyInjection(WebApplicationBuilder builder)
        {
            _builder = builder;
            connectionString = _builder.Configuration.GetConnectionString("default");
        }

        public static DependecyInjection builder(WebApplicationBuilder builder)
        {
            return new DependecyInjection(builder);
        }

        public DependecyInjection context()
        {
            _builder.Services
                 .AddDbContext<Context>(options => options.UseNpgsql(connectionString));

            Console.WriteLine(connectionString);
            return this;

        }


        public DependecyInjection services()
        {

            return this;
        }
    }
}
