

namespace asp_login.Models;

public class LoginController
{
    private Credentials Credentials;
    
    public LoginController() 
    {
        Credentials = new Credentials();
    }

    public bool CredentialsMatch(LoginModel user)
    {
        return Credentials.Users.ContainsKey(user.Username) && Credentials.Users[user.Username] == user.Password;
    }

    public string? Login(LoginModel user)
    {
        if (CredentialsMatch(user))
        {
            SessionModel session = new SessionModel(user.Username, null);
            string uid = SessionService.AddSession(session);
            return uid;
        }
        return default;
    }

    public void Logout(string sessionKey)
    {
        SessionService.RemoveSession(sessionKey);
    }
}