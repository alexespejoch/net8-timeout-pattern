# Implementación del Patrón Timeout en ASP.NET Core 8

El objetivo de este proyecto es proporcionar un ejemplo sobre la implementación del patrón timeout en aplicaciones ASP.NET Core 8 con un enfoque sencillo y aprovechando el poder de Clean Architecture y ASP.NET Core. Con este ejemplo puede implementar el patrón timeout en cualquier tipo de proyecto ASP.NET Core 8 (Api Mínima, Api Web con Controladores, MVC & Razor Pages).

Los detalles los encuentra a continuación ...

Si este proyecto te resulta útil, regálame una estrella. ¡Gracias! ⭐

## Requisitos
Se requieren los siguientes requisitos para compilar y ejecutar la solución:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (última versión)
- [MSSQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) (2019 o superior)

## Base de datos
La aplicación está configurada para utilizar MSSQL Server de forma predeterminada.

Cuando ejecute la aplicación, la base de datos se creará automáticamente (si es necesario) y se aplicarán las migraciones más recientes.

La ejecución de migraciones de bases de datos es sencilla. Asegúrese de agregar los siguientes indicadores a su comando (los valores suponen que está ejecutando desde la raíz de la solución.

Por ejemplo, para agregar una nueva migración desde la carpeta raíz:

`dotnet ef migrations add CreateInitialScheme -s src\BookStore.WebApi -p src\BookStore.Infrastructure -o Migrations`

`dotnet ef database update -s src\BookStore.WebApi -p src\BookStore.Infrastructure`

Para insertar datos pueden apoyarse del script ubicado en el direcorio scripts\data.sql

## Tecnologías

* [ASP.NET Core 8](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core)
* [Entity Framework Core 8](https://docs.microsoft.com/en-us/ef/core/)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)

## Learn More

* [Arquitectura de Aplicaciones Empresariales con .NET 8](https://www.udemy.com/course/arquitectura-aplicaciones-empresariales-con-net-core/?referralCode=BB6711C3FB50C5DEF33A)
* [Diseño y Construcción de Microservicios .NET 8 utilizando gRPC](https://www.udemy.com/course/microservices-net-grpc/?referralCode=DECDB75CE566EF488A25)
* [Observabilidad de Microservicios .NET 8 utilizando OpenTelemetry](https://www.udemy.com/course/opentelemetry/?referralCode=53504360A5755DCCFD8C)
  
## Licencia

This project is licensed with the [MIT license](LICENSE).
