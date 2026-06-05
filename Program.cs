using Microsoft.EntityFrameworkCore;
using System;
namespace ClientManager
{
    class Program
    {
        public static void Main()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.Migrate();
            }
            ClientList manager = new ClientList();
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("\n --- ЗАПИСЬ КЛИЕНТОВ ---");
                Console.WriteLine("1. -  Добавить клиента");
                Console.WriteLine("2. -  Показать всех");
                Console.WriteLine("3. -  Удалить клиента");
                Console.WriteLine("4. -  Найти клиента");
                Console.WriteLine("5. - Выйти");
                Console.Write("Выберите пункт меню: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Ошибка! Введите число от 1 до 5.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Имя клиента:");
                        string name = Console.ReadLine()!;

                        Console.WriteLine("Номер телефона клиента:");
                        string number = Console.ReadLine()!;

                        Console.WriteLine("Дата и время клиента (например: 2026-06-20 18:00):");
                        string dateInput = Console.ReadLine()!;

                        if (DateTime.TryParse(dateInput, out DateTime result))
                        {
                            DateTime utcResult = DateTime.SpecifyKind(result, DateTimeKind.Utc);
                            manager.AddCLient(name, number, utcResult);

                        }
                        else
                        {
                            Console.WriteLine("Ошибка! Неверный формат даты. Клиент не добавлен.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Список клиентов:");
                        manager.ShowAll();
                        break;

                    case 3:
                        Console.WriteLine("Введите номер телефона для удаления:");
                        string number1 = Console.ReadLine()!;
                        manager.RemoveClient(number1);
                        break;

                    case 4:
                        Console.WriteLine("Введите имя клиента:");
                        string name1 = Console.ReadLine()!;
                        manager.FindClient(name1);
                        break;

                    case 5:
                        Console.WriteLine("До свидания!");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}