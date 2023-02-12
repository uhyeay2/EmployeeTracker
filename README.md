# EmployeeTracker

ASP.Net Core Application for tracking Employee Metrics such as Attendance/Performance

## Contents
* [Overview](https://github.com/uhyeay2/EmployeeTracker/blob/main/README.md#overview)
* [Architecture](https://github.com/uhyeay2/EmployeeTracker/blob/main/README.md#architecture)
* [Testing](https://github.com/uhyeay2/EmployeeTracker/blob/main/README.md#Testing)
* [Technologies/Highlights](https://github.com/uhyeay2/EmployeeTracker/blob/main/README.md#technologieshighlights)

## Overview

This is a Domain Driven Design project created using Clean Architecture. Different layers are separated into their own projects with the Domain layer residing in the center. 

The Data Layer of this application utilizes Dapper, with my own pattern for abstracting/wrapping the Dapper Dependency. This pattern does not use the commonly known Repository Pattern, but instead makes use of a 'DataAccess' class that can execute any DataRequest.

This project also makes use of the MediatR Nuget Package, allowing for easier use of the Mediator Pattern. I found that this design pattern flows very well with the pattern I created for Dapper in this project.

Unit Testing is done with Moq using xUnit Test Projects. Shouldly is another Nuget package used in the testing projects to enhance readability with easier to read assertions. 

## Architecture

Architecture is something that I've always found to be an important part of an application. Ever since I first learned about Clean Architecture I've strived to implement it in all of my personal projects. It was a no brainer for me that I'd use Clean Architecture for this application.

As Part of using Clean Architecture, the Domain Project resides at the center of my application. However I also have several other Layers/Ports that are used as well. Here's a breakdown of the Projects in this application and their responsibilities.

- EmployeeTracker.Domain
  - This Class Library is the core of the application, the Domain is responsible for housing Domain objects/logic.
  - Some examples of Domain objects found here are the Employee and Department classes.
  - Domain objects do not expose details that should not be given to the user such as Table Id's
- EmployeeTracker.Database
  - This SqlServer project is used to track the history of and deploy changes to the Sql Server Database.
  - Changes for the Database are made here, then published to the Sql Sever Database through Visual Studios.
- EmployeeTracker.Data
  - This Class Library is responsible for accessing the Database via the Dapper ORM.
  - All DataRequests are handled via a class called DataAccess
  - Since Queries/Commands are RequestObjects they are easily reusable without repeated SQL everywhere!
  - Sql Generation included for simple SQL requests
- EmployeeTracker.Mediator
  - This Class Library utilizes the MediatR Nuget Package to introduce the Mediator Pattern.
  - PipeLine Behavior created to handle Validation using my own IValidatable interface.
  - Handlers are encapsulated internally so that consumers can only see the Mediator Request Objects
- EmployeeTracker.Api
  - Still in development
  
### EmployeeTracker.Domain

Since this project is using Clean Architecture the domain is a vital part of the application. Here there are no dependencies on other projects, instead all the other projects depend inwards on the Domain. 

The objects housed in the Domain do not disclose details from the data layer that should not be given to the user. For example the Employee object from the Domain Layer does not include a DepartmentId. Instead the Employee object includes a Department object which has only the Department Code/Name.

The Domain also houses interfaces that are applicable accross the application. For example, my IValidatable interface is utilized for Validation Handling in the Mediator Layer - however I could reuse this same interface for validation handling in the Api layer. Additionally the IConfig allows me to fetch configuration data which is definitely applicable across different layers of the application.

### EmployeeTracker.Database

The database is an important part of the application - after all this is where all the data is stored. Thankfully if you want to clone this project you won't have to try hard to get your Database set up. Since I use this Sql Server Database Project to manage my Database, you already have everything you need to get started.

By simply Publishing the Database to your own local Db, you can have all the tables I've created automatically deployed to your database. I actually publish my changes from project in Visual Studios any time that I need to make changes to my Sql Server Database - and I love having the changes tracked as part of my respository!

### EmployeeTracker.Data

This Class Library is probably one of the parts of this application that I'm the most proud of. I've used this same pattern for abstracting Dapper in a few projects now, and I love the freedom that it brings. I found the Repository Pattern to quickly introduce cross dependencies and that's something this pattern has definitely addressed.

Each IDataRequest Object will GenerateSql() and GenerateParameters() - by sticking to this contract I've been able to create a class that will execute any DataRequest. DataRequests can even be inherited from BaseRequests if you find yourself repeating the same RequestShape for many requests!

### EmployeeTracker.Mediator

This Class Library utilizes the MediatR Nuget Package to introduce the Mediator Pattern. I've fallen in love with this pattern because I feel it really allows you to create applications with less inter-dependencies, and each Request/Handler fits in its own nice little area. I decided to place my Handlers/Requests in the same cs file, but all Handlers are internal so that the consumers can only utilize the Mediator Request Objects.

The first time I used the MediatR package I used FluentValidations to add a Validation Behavior to the MedaitR Pipeline. I thought this worked okay, but ultimately I preferred to use my own IValidatable interface to handle validations. However I still utilized the MediatR Pipeline to automatically handle the Validation before passing requests to their handlers.

### EmployeeTracker.Api

This Layer is still in development.

## Testing

Testing is an important part of the application. I am a believer in true unit testing, so I've introduced Moq to help test objects without testing their dependencies. 

I introduce abstractions to my Test Layers to make writing tests easier. My abstract Base Test classes eliminate repeated mocking and simplify the Setup process which allows me to write my tests faster - and with increased readability.

This is the first project I've done where I've used Dapper and Mocked my IDbConnection. I thought InMemoryDatabases were only possible with Entity - but I was wrong! In this project I use an InMemoryDatabase to test my Queries/Commands without ever touching my database.

I also utilized the Shouldly Nuget Package to enhance readability with my Assertions. I love the way that assertions flow more like a regular english sentance with the help of this package. After all, readability is an important aspect of our tests!

## Technologies/Highlights

- Overall
  - .Net Core 6.0
  - Clean Architecture
  - SOLID Principles
  - Mediator Pattern
  - Unit Testing w/ Mocked Dependencies
  - InMemoryDatabase w/ Dapper For Testing
- EmployeeTracker.Domain
  - No External Dependencies (Domain Is Center Of Application)
  - Custom Validation Handling
- EmployeeTracker.Database
  - Sql Server Database
  - Deploy Db Changes via Publishing SqlServer Project
  - Manually Created Table Scripts
- EmployeeTracker.Data
  - Dapper ORM for Data Transactions
  - Dapper Abstracted through Wrapper to handle Data Requests
  - Sql Generation for easy Sql Query/Command creations
- EmployeeTracker.Mediator
  - MediatR Nuget Package
  - Mediator Design Pattern
  - Validation Behavior via MediatR Pipeline  
- Tests
  - xUnit Testing Projects
  - InMemoryDatabase w/ Dapper for Data Tests
  - Moq Nuget Package for Mocking Dependencies
  - Shouldly Nuget Package for Enhancing Assertion Readability
  - Abstraction in Test Layers to make writing tests easier
