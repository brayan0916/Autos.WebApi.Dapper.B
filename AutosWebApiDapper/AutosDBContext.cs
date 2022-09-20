using Microsoft.EntityFrameworkCore;

namespace AutosWebApiDapper
{
    public class AutosDBContext: DbContext
    {
        public AutosDBContext(DbContextOptions<AutosDBContext> options) : base(options)
        {

        }

        public DbSet<AutosEntity> autosCar { get; set; }
    }
}
