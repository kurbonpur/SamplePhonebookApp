using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SamplePhonebookApp.Models
{
    public partial class ApplicationContext: IdentityDbContext<User>
    {
        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Phone> Phones { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
           Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          //  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /*
               protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

                    modelBuilder.Entity<Category>(entity =>
                    {
                        entity.ToTable("Category");

                        entity.Property(e => e.Name).HasMaxLength(30);
                    });

                    modelBuilder.Entity<Phone>(entity =>
                    {
                        entity.ToTable("Phone");

                        entity.Property(e => e.Id).HasColumnName("id");

                        entity.Property(e => e.Address).HasMaxLength(60);

                        entity.Property(e => e.Name).HasMaxLength(30);

                        entity.HasOne(d => d.Category)
                            .WithMany(p => p.Phones)
                            .HasForeignKey(d => d.CategoryId)
                            .HasConstraintName("FK_Phone_Category");
                    });

                    OnModelCreatingPartial(modelBuilder);
                }

                partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
                */
    }
}