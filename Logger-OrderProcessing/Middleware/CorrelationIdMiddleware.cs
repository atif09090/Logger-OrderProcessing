namespace Logger_OrderProcessing.Middleware
{
    public class CorrelationIdMiddleware
    {
        private const string CorrelationIdHeader = "X-Correlation-ID";
        private readonly RequestDelegate _next;

        public CorrelationIdMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(CorrelationIdHeader, out var correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            context.Items[CorrelationIdHeader] = correlationId;
            context.Response.Headers[CorrelationIdHeader] = correlationId;

            using (Serilog.Context.LogContext.PushProperty("CorrelationId", correlationId))
            {
                await _next(context);
            }
        }
    }
}
