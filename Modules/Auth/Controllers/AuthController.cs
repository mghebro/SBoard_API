using Microsoft.AspNetCore.Mvc;

namespace SBoard.Modules.Auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet()] // დაუწერეთ რას აბრუნებთ რო Front-end - მა იცოდეს გამოძახების გარეშე
        public ActionResult<String> Get()
        {
            return Ok("Hello World!");
        }
    }
}