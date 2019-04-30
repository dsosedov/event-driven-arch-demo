using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SithWebSerivce.Web.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SithContext(serviceProvider.GetRequiredService<DbContextOptions<SithContext>>()))
            {
                context.Seed();
            }
        }
    }
}
