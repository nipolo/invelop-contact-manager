# Contact manager

## Requirements
Create a simple web app for managing personal contacts

Required data:
   - first name
   - surname
   - D.O.B
   - address
       - line1
       - line2
       - postcode
       - city
       - country
   - phone number
   - IBAN

The data must be persisted.

There are a few additional paradigms/technologies/techniques we are interested to see:
   - .NET Backend:
   - EF Core for db communication (any db)
   - FluentValidation for models & entities
   - CQRS pattern
   - Rich Domain Model

Angular frontend:
   - ngrx Store
   - PrimeNG components
   - cypress e2e test (1 is enough)

## Initial setup
### Local setup with script
1. Run [this](Deployment/Deployment.Development.cmd) cmd file 

### Local setup with Visual Studio
1. Open **INV.ContactManager.Api.sln** with Visual Studio 2019/2022
1. Set **docker-compose** as Startup Project
1. Press F5

## Test the project
Import Postman collections and environments from [here](ContactManager/Tests)
### Local
1. Open Postman with the imported collections and environments
1. Choose **ContactManager-Local** environment
1. Execute *Create contact*, *Update contact*, *Get all contacts* and *Delete contact* requests
### BETA EC2 Server
1. Open Postman with the imported collections and environments
1. Choose **ContactManager-BETA** environment
1. Execute *Create contact*, *Update contact*, *Get all contacts* and *Delete contact* requests

## Notes
   - CQRS is not needed (unnecessary complexity)
      - The command part of this pattern is used for complex processes. The traditional RESTful API approach is perfect for CRUD opperations
      - Check [this](https://github.com/nipolo/invelop-contact-manager/tree/feature/replace-domain-services-with-MediatR) branch for implementation with MediatR library instead of domain services 
   - Rich domain models are not needed (unnecessary complexity)
   - Create, Load and Update methods/functions do not accept commands and states as params because the domain objects should be isolated from data and transport/presentation layers
   - Mappers have been avoided for a reason






