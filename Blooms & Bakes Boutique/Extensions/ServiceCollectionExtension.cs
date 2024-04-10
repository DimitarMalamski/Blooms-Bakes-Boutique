﻿using Blooms___Bakes_Boutique.Core.Contracts.Florist;
using Blooms___Bakes_Boutique.Core.Contracts.Flower;
using Blooms___Bakes_Boutique.Core.Contracts.Pastry;
using Blooms___Bakes_Boutique.Core.Contracts.Patissier;
using Blooms___Bakes_Boutique.Core.Services.Florist;
using Blooms___Bakes_Boutique.Core.Services.Flower;
using Blooms___Bakes_Boutique.Core.Services.Pastry;
using Blooms___Bakes_Boutique.Core.Services.Patissier;
using Blooms___Bakes_Boutique.Infrastructure.Data;
using Blooms___Bakes_Boutique.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPastryService, PastryService>();
            services.AddScoped<IFlowerService, FlowerService>();
            services.AddScoped<IPatissierService, PatissierService>();
            services.AddScoped<IFloristService, FloristService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<BloomsAndBakesDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IRepository, Blooms___Bakes_Boutique.Infrastructure.Data.Common.Repository>();

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddDefaultIdentity<IdentityUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;

                })
                .AddEntityFrameworkStores<BloomsAndBakesDbContext>();

            return services;
        }
    }
}

