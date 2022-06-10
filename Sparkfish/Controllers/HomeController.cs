using Microsoft.AspNetCore.Mvc;
using Sparkfish.Services;

namespace Sparkfish.Controllers
{
    /// <summary>
    /// The controller is tightly coupled to the Listify object.
    /// </summary>
    [ApiController]
    [Route("listify")]
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
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpGet("{begin}/{end}/{index}")]
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
