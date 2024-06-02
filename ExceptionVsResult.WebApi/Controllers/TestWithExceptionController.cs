using ExceptionVsResult.WebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionVsResult.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestWithExceptionController(
        IBusinessServiceWithException businessServiceWithException)
        : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(string id)
        {
            var result = await businessServiceWithException.Get(id);
            return Ok(result);
        }
    }
}
