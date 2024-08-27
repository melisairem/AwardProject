using Microsoft.EntityFrameworkCore;

namespace AwardProjectEntity.Base
{
    public class ModelContext : DbContext
    {
        private static ModelContext _instance;
        private static readonly object _lock = new object();

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        public static ModelContext Intance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            var optionsBuilder = new DbContextOptionsBuilder<ModelContext>();
                            optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q9UG9JQ;Database=Award;User Id=sa;Password=123;TrustServerCertificate=True");
                            return new ModelContext(optionsBuilder.Options);
                        }
                    }
                }
                return _instance;
            }
        }

        public DbSet<User> User { get; set; }

        public DbSet<Award> Award { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<UserAward> UserAward { get; set; }
    }
}