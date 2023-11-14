# TodoApp
First backend REST project in C# and ASP.NET to learn about basics of .NET platform and fundamentals like `connecting to database`, launch `EF Core ORM` and so on.


### In case you use Visual Studio Code and want to run this project
https://code.visualstudio.com/docs/languages/dotnet#_setting-up-vs-code-for-net-development

This docs contain a must-have extensions:
- `C# Extension`,
- `C# Dev Kit extension`

Also you'll need the `.NET SDK`.
Everything is in docs linked above.

### Steps to run a project in Visual Studio Code

1. Clone repository with `git clone` command,
2. Open folder with `.sln` file inside your editor,
3. Use `dotnet restore` command to install required packages,
4. Use `dotnet build` command,
5. Run application with `dotnet watch` command.


### Connecting to database

1. Install `docker` and `DBeaver` or another SQL client software on your machine (I'm using `DBeaver`),
2. Run docker container with `docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest` command,
3. Create new connection inside `DBeaver`. If you have problems with connecting `SQL server` inside docker with SQL client software, check this guide: https://www.youtube.com/watch?v=TUWItrX7hmA
4. If you want create new migrations files, run `dotnet ef migrations add <migration-name>` command,
5. Run `dotnet ef database update` command. After that your database should contain declared models inside app.

### Application Content

It's simple `CRUD` application with saving data to` database`. As a database I use `SQL Server` inside `docker container`. 

### Routes
| Route | Method | Description|
| ----------- | ----------- | ----------- |
| /api/Todos/GetAll | GET | Get list of Todo Items 
| /api/Todos/{id} | GET | Get single Todo Item
| /api/Todos/{id} | DELETE | Delete single Todo Item
| /api/Todos/ | POST | Add single Todo Item
| /api/Todos/ | PUT | Fully update given Todo Item

