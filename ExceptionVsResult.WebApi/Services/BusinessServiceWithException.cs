using ExceptionVsResult.WebApi.Exceptions;

namespace ExceptionVsResult.WebApi.Services
{
    public class BusinessServiceWithException : IBusinessServiceWithException
    {
        public async Task<string> Get(string id)
        {
            await Task.CompletedTask;
            
            if (string.Compare("HasValue", id, StringComparison.CurrentCultureIgnoreCase) == 0)
                return id + " success";
            
            var notFoundException = new NotFoundException(id);
            throw notFoundException;
        }
    }

    public interface IBusinessServiceWithException  
    {
        Task<string> Get(string id);
    }
}
