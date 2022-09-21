using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PycApi.BackgroundServices;
using PycApi.Mapper;
using PycApi.RabbitMqServices;
using PycApi.Service;

namespace PycApi.StartUpExtension
{
    public static class ExtensionService
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddHostedService<SendEmailProcessBackgroundService>();
            services.AddControllersWithViews();
            services.AddSingleton<RabbitMQClientService>();
            services.AddSingleton<RabbitMQPublisher>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
