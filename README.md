# SETUP

Required tools:
- [Visual Studio Community Edition 2022](https://visualstudio.microsoft.com/vs/community/)
- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

Once all tools are installed, you need to set a *User Environment Variable* `POSTGRES_PASSWORD` that contains your password to the `postgres` user on your database

You can build the database from the SQL file `HackathonTest.sql`, please update it when changing the database

Then you can run this command in the *Package Manager Console* of *Visual Studio* to scaffold the database.
```PowerShell
Scaffold-DbContext -Connection "Database=HackathonTest;Username=postgres;Host=127.0.0.1;Password=$env:POSTGRES_PASSWORD;Persist Security Info=True" -Namespace HackathonTest.Entities -OutputDir Entities -Context HackathonTestContext -ContextDir Database -ContextNamespace HackathonTest.Database -Force -Provider Npgsql.EntityFrameworkCore.PostgreSQL
```