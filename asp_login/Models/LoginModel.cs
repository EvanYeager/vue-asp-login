using System.ComponentModel.DataAnnotations;

public class LoginModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }

    public LoginModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}