using System.Security.Authentication;
using Yandex.Music.Api.Common.Debug;
using Yandex.Music.Api.Common.Debug.Writer;
using YandexMusicClient.Models;

public class TestAuthApplication
{
    private List<MenuItem> _currentItems;
    private int _selectedIndex;
    private MenuItem? _currentParent;
    private UserSession _session;
    private Stack<string> _navigationHistory = new();
    private Yandex.Music.Client.YandexMusicClient _yandexMusicClient;

    // Цветовая схема
    private readonly ConsoleColor _backgroundColor = ConsoleColor.Black;
    private readonly ConsoleColor _foregroundColor = ConsoleColor.White;
    private readonly ConsoleColor _selectedBackgroundColor = ConsoleColor.DarkCyan;
    private readonly ConsoleColor _selectedForegroundColor = ConsoleColor.White;
    private readonly ConsoleColor _borderColor = ConsoleColor.Cyan;
    private readonly ConsoleColor _successColor = ConsoleColor.Green;
    private readonly ConsoleColor _errorColor = ConsoleColor.Red;
    private readonly ConsoleColor _inputColor = ConsoleColor.Yellow;
    private readonly ConsoleColor _infoColor = ConsoleColor.DarkGray;

    public TestAuthApplication(List<MenuItem> rootItems)
    {
        _currentItems = rootItems;
        _session = new UserSession();
        _yandexMusicClient = new Yandex.Music.Client.YandexMusicClient("d53bbee11acd8f6d6db35c2badb7dd84", new DebugSettings(new DefaultDebugWriter("responses", "log.txt")));
    }

