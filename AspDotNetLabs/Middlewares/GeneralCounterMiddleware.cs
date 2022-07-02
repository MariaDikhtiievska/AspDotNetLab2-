using AspDotNetLabs.Services;

namespace AspDotNetLabs.Middlewares
{
    public class GeneralCounterMiddleware
    {
        private readonly RequestDelegate next;

        public GeneralCounterMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, GeneralCounterService generalCounterService)
        {
            generalCounterService.Increment();
            if (httpContext.Request.Path == "/services/general-counter")
            {
                await httpContext.Response.WriteAsync($"generalCounterService: {generalCounterService.Count}");
                return;
            }
            await next.Invoke(httpContext);
        }
    }
}
