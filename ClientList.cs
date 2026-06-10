using Microsoft.EntityFrameworkCore;
namespace ClientManager
{
    class ClientList : IClientList
    {
        private readonly ApplicationContext _db;
        public ClientList(ApplicationContext db)
        {
            _db = db;
        }
        public void AddCLient(string name, string number, DateTime dateAndClock)
        {
            Client peoplesclients = new Client(name, number, dateAndClock);
            // Сохранение
            _db.Clients.Add(peoplesclients);
            _db.SaveChanges();
        }
        public void ShowAll()
        {
            var dbClients = _db.Clients.ToList();

            if (!dbClients.Any())
            {
                Console.WriteLine("Клиентов нет");
                return;
            }
            foreach (Client client in dbClients)
            {
                Console.WriteLine($"Имя: {client.Name}, Телефон: {client.Number}, Дата: {client.DateAndClock}");
            }
        }
        public void RemoveClient(string number)
        {
            var clientToDelete = _db.Clients.FirstOrDefault(u => u.Number == number);
             if (clientToDelete != null)
            {
                _db.Clients.Remove(clientToDelete);
                _db.SaveChanges();
                Console.WriteLine($"{clientToDelete.Name} был(а) удален");
            }
            else
            {
                Console.WriteLine($"Такого клиента нет ");
            }
        }
        public void FindClient(string name)
        {
            var findClient = _db.Clients
            .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
            .ToList();
            if (!findClient.Any())
            {
                Console.WriteLine($"Клиентов с таким именем нет");
                return;
            }
            foreach (var client in findClient)
            {
                Console.WriteLine($"Имя : {client.Name} | Телефон : {client.Number} | Дата : {client.DateAndClock}");
            }
        }
    }
}