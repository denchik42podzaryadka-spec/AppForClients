using System;
using System.Collections.Generic;
using System.Linq;
class Client
{
   public string Name { get; private set;}
    public string Number { get; private set;}
    public string DateAndClock {get; private set;}
    public Client(string name, string number, string dateAndClock)
    {
        Name = name;
        Number = number;
        DateAndClock = dateAndClock;
    }
}
class ClientList
{
    private List<Client> clients = new List<Client>();
    public void AddCLient(string name, string number, string dateTimeOffset)
    {
        Client peoplesclients= new Client(name, number, dateTimeOffset);
        clients.Add(peoplesclients);
        Console.WriteLine("Клиент добавлен");
    }
    public void ShowAll()
    {
            if (clients.Count == 0)
            {
               Console.WriteLine("Клиентов нет");
                return;
            }
            foreach(Client client in clients)
        {
             Console.WriteLine($"Имя: {client.Name}, Телефон: {client.Number}, Дата: {client.DateAndClock}");
        }
    }
    public void RemoveClient(string number)
    {
        Client foundClient = clients.FirstOrDefault(u => u.Number == number)!;
        if(foundClient != null)
        {
        clients.Remove(foundClient);
        }
        else
        {
            Console.WriteLine("Клиент с таким номером не найден");
        }
    }
}
class Program
{
    public static void Main()
    {
        ClientList manager = new ClientList();
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n --- ЗАПИСЬ КЛИЕНТОВ ---");
            Console.WriteLine("1. -  Добавить клиента");
            Console.WriteLine("2. -  Показать всех");
            Console.WriteLine("3. -  Удалить клиента");
            Console.WriteLine("4. -  Выйти");
            string choice = Console.ReadLine()!;
            if(choice == "1")
            {
                Console.WriteLine("Имя клиента");
                string name = Console.ReadLine()!;
                Console.WriteLine("Номер телефона клиента");
                string number = Console.ReadLine()!;
                Console.WriteLine("Дата и время клиента (например: 2026-06-20 18:00)");
                string dateInput = Console.ReadLine()!;
                manager.AddCLient(name, number, dateInput);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Список клиентов:");
                manager.ShowAll();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Введите номер телефона для удаления");
                string number = Console.ReadLine()!;
                manager.RemoveClient(number);
                Console.WriteLine("Клиент удален");
            }
            else if(choice == "4")
            {
                Console.WriteLine("До свидания!");
                isRunning = false;
            }
            else
            {
              Console.WriteLine("Неверный ввод, попробуйте снова");  
            }
        }
    }
}