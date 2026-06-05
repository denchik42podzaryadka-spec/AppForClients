using System;
interface IClientList
{
    void AddCLient(string name, string number, DateTime dateTimeOffset);
    void ShowAll();
    void RemoveClient(string number);
    void FindClient(string name);
}