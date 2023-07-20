using MediatR;
using Serilog;

namespace BookShopApp.Application.Behaivvors
{
    public class LoggingBehavor<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse> where TRequest
        : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request,
            RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            Log.Information("BookShopApp Request: {Name} {@Request}",
                requestName, request);

            var responce = await next();

            return responce;
        }
    }
}
