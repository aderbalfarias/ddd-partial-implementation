# DDDExample

This repository contains a basic example to implement the methodology of project Domain Driven Design (DDD) with some Technologies like:
- C#
- ASP.NET MVC 5
- Entity Framework 6
- CodeFirst
- Dependency Injection (IoC)
- Application in layers
- Ninject as container of IoC
- FluentApi
- AutoMapper
- Linq Lambda Expressions

## Configuration

For this project to work on your machine, you have to replace the line below on file Web.config.

```xml
<add name="Connection" connectionString="Data Source=yourserver; initial catalog=DbExample;user id=youruser;password=yourpassword;" providerName="System.Data.SqlClient" />
```
You have to replace these words:<br />
**yourserver:** server name where the application will create the database<br />
**youruser:** your username to access the server<br />
**yourpassword:** your password to access the server<br />

The application contains an initialization file that will create the default user.<br />
**User: admin**<br />
**Password: 123456**<br />

If you want, you can configure SMTP server to send email on file Web.config as well in these keys.

```xml
<add key="SMTPServer" value="Server" />
<add key="SMTPPort" value="25" />
<add key="SMTPUser" value="user" />
<add key="SMTPPassword" value="password" />
<add key="SMTPDomain" value="domain" />
```
