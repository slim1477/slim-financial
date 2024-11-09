# Slimfinancial.API
This is a C# .NET API project. It provides backend services to the slimfinancial.UI frontend application, including authentication, account opening, and transaction posting and retrieval. The API follows the Onion Architecture structure which promots the Dependency Inversion Principle to ensure maintainability, testability, and scalability.

# Contents
* Overview
* Features
* Project Structure
# Overview
This API serves as the backend for slimfinancial.UI, handling all business logic and data management. It provides the essential services to the frontend application and is structured using the Onion Architecture, which promotes a clear separation of concerns and adherence to the **SOLID** principles.

# Features
* Authentication Services: Manages user authentication, registration, and access control.
* Account  Services: Provides endpoints to open or close accounts, validate user information, and initialize account data.
* Transaction  Services: Retrieves transaction history, post new transactions, and other financial records for users transactions.
# Architecture
This API is structured following the Onion Architecture, which divides the application into different layers based on the dependency inversion principle.
# Project Structure
* **Core** : Holds the core entities.
* **Application** : Contains service interfaces 
* **Infrastructure** : Implements data access, external integrations, and repository patterns, DTOs and implementation of business logic defined in the application layer.
* **Presentation** : The presentation layer providing the RESTful API endpoints.
# Key Directories
* **[/Core/SlimFinancial.Domain](/Core/SlimFinancial.Domain)** : Domain Models
* **[/Application/SlimFinancial.Application](/Application/SlimFinancial.Application)** : Services and Use Cases
* **[/Infrastructure/SlimFinancial.Infrastructure](/Infrastructure/SlimFinancial.Infrastructure)** : Data access, Implementation and Service intergrations.
* **[/Presentation/SlimFinancial.API](/Presentation/SlimFinancial.API)** : API Controllers and configurations.



