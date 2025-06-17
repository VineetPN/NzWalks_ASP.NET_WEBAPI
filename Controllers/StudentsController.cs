using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace MyApiProjectTest.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase{
        private static string[] names = { "Vineet", "Poorvi",};

        [HttpGet]
        public IActionResult GetNames(){
            return Ok(names);
        }
    }
}