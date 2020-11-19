using Library.Services;
using Library.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Utils.Extensions
{
    public static class LibraryServiceExtensions
    {
        public static IServiceCollection AddLibraryServicesDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            

            return services;
        }
    }
}
