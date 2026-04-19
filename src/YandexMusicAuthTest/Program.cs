using YandexMusicAuthTest.Models;

namespace YandexMusicAuthTest;

public static class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Авторизация Яндекс Музыка";
        Console.OutputEncoding = System.Text.Encoding.UTF8;
            
        // Создаем корневое меню (только один пункт)
        List<MenuItem> rootMenu = new();
            
        // Главный пункт меню - вход по логину
        MenuItem passwordMenu = new("🔑 Войти по логину");
        rootMenu.Add(passwordMenu);

        MenuItem smsMenu = new("Войти по номеру телефона");
        rootMenu.Add(smsMenu);

        // Добавляем выход для красоты
        rootMenu.Add(new MenuItem("🚪 Выход", (session) => { Environment.Exit(0); return true; }));
            
        // Запускаем меню
        TestAuthApplication menu = new(rootMenu);
        menu.Run();
    }
}