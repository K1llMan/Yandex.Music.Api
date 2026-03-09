using System;
using System.Collections.Generic;

namespace YandexMusicClient
{
    // Класс для представления пункта меню
    public class MenuItem
    {
        public string Title { get; set; }
        public List<MenuItem> SubItems { get; set; }
        public Action Action { get; set; }
        public MenuItem Parent { get; set; }

        public MenuItem(string title, Action action = null)
        {
            Title = title;
            SubItems = new List<MenuItem>();
            Action = action;
        }

        public bool HasSubItems => SubItems.Count > 0;
        public bool IsBack => Title == "Назад";
    }

    // Основной класс меню
    public class Menu
    {
        private List<MenuItem> _currentItems;
        private int _selectedIndex = 0;
        private MenuItem _currentParent = null;

        // Цветовая схема
        private readonly ConsoleColor _backgroundColor = ConsoleColor.Black;
        private readonly ConsoleColor _foregroundColor = ConsoleColor.White;
        private readonly ConsoleColor _selectedBackgroundColor = ConsoleColor.DarkCyan;
        private readonly ConsoleColor _selectedForegroundColor = ConsoleColor.White;
        private readonly ConsoleColor _borderColor = ConsoleColor.Cyan;

        public Menu(List<MenuItem> rootItems)
        {
            _currentItems = rootItems;
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
                        
                        if (selectedItem.IsBack)
                        {
                            // Возврат к родительскому меню
                            if (_currentParent != null)
                            {
                                _currentItems = _currentParent.Parent?.SubItems ?? GetRootMenu();
                                _currentParent = _currentParent.Parent;
                                _selectedIndex = 0;
                            }
                        }
                        else if (selectedItem.HasSubItems)
                        {
                            // Переход в подменю
                            _currentParent = selectedItem;
                            _currentItems = selectedItem.SubItems;
                            _selectedIndex = 0;
                        }
                        else
                        {
                            // Выполнение действия
                            selectedItem.Action?.Invoke();
                            
                            if (selectedItem.Title == "Выход")
                            {
                                Environment.Exit(0);
                            }
                            
                            Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                            Console.ReadKey(true);
                        }
                        break;
                        
                    case ConsoleKey.Escape:
                        if (_currentParent != null)
                        {
                            // Выход в родительское меню по Escape
                            _currentItems = _currentParent.Parent?.SubItems ?? GetRootMenu();
                            _currentParent = _currentParent.Parent;
                            _selectedIndex = 0;
                        }
                        break;
                }
            }
        }

        private List<MenuItem> GetRootMenu()
        {
            // Поиск корневого меню
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
            string title = "=== СИСТЕМА АВТОРИЗАЦИИ ===";
            Console.ForegroundColor = _borderColor;
            Console.WriteLine(title);
            Console.WriteLine(new string('=', title.Length));
            Console.WriteLine();

            // Хлебные крошки (навигация)
            DrawBreadcrumbs();
            Console.WriteLine();

            // Рисуем меню
            for (int i = 0; i < _currentItems.Count; i++)
            {
                var item = _currentItems[i];
                
                // Визуальный разделитель для пункта "Назад"
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

                // Отступ и маркер выбранного пункта
                string prefix = i == _selectedIndex ? "▶ " : "  ";
                
                // Иконка для подменю
                string suffix = item.HasSubItems ? " ▼" : "";
                
                // Специальный символ для пункта "Назад"
                if (item.IsBack)
                {
                    suffix = " ←";
                }

                Console.WriteLine($"{prefix}{item.Title}{suffix}");
                
                // Сброс цвета
                Console.BackgroundColor = _backgroundColor;
                Console.ForegroundColor = _foregroundColor;
            }

            // Подсказки
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("↑/↓ - навигация | Enter - выбрать | Esc - назад");
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
                Console.WriteLine("Путь: " + string.Join(" → ", breadcrumbs));
                Console.ResetColor();
            }
        }
    }


}