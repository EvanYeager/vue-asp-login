

namespace asp_login.Models;

public static class SessionTracker
{
    public static Dictionary<string, SessionModel> Sessions = new();
}