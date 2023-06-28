namespace BookShopApp.WebApi.Middleware
{
    public static class CustomExceptionsHandlerMiddlewareExtentions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
