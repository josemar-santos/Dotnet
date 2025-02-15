using Microsoft.EntityFrameworkCore;

namespace E_Learn.Infrastructure.Database.Context
{
    public class Context: DbContext
    {

        public Context(DbContextOptions<Context> options): base(options) { }
    }
}
