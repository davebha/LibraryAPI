using Library.DataAccess;
using Library.DataAccess.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Extensions
{
    public static class LibraryRepositoryExtensions
    {
        public static IServiceCollection AddLibraryRepositoriesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            return services;
        }

        public static IServiceCollection AddInMemoryLibraryDbContext(this IServiceCollection services)
        {
            services.AddDbContext<LibraryDbContext>(opt => opt.UseInMemoryDatabase("InMemoryLibraryDB"));

            var options = new DbContextOptionsBuilder<LibraryDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryLibraryDB")
            .Options;

            using (var context = new LibraryDbContext(options))
            {
                context.Database.EnsureCreated();
            }

            return services;
        }
    }
}
