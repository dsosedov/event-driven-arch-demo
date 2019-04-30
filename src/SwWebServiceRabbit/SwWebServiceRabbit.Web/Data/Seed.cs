using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace SwWebServiceRabbit.Web.Data
{
    public static class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToonContext(serviceProvider.GetRequiredService<DbContextOptions<ToonContext>>()))
            {
                context.Seed();
            }
        }
    }
}
