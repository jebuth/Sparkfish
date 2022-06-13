using Microsoft.AspNetCore.Mvc;
using Sparkfish.Services;

namespace Sparkfish.Controllers
{
    /// <summary>
    /// The controller is tightly coupled to the Listify object.
    /// </summary>
    [ApiController]
    public class HomeController : Controller
    {
        private ILogger<HomeController> logger;
        private readonly IListify service;

        public HomeController(ILogger<HomeController> _logger, IListify _service)
        {
            logger = _logger;
            service = _service;
        }

        /// <summary>
        /// Return a value at the provided index within a range.
        /// </summary>
        /// <param name="begin">Begininning of the range (inclusive).</param>
        /// <param name="end">End of the range (inclusive).</param>
        /// <param name="index">Target index to access.</param>
        /// <returns>The value of the element at index.</returns>
        [HttpGet("listify/{begin}/{end}/{index}")]
        public IActionResult Index(int begin, int end, int index)
        {
            try
            {
                // "given a list of numbers ranging from 100 to 200"
                var myList = service.Create(begin, end);

                // "When I access index position 50"
                var target = myList[index];

                return Ok(target);
            }
            catch (Exception ex)
            {
                // log error
                logger.LogCritical($"{DateTime.UtcNow}" + 
                    System.Environment.NewLine + 
                    Request.Host + 
                    System.Environment.NewLine + ex.Message);

                return StatusCode(500, "sorry..");
            }
        }
    }
}