    public void Run()
    {
        Console.CursorVisible = false;

        while (true)
        {
            DrawMenu();

            var key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _selectedIndex = Math.Max(0, _selectedIndex - 1);
                    break;

                case ConsoleKey.DownArrow:
                    _selectedIndex = Math.Min(_currentItems.Count - 1, _selectedIndex + 1);
                    break;

                case ConsoleKey.Enter:
                    var selectedItem = _currentItems[_selectedIndex];

                    if (selectedItem.IsExit)
                    {
                        Environment.Exit(0);
                    }
                    else if (selectedItem.IsBack)
                    {
                        HandleBackNavigation();
                    }
                    else if (selectedItem.Title == "🔑 Войти по логину")
                    {
                        HandleLoginProcess();
                    }
                    else if (selectedItem.HasSubItems)
                    {
                        // Переход в подменю
                        _navigationHistory.Push(_currentParent?.Title ?? "Главное");
                        _currentParent = selectedItem;
                        _currentItems = selectedItem.SubItems;
                        _selectedIndex = 0;
                    }
                    else
                    {
                        // Выполнение действия авторизации
                        bool success = selectedItem.Action?.Invoke(_session) ?? false;

                        if (success)
                        {
                            _session.IsAuthenticated = true;
                            ShowMessage($"✅ Успешная авторизация через {selectedItem.Title}!", _successColor);
                        }
                        else
                        {
                            ShowMessage($"❌ Ошибка авторизации через {selectedItem.Title}!", _errorColor);
                        }

                        ShowContinuePrompt();

                        // Для демонстрации сбрасываем сессию при повторном входе
                        if (!success)
                        {
                            _session.IsAuthenticated = false;
                        }
                    }

                    break;

                case ConsoleKey.Escape:
                    HandleBackNavigation();
                    break;

                case ConsoleKey.F1:
                    ShowHelp();
                    break;
            }
        }
    }

    private void HandleBackNavigation()
    {
        if (_currentParent != null)
        {
            if (_navigationHistory.Count > 0)
                _navigationHistory.Pop();

            _currentItems = _currentParent.Parent?.SubItems ?? GetRootMenu();
            _currentParent = _currentParent.Parent;
            _selectedIndex = 0;
        }
    }

    private void HandleLoginProcess()
    {
        // Шаг 1: Ввод логина
        Console.Clear();
        DrawHeader("🔐 ВХОД В СИСТЕМУ - ШАГ 1/2");

        string login = PromptInput("Введите логин", ValidateLogin);
        _session.Login = login;

        try
        {
            _yandexMusicClient.PassportCreateAuthSession();
            var passportUser = _yandexMusicClient.PassportAuthByUser(login);

            if (passportUser is not null)
            {
                ShowMessage($"✅ Логин принят: {login}", _successColor);
                ShowMessage("Пользователь авторизован", _infoColor);
                ShowMessage($"Доступные методы авторизации: {string.Join(",", passportUser.PreferredAuthMethod)}", _infoColor);
            }
        }
        catch (AuthenticationException e)
        {
            ShowMessage($"❌ Ошибка авторизации: {e.Message}", _errorColor);
        }

        ShowContinuePrompt();

        // Шаг 2: Ввод пароля
        Console.Clear();
        DrawHeader("🔐 ВХОД В СИСТЕМУ - ШАГ 2/2");
        Console.ResetColor();

        // Создаем подменю с методами двухфакторной авторизации
        var twoFactorMenu = new MenuItem($"🔐 2FA для {_session.Login}");
        twoFactorMenu.SubItems.Add(new MenuItem("📨 Войти по Паролю", session =>
        {
            var isauthorized = AuthentificateByPassword(session);

            if (isauthorized)
            {
                CreateAccessToken(session);
                TestAccessToken(session);
            }
            
            return isauthorized;
        }));
        twoFactorMenu.SubItems.Add(new MenuItem("📨 Войти по СМС", session =>
        {
            var isauthorized = AuthentificateBySms(session);
            
            return  isauthorized;
        }));

        twoFactorMenu.SubItems.Add(new MenuItem("◀ Назад"));

        foreach (var item in twoFactorMenu.SubItems)
        {
            item.Parent = twoFactorMenu;
        }

        // Переходим в подменю
        _navigationHistory.Push(_currentParent?.Title ?? "Главное");
        _currentParent = twoFactorMenu;
        _currentItems = twoFactorMenu.SubItems;
        _selectedIndex = 0;
    }

    private string PromptInput(string prompt, Func<string, bool> validator, bool isPassword = false)
    {
        string input = "";
        bool isValid = false;

        while (!isValid)
        {
            Console.ForegroundColor = _inputColor;
            Console.Write($"\n➤ {prompt}: ");
            Console.ResetColor();

            Console.CursorVisible = true;

            if (isPassword)
            {
                // Скрытый ввод пароля
                input = ReadPassword();
            }
            else
            {
                input = Console.ReadLine()?.Trim() ?? "";
            }

            Console.CursorVisible = false;

            if (validator(input))
            {
                isValid = true;
            }
            else
            {
                ShowMessage("❌ Некорректный ввод. Попробуйте снова.", _errorColor);
            }
        }

        return input;
    }

    private string ReadPassword()
    {
        string password = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (keyInfo.Key != ConsoleKey.Enter &&
                     keyInfo.Key != ConsoleKey.Backspace &&
                     !char.IsControl(keyInfo.KeyChar))
            {
                password += keyInfo.KeyChar;
                Console.Write("*");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }

    private bool ValidateLogin(string login)
    {
        if (string.IsNullOrWhiteSpace(login))
        {
            ShowMessage("❌ Логин не может быть пустым", _errorColor);
            return false;
        }

        return true;
    }

    private bool ValidatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            ShowMessage("❌ Пароль не может быть пустым", _errorColor);
            return false;
        }

        if (password.Length < 4)
        {
            ShowMessage("❌ Пароль должен содержать минимум 4 символа", _errorColor);
            return false;
        }

        return true;
    }

    private List<MenuItem> GetRootMenu()
    {
        var item = _currentParent;
        while (item?.Parent != null)
        {
            item = item.Parent;
        }

        return item?.SubItems ?? _currentItems;
    }

    private void DrawMenu()
    {
        Console.Clear();

        // Заголовок
        DrawHeader("🔐 СИСТЕМА ДВУХФАКТОРНОЙ АВТОРИЗАЦИИ");

        // Хлебные крошки
        DrawBreadcrumbs();
        Console.WriteLine();

        // Рисуем меню
        for (int i = 0; i < _currentItems.Count; i++)
        {
            var item = _currentItems[i];

            if (item.IsBack)
            {
                Console.WriteLine();
            }

            if (i == _selectedIndex)
            {
                Console.BackgroundColor = _selectedBackgroundColor;
                Console.ForegroundColor = _selectedForegroundColor;
            }
            else
            {
                Console.BackgroundColor = _backgroundColor;
                Console.ForegroundColor = _foregroundColor;
            }

            string prefix = i == _selectedIndex ? "▶ " : "  ";
            string suffix = item.HasSubItems ? " ▼" : "";

            if (item.IsBack)
            {
                suffix = " ←";
            }

            Console.WriteLine($"{prefix}{item.Title}{suffix}");

            Console.BackgroundColor = _backgroundColor;
            Console.ForegroundColor = _foregroundColor;
        }

        // Подсказки
        Console.WriteLine();
        Console.ForegroundColor = _infoColor;
        Console.WriteLine(new string('─', 60));
        Console.WriteLine("↑/↓ - навигация | Enter - выбрать | Esc - назад | F1 - помощь");
        Console.ResetColor();
    }

    private void DrawHeader(string title)
    {
        Console.ForegroundColor = _borderColor;
        string border = new string('═', title.Length + 4);
        Console.WriteLine($"╔{border}╗");
        Console.WriteLine($"║  {title}  ║");
        Console.WriteLine($"╚{border}╝");
        Console.ResetColor();
    }

    private void DrawBreadcrumbs()
    {
        var breadcrumbs = new List<string>();
        var current = _currentParent;

        while (current != null)
        {
            breadcrumbs.Insert(0, current.Title);
            current = current.Parent;
        }

        if (breadcrumbs.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📂 " + string.Join(" → ", breadcrumbs));
            Console.ResetColor();
        }
        else if (!string.IsNullOrEmpty(_session.Login))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n📂 Главное меню");
            Console.ResetColor();
        }
    }

    private void ShowMessage(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"\n{message}");
        Console.ResetColor();
    }

    private void ShowContinuePrompt()
    {
        Console.ForegroundColor = _infoColor;
        Console.WriteLine("\nНажмите любую клавишу для продолжения...");
        Console.ResetColor();
        Console.ReadKey(true);
    }

    private void ShowHelp()
    {
        Console.Clear();
        DrawHeader("📖 ПОМОЩЬ");

        Console.WriteLine("\n🔹 Навигация:");
        Console.WriteLine("   ↑/↓ - перемещение по меню");
        Console.WriteLine("   Enter - выбор пункта");
        Console.WriteLine("   Esc - возврат в предыдущее меню");
        Console.WriteLine("   F1 - показать эту справку");

        Console.WriteLine("\n🔹 Процесс авторизации:");
        Console.WriteLine("   1. Выберите 'Войти по логину'");
        Console.WriteLine("   2. Введите логин (мин. 3 символа)");
        Console.WriteLine("   3. Введите пароль (мин. 4 символа)");
        Console.WriteLine("   4. Выберите метод двухфакторной авторизации");

        Console.WriteLine("\n🔹 Методы 2FA:");
        Console.WriteLine("   📨 SMS - получение кода по SMS");
        Console.WriteLine("   📧 Email - получение кода на email");
        Console.WriteLine("   📱 QR - сканирование QR-кода");

        Console.ForegroundColor = _infoColor;
        Console.WriteLine("\n" + new string('─', 60));
        Console.WriteLine("Нажмите любую клавишу для возврата в меню...");
        Console.ResetColor();

        Console.ReadKey(true);
    }

    private bool AuthentificateByPassword(UserSession session)
    {
        string inputPassword = PromptInput("Введите пароль", _ => true);
        _session.Password = inputPassword;
        var passwordResponse = _yandexMusicClient.PassportAuthByPassword(inputPassword);

        if (passwordResponse?.State == "rfc_totp")
        {
            ShowMessage($"Необходимо ввести код подтверждения из Я.Ключ для пользователя: {passwordResponse.Account.DisplayLogin}", _infoColor);
            string otpPassword = PromptInput("Введите код из Я.Ключ", _ => true);
            _session.Otp = otpPassword;

            passwordResponse = _yandexMusicClient.PasportSendRfcOtpPassword(otpPassword);

            if (passwordResponse.State == string.Empty)
            {
                try
                {
                    var passportSession = _yandexMusicClient.PassportGetSession();
                    var sessionState = _yandexMusicClient.PassportGetSessionStatus();

                    if (!sessionState.SessionIsCorrect || !sessionState.SessionHasUsers)
                    {
                        ShowMessage($"Ошибка создания сессии для пользователя {_session.Login}", _errorColor);
                        return false;
                    }

                    ShowMessage($"Создана сессия '{passportSession.DefaultUid}' для пользователя: {_session.Login}", _infoColor);
                }
                catch (Exception e)
                {
                    ShowMessage($"Ошибка создания сессии для пользователя {_session.Login}: {e}", _errorColor);
                    return false;
                }
            }
            else
            {
                ShowMessage("Ошибка авторизации по коду", _errorColor);
            }
        }

        return true;
    }

    private bool AuthentificateBySms(UserSession session)
    {
        return false;
    }
    
    private bool AuthenticateWith2FA(UserSession session)
    {
        Console.Clear();

        // Имитация отправки кода
        string code = new Random().Next(100000, 999999).ToString();

        Console.ForegroundColor = _inputColor;
        Console.WriteLine($"📨 Код подтверждения отправлен:");
        //Console.WriteLine($"   {GetMockDestination(method)}");
        Console.ResetColor();
        Console.WriteLine();

        // Запрос кода подтверждения
        Console.Write("➤ Введите полученный код: ");
        Console.CursorVisible = true;
        string inputCode = Console.ReadLine()?.Trim() ?? "";
        Console.CursorVisible = false;

        // Имитация проверки
        bool success = inputCode == code;

        Console.WriteLine();

        if (success)
        {
            // Красивая анимация успеха
            string[] successFrames = { "◴", "◷", "◶", "◵" };
            for (int i = 0; i < 8; i++)
            {
                Console.Write($"\r✅ Проверка кода {successFrames[i % 4]}");
                System.Threading.Thread.Sleep(100);
            }

            Console.ForegroundColor = _successColor;
            Console.WriteLine($"\n\n✅ Двухфакторная авторизация через успешна!");
            Console.WriteLine($"🎉 Добро пожаловать, {session.Login}!");
            Console.ResetColor();

            return true;
        }
        else
        {
            Console.ForegroundColor = _errorColor;
            Console.WriteLine($"❌ Неверный код подтверждения!");
            Console.WriteLine($"   Ожидался: {code}");
            Console.WriteLine($"   Получен:  {inputCode}");
            Console.ResetColor();

            return false;
        }
    }

    private void CreateAccessToken(UserSession session)
    {
        DrawHeader("ПОЛУЧЕНИЕ AccessToken");

        var authToken = _yandexMusicClient.GetTokenBySession();
        session.AccessToken = _yandexMusicClient.GetTokenByAccessToken(authToken).AccessToken;

        ShowMessage("AccessToken получен", _infoColor);
    }

    private void TestAccessToken(UserSession session) 
    {
        DrawHeader("ТЕСТИРОВАНИЕ AccessToken");
        if (_yandexMusicClient.Authorize(session.AccessToken))
        {
            ShowMessage("Пользователь авторизирован", _infoColor);
        }
        else
        {
            ShowMessage("Пользователь не авторизирован", _errorColor);
        }
    }
}