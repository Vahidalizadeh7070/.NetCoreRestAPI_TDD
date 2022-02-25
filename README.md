# .NetCoreRestAPI_TDD
This repository includes a rest API which is implemented by .net core and TDD.

<h2>What is TDD</h2>
TDD is a software development process being converted to test cases before the software is fully developed.

There are 2 projects in this repository that one of those is a REST Api and the another is a test project.
<h3>REST Api</h3>
This API is implemented by .Net core API and it is implemented by Entity framework Core. The main section of this API is the repository pattern which is responsible for the CRUD operation. AutoMapper is another package that we have used in this REST API which maps all Dtos to concrete class and then we can send the map object to the repository to proceed with the CRUD operation. In addition, we have used the MVC design pattern in the REST API. It can provide a lot of capabilities in an API such as Authentication and Authorization and You can manage each section of your API in the easiest way. Eventually, we have considered InMemoryDatabase to do the CRUD operation and use Postman to test the API, altough the Swagger has been added in the <code>Startup.cs</code>.
<h5>Packages in used</h5>

- AutoMapper : <code>Install-Package AutoMapper -Version 11.0.1</code>
- Entityframework Core : <code>Install-Package Microsoft.EntityFrameworkCore -Version 5.0.1</code>
- Entityframework Core Design : <code>Install-Package Microsoft.EntityFrameworkCore.Design -Version 5.0.1</code>
- Entityframework Core InMemory : <code>Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 5.0.1</code>
- Entityframework Core Tools : <code>Install-Package Microsoft.EntityFrameworkCore.Tools -Version 5.0.1</code>

<hr/>

<h3>Unit Testing </h3>
The unit testing is implemented by xUnit tool. In this testing, all the actions that are implemented in REST API will be tested. Moreover, we have used dummy data to the CRUD operation based on those values, in other words, those values illustrate the context and through the CRUD operation we can modify it. Finally, as we used InMemoryDatabase in the REST API, we can use it in the unit testing and the other considerable tool that we have used is AutoMapper which helps us to map the object to the valid object and then send it to the API.

<h5>Packages in used</h5>
- AutoMapper : <code>Install-Package AutoMapper -Version 11.0.1</code>
- Entityframework Core InMemory : <code>Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 5.0.1</code>
- Fluent Assertions : <code>Install-Package FluentAssertions -Version 6.5.1</code>
- xUnit : <code>Install-Package xunit -Version 2.4.2-pre.12</code>
