using MediatR;

namespace RedeTestCase.API.Mediator.Base
{
    public abstract class AbstractRequestHandler<T> : IRequestHandler<T, HandleResponse> where T : IRequest<HandleResponse>
    {
        //protected readonly Serilog.ILogger _logger = Serilog.Log.Logger;
        internal abstract HandleResponse HandleIt(T request, CancellationToken cancellationToken);

        public Task<HandleResponse> Handle(T request, CancellationToken cancellationToken)
        {
            //_logger.Information(this.GetType().Name, request, "start request");

            HandleResponse result = new HandleResponse();

            if (object.Equals(request, default(T)))
                return Task.FromResult(result);

            try
            {
                result = HandleIt(request, cancellationToken);

                //_logger.Information(this.GetType().Name, result.Content, "finished request");
            }
            catch (Exception ex)
            {
                //_logger.Error(ex, $"Error in Handler :{typeof(T).Name}Handler");
                throw;
            }

            return Task.FromResult(result);
        }
    }
}
