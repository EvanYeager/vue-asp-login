using asp_login.Models;
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
        Credentials credentials = new Credentials();
        bool userExists = credentials.Users.ContainsKey(model.Username) && credentials.Users[model.Username] == model.Password;
        if (!userExists)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }

        SessionModel session = new SessionModel(model.Username, new string[] { "coord1", "coord2" });
        HttpContext.Session.SetObject("test session", session);

        SessionService.AddSession(session);

        return Ok(session);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        // manage sign out cookies
        String body = "logging out user " + HttpContext.Session.GetString("username") + "\n" + HttpContext.Session.GetString("test session");
        return Ok(body);
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

