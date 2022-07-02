using AspDotNetLabs.Services;

namespace AspDotNetLabs.Middlewares
{
    public class TimerMiddleware
    {
        private readonly RequestDelegate next;

        public TimerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, TimerService timerService)
        {
            if(httpContext.Request.Path == "/services/timer")
            {
                await httpContext.Response.WriteAsync($"timerService: {timerService.GetDateTimeNow()}");
                return;
            }
            await next.Invoke(httpContext);
        }
    }
}
