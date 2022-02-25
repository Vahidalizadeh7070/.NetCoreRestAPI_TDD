# .NetCoreRestAPI_TDD
This repository includes a rest API which is implemented by .net core and TDD.

There are 2 projects in this repository that one of those is a REST Api and the another is a test project.
<h3>REST Api</h3>
This API is implemented by .Net core API and it is implemented by Entity framework Core. The main section of this API is the repository pattern which is responsible for the CRUD operation. AutoMapper is another package that we have used in this REST API which maps all Dtos to concrete class and then we can send the map object to the repository to proceed with the CRUD operation. In addition, we have used the MVC design pattern in the REST API. It can provide a lot of capabilities in an API such as Authentication and Authorization and You can manage each section of your API in the easiest way. Eventually, we have considered InMemoryDatabase to do the CRUD operation and use Postman to test the API, altough the Swagger has been added in the <code>Startup.cs</code>.
<h5>Packages in used</h5>
- AutoMapper : Install-Package AutoMapper -Version 11.0.1
- Entityframework Core : Install-Package Microsoft.EntityFrameworkCore -Version 5.0.1
- Entityframework Core Design : Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.1
- Entityframework Core InMemory : Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 5.0.1
- Entityframework Core Tools : Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.1

