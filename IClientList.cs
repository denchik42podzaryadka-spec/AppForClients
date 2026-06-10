interface IClientList
{
    void AddClient(string name, string number, DateTime dateTimeOffset);
    void ShowAll();
    void RemoveClient(string number);
    void FindClient(string name);
}