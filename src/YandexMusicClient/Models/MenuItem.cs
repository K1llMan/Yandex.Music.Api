namespace YandexMusicClient.Models;

public class MenuItem
{
    public string Title { get; set; }
    public List<MenuItem> SubItems { get; set; }
    public Func<UserSession, bool> Action { get; set; } // Функция принимает сессию пользователя
    public MenuItem Parent { get; set; }
    public bool RequiresLogin { get; set; } // Требуется ли ввод логина перед показом

    public MenuItem(string title, Func<UserSession, bool> action = null, bool requiresLogin = false)
    {
        Title = title;
        SubItems = new List<MenuItem>();
        Action = action;
        RequiresLogin = requiresLogin;
    }

    public bool HasSubItems => SubItems.Count > 0;
    public bool IsBack => Title == "Назад";
    public bool IsExit => Title == "Выход";
}