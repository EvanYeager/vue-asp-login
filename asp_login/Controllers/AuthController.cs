using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        // search up user by username
        // check if password matches
        // manage sign in cookies
        // return Ok();
        bool userExists = model.Username == "evan";
        if (!userExists)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }
        return Ok();
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // manage sign out cookies
        return Ok();
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

