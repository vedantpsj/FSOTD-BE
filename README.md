# Users

Foobar is a .NET(6.0) WEB API project to perform basic CRUD operations on user database.

## Prerequisite

1. Visual studio
2. Postgresql Database

## Create a project

1. Create a project using visual studio.
2. Select ASP.NET CORE API template from the templates.

## Installing packages

1. Go to projects
2. Go to Manage Nuget Packages
3. Add following packages

```bash
Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.tools
Microsoft.EntityFrameworkCore.
Microsoft.EntityFrameworkCore.SqlServer
Npgsql.EntityFrameworkCore.PostgreSQL
```

## Connect to database

1. Generate connection string for the database and add to appsettings.json

```bash
 {
   ...
   "ConnectionStrings": {
    "userConnectionString": "server=127.0.0.1;port=5432;user id=newuser;password=password;database=postgres"
    },
}
```

2. Create a model for user.
3. Create a context for user.
4. Connection to database

## Run migrations

1. Create migration.
   Go to root of the project in terminal and run the following command.

```bash
 dotnet ef migrations add XXX
```

2. Run Db migration

```bash
dotnet ef database update
```

## Create Controller

Create a Controller folder, and add a UserController.cs file

Create endpoints and functions which are required in this file.

I have added 4 CRUD operations

1. Get users

```bash
GET /user
```

2. Get Specific user based on id

```bash
GET /user/${id}
```

3. Add a user

```bash
POST /user
```

4. Update a user

```bash
PUT /user/${id}
```

5. Delete a user

```bash
DELETE /user/${id}
```
