namespace ClientManager
{
    class ClientList : IClientList
    {
        public void AddCLient(string name, string number, DateTime dateAndClock)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Client peoplesclients = new Client(name, number, dateAndClock);
                // Сохранение
                db.Clients.Add(peoplesclients);
                db.SaveChanges();
            }
        }
        public void ShowAll()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var dbClients = db.Clients.ToList();

                if (dbClients.Any())
                {
                    Console.WriteLine("Клиентов нет");
                    return;
                }
                foreach (Client client in dbClients)
                {
                    Console.WriteLine($"Имя: {client.Name}, Телефон: {client.Number}, Дата: {client.DateAndClock}");
                }
            }
        }
        public void RemoveClient(string number)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var clientToDelete = db.Clients.FirstOrDefault(u => u.Number == number);
                if (clientToDelete != null)
                {
                    db.Clients.Remove(clientToDelete);
                    db.SaveChanges();
                    Console.WriteLine($"{clientToDelete.Name} был(а) удален");
                }
                else
                {
                    Console.WriteLine($"Такого клиента нет ");
                }
            }
        }
        public void FindClient(string name)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var findClient = db.Clients.Where(p => p.Name.ToLower() == name.ToLower()).ToList();
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
}