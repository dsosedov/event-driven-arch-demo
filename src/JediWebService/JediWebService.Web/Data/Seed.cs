using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JediWebService.Web.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JediContext(serviceProvider.GetRequiredService<DbContextOptions<JediContext>>()))
            {
                context.Seed();
            }
        }
    }
}
