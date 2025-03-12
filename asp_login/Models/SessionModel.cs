

namespace asp_login.Models;

public class SessionModel
{
    public string Username { get; set; }
    public string[]? Coordinates { get; set; }

    public SessionModel(string username, string[]? coordinates)
    {
        Username = username;
        Coordinates = coordinates;
    }
}