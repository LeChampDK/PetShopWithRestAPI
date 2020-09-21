using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;

namespace PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.StartUI();
        }
    }
}
