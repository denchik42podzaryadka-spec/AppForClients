# AppForCLients

Client management application built with C# and Entity Framework Core.

## Features
- ✅ Add new clients
- ✅ View all clients
- ✅ Search clients by name (case-insensitive)
- ✅ Delete clients by phone number
- ✅ Automatic database creation on first run

## Technologies
- **Language:** C# (.NET 10)
- **Database:** SQLite
- **ORM:** Entity Framework Core
- **Architecture:** Clean architecture with interfaces

## How to Run
1. Clone the repository
2. Run `dotnet run`
3. Database will be created automatically
4. Follow the menu prompts

## Project Structure
- `Client.cs` - Client entity with validation
- `ClientList.cs` - Business logic for CRUD operations
- `ApplicationContext.cs` - EF Core database context
- `Program.cs` - Application entry point

## What I Learned
- Entity Framework Core migrations
- LINQ queries (Where, FirstOrDefault, Any)
- Using blocks and resource management
- Git version control
- Clean code architecture