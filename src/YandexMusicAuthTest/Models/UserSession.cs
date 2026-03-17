namespace YandexMusicAuthTest.Models;

public class UserSession
{
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsAuthenticated { get; set; }
    public string Otp { get; set; }
    public string AccessToken { get; set; }
}