﻿using Microsoft.EntityFrameworkCore;

namespace AwardProjectEntity.Base
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        public DbSet<Award> Award { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<UserAward> UserAward { get; set; }
    }
}