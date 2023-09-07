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

## Endpoints

All endpoints working accordingly to func:

    * GET /api/products ->              return a list of products
        Available filters on request params:
            *minPrice
            *maxPrice
            *minStock
            *maxStock
            *category
            *Page NOT IMPLEMENTED
            *numPerPage NOT IMPLEMENTED
    * GET /api/products/categories ->   return a list of categories
    * POST /api/products/remove ->      Product Name to be removed from product list for the user
        request param:
            *productName 
    * GET /api/products/remove ->       return a list of Removed Products

    * POST /api/user/login ->           return jwt on valid login
        request body:
            *Username
            *Password
    
    * GET /api/records ->               return a list of Call Records made to the endpoints

## TODO

    * Fix Authorization
    * Change User model to save hashedpassword
    * Exception Handlers
    * Validations
    * DTOs instead of directly using the entities
    * Refactor so Handlers are Service injected and we can handle the logic on the Service, creating an abstraction layer and going acording to best practises
    * GetAllRecords need to map user
    * !Testing!