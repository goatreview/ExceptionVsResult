using ExceptionVsResult.WebApi.Exceptions;
using LanguageExt.Common;

namespace ExceptionVsResult.WebApi.Services
{
    public class BusinessServiceWithResult : IBusinessServiceWithResult
    {
        public async Task<Result<string>> Get(string id)
        {
            await Task.CompletedTask;
            
            if (string.Compare("HasValue", id, StringComparison.CurrentCultureIgnoreCase) == 0)
                return id + " success";
                
            var notFoundException = new NotFoundException(id);
            return new Result<string>(notFoundException);
        }
    }

    public interface IBusinessServiceWithResult
    {
        Task<Result<string>> Get(string id);
    }
}
