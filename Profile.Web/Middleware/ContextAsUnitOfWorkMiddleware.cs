using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Profile.Web.Middleware
{
    public class ContextAsUnitOfWorkMiddleware<TDbContext> where TDbContext : DbContext
    {
        private readonly RequestDelegate _next;

        public ContextAsUnitOfWorkMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, TDbContext context)
        {
            await _next(httpContext);
            try
            {
                await context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new DbUpdateException(ex.Message, ex);
            }
        }
    }
}