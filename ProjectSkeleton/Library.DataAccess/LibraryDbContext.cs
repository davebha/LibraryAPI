using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<LibraryLog> LibraryLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Book

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            #endregion

            SeedAuthors(modelBuilder);
        }

        private void SeedAuthors(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author
            { 
                Id = 1,
                Name = "William Shakespeare"
            });

            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 2,
                Name = "George Orwell"
            });

            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 3,
                Name = "J. K. Rowling"
            });
        }
    }
}
