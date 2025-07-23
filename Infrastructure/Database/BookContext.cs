using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Metadata;

namespace Infrastructure.Database
{
    public class BookContext(DbContextOptions<BookContext> options) : DbContext (options)
    {
        // Таблицы сущностей
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        // Применение конфигураций (см. ниже)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BooksConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorsConfiguration());
                
        }
    }

    // Конфигурации сущностей
    public class BooksConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);
            builder
                .HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(200);
        }
    }

    public class AuthorsConfiguration : IEntityTypeConfiguration<Author> 
    {
        public void Configure(EntityTypeBuilder<Author> builder) 
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(100);
        }

    }
}
