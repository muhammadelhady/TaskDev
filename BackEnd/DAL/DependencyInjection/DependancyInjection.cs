using DAL.Data;
using DAL.Repos.Implementation;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DependencyInjection
{
    public static class DependancyInjection
    {
        public static void DAL_DI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<DataContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), m => m.MigrationsAssembly("DAL"));
            });

            services.AddScoped<ICustomerRepo, CustomerRepo>();
            services.AddScoped<IStoreRepo, StoreRepo>();
            services.AddScoped<IUnitRepo, UnitRepo>();
            services.AddScoped<IItemRepo, ItemRepo>();
            services.AddScoped<IInvoiceRepo, InvoiceRepo>();



        }
    }
}
