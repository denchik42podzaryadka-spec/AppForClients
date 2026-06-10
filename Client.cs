namespace ClientManager
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; private set; } = null!;
        public string Number { get; private set; } = null!;
        public DateTime DateAndClock { get; private set; }
        public Client(string name, string number, DateTime dateAndClock)
        {
            UpdateName(name);
            UpdateNumber(number);
            DateAndClock = dateAndClock;
        }
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Имя не может быть пустым.");
            Name = newName;
        }
        public void UpdateNumber(string newNumber)
        {
            if (string.IsNullOrWhiteSpace(newNumber) || newNumber.Length < 5)
                throw new ArgumentException("Некорректный формат номера телефона.");
            Number = newNumber;
        }
    }
}