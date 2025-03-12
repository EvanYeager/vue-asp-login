

namespace asp_login.Models;

public static class SessionService
{
    public static string AddSession(SessionModel sessionModel)
    {
        // do i need to check if the session already exists? or do i enforce that in the frontend
        string guidString = Guid.NewGuid().ToString();
        SessionTracker.Sessions.Add(guidString, sessionModel);
        return guidString;
    }

    public static void RemoveSession(string key)
    {
        SessionTracker.Sessions.Remove(key);
    }
}