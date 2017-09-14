# DDDExample

This repository contains a basic example to implement the methodology of project Domain Driven Design (DDD) with some Technologies like:
- ASP.NET MVC 5
- C#
- Entity Framework 6 CodeFirst
- Dependency Injection (IoC)
- Application in layers
- Ninject as container of IoC
- FluentApi
- AutoMapper

## Configuration

For this project to work on your machine, you have to replace the line below.

```xml
<add name="Connection" connectionString="Data Source=yourserver; initial catalog=DbExample;user id=youruser;password=yourpassword;" providerName="System.Data.SqlClient" />
```
You have to replace these words:<br />
**yourserver:** server name where the application will create the database<br />
**youruser:** your username to access the server<br />
**yourpassword:** your password to access the server<br />