using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xy.Project.Core.Base;
using Xy.Project.Core.Extensions;
using Xy.Project.Platform.Model.Entity.Sys;

namespace EFCoreTest
{
    public class TestDbContext: DbContext
    {

        public DbSet<TestUser> TestUsers { get; set; }
        public TestDbContext(DbContextOptions<TestDbContext> contextOptions) : base(contextOptions)
        { 
        
         


          
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TestUserConfiguration());
        }
 
    }


    public class TestUser: PrivateDEntityBase<Guid>
    { 
    
    
        public string? Name { get; set; }
        public string Tile { get; set; }

    
    }

    internal class TestUserConfiguration : IEntityTypeConfiguration<TestUser>
    {
        public void Configure(EntityTypeBuilder<TestUser> builder)
        {
            builder.HasKey(o => o.Id);
            //builder.HasIndex("Id");
            builder.ToTable("TestUser");
        }
    }
}
