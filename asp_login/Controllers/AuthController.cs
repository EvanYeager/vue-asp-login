using asp_login.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController: ControllerBase
{

    public LoginController LoginController;

    public AuthController() : base()
    {
        LoginController = new LoginController();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        bool userExists = LoginController.CredentialsMatch(model);
        if (!userExists)
        {
            return StatusCode(StatusCodes.Status401Unauthorized);
        }

        string? uid = LoginController.Login(model);

        return Ok(uid);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] string uid)
    {
        if (!SessionTracker.Sessions.ContainsKey(uid))
        {
            return StatusCode(StatusCodes.Status304NotModified);
        }

        string body = SessionTracker.Sessions[uid].Username + " is now logged out.";
        LoginController.Logout(uid);
        return Ok(body);
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
        return Ok();
    }
}

