using ExceptionVsResult.WebApi.Exceptions;
using ExceptionVsResult.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExceptionVsResult.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestWithResultController(
        IBusinessServiceWithResult businessServiceWithResult)
        : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            var result = await businessServiceWithResult.Get(id);
            return result.Match<ActionResult<string>>(success=> Ok(success),
                failure =>
                {
                    return failure switch
                    {
                        NotFoundException notFoundException => StatusCode((int)HttpStatusCode.NotFound,
                            new { message = notFoundException.Message }),
                        _ => StatusCode((int)HttpStatusCode.InternalServerError,
                            new { message = "Internal Server Error" })
                    };
                }
            );
        }
    }
}
