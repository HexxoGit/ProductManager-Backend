# ProductManager-Backend

## Table of Contents

MinimalApi to collect information on Products from an externalApi and work the data as requested.

- [TechStack](#techstack)
- [CurrentState](#currentsate)
- [Endpoints](#endpoints)
- [ToDo](#todo)

## TechStack, Patterns & Architecture
    * Clean Architecture
    * net7
    * C#
    * mySQL code-first
    * Linq
    * CQRS & Mediator Pattern

## CurrentState

Authentication & Authorization implemented but not working correctly when authorizing JWT on endpoits.

Default user created with DB used to test Login and hardcoded into otherendpoins to represent user authentication.
Username: FirstUser
Password: 123

## Endpoints

Can be found at https://localhost:7037/swagger/index.html

## TODO

List of future tasks:

    * Fix Authorization
    * Change User model to save hashedpassword
    * Exception Handlers
    * Validations
    * DTOs instead of directly using the entities
    * Refactor so Handlers are Service injected and we can handle the logic on the Service, creating an abstraction layer and going acording to best practises
    * GetAllRecords need to map user
    * Add Swager or similar tool to facilitate Endpoint sharing and testing.
    * !Testing!

List of completed tasks:

    * Endpoint refactor where every endpoint has a corresponding method so code is better structured.
    * Changed RemodeProduct endpoint from POST to DELETE and changed rout naming so it goes acording to RESTFul best practices.
    * Configured Swagger so endpoints can be used directly instead of requiring a tool like Postman.
    * Created Services for the corresponding models and necessary logic.
    * Handlers refactor so instead of having repo injection now the services are being injected into the handlers.
    * Changed Middleware from Infrastructure layer to Interface/Api layer to follow a clean architecture.
    *