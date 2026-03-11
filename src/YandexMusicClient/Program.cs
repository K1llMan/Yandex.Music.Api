using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using YandexMusicClient.Models;

namespace YandexMusicClient;

public static class Program
{
    static void Main(string[] args)
    {
        JsonSerializerOptions settings = new() {
            Converters = {
                new JsonStringEnumConverter()
            },
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        Console.Title = "Авторизация Яндекс Музыка";
        Console.OutputEncoding = System.Text.Encoding.UTF8;
            
        // Создаем корневое меню (только один пункт)
        var rootMenu = new List<MenuItem>();
            
        // Главный пункт меню - вход по логину
        var loginMenu = new MenuItem("🔑 Войти по логину");
        rootMenu.Add(loginMenu);
            
        // Добавляем выход для красоты
        rootMenu.Add(new MenuItem("🚪 Выход", (session) => { Environment.Exit(0); return true; }));
            
        // Запускаем меню
        var menu = new TestAuthApplication(rootMenu);
        menu.Run();
    }
}