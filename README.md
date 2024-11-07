# SETUP

Required tools:
- [Visual Studio Community Edition 2022](https://visualstudio.microsoft.com/vs/community/)
- [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)

## Build

Once all tools are installed, you need to set a *User Environment Variable* `POSTGRES_PASSWORD` that contains your password to the `postgres` user on your database

You can build the database from the SQL file `HackathonTest.sql`, please update it when changing the database

Then you can run this command in the *Package Manager Console* of *Visual Studio* to scaffold the database.
```PowerShell
Scaffold-DbContext -Connection "Database=HackathonTest;Username=postgres;Host=127.0.0.1;Password=$env:POSTGRES_PASSWORD;Persist Security Info=True" -Namespace HackathonTest.Entities -OutputDir Entities -Context HackathonTestContext -ContextDir Database -ContextNamespace HackathonTest.Database -Force -Provider Npgsql.EntityFrameworkCore.PostgreSQL
```

## Export the database

Right click `HackathonTest > Backup`:
- In `General > Format` enter *Plain*
- In `Data Options > Only schemas` ensure *Checked*

### Common error

If you get the [following error](https://github.com/pgadmin-org/pgadmin4/issues/7969#issuecomment-2378481828):
```
pg_dump: error: aborting because of server version mismatch
pg_dump: detail: server version: 17.0; pg_dump version: 16.4
```

In `File > Preferences > Paths > Binary Paths > PostgreSQL Binary Path` check *PostgreSQL 17* and enter `C:\Program Files\PostgreSQL\17\bin`
