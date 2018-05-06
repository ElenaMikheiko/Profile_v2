using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

namespace Profile.Web.Middleware
{
    public static class ContextAsUnitOfWorkExtensions
    {
        public static IApplicationBuilder UseContextAsUnitOfWork<TDbContext>(this IApplicationBuilder builder) where TDbContext : DbContext
        {
            return builder.UseMiddleware<ContextAsUnitOfWorkMiddleware<TDbContext>>();
        }
    }
}
