using CloudinaryDotNet;
using dotenv.net;
using E_Learn.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace E_Learn.Infrastructure.IoC
{
    public class DependecyInjection
    {

        private WebApplicationBuilder _builder;
        private string connectionString;

        private IDictionary<string, string> env = DotEnv.Read();


        public DependecyInjection(WebApplicationBuilder builder)
        {
            _builder = builder;
            connectionString = env["DATABASE_URL"];
        }

        public static DependecyInjection builder(WebApplicationBuilder builder)
        {
            return new DependecyInjection(builder);
        }

        public DependecyInjection context()
        {
            _builder.Services
                 .AddDbContext<Context>(options => options.UseNpgsql(connectionString));
            return this;

        }


        public DependecyInjection services()
        {
            return this;
        }
    }
}
