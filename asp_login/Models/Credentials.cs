

namespace asp_login.Models;

public class Credentials 
{
    public Dictionary<string, string> Users { get; set; } = new Dictionary<string, string>
    {
        {"admin", "admin"},
        {"evan", "password"}
    };
}