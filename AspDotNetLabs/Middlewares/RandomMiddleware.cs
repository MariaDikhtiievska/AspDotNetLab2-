using AspDotNetLabs.Services;

namespace AspDotNetLabs.Middlewares
{
    public class RandomMiddleware
    {
        private readonly RequestDelegate next;

        public RandomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, RandomService randomService1, RandomService randomService2)
        {
            if (httpContext.Request.Path == "/services/random")
            {
                await httpContext.Response.WriteAsync($"randomService1: {randomService1.Value}, randomService2: {randomService2.Value}");
                return;
            }
            await next.Invoke(httpContext);
        }
    }
}
