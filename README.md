# SchoolProjectInCleanArchitecture

## Overview

**SchoolProjectInCleanArchitecture** is a web-based API project developed with **ASP.NET Core** following the principles of **Clean Architecture**. The project demonstrates how to create a scalable and maintainable application with modern design patterns and practices, leveraging the **Code-First** approach for database design.

---

## Features

### Core Features
- **Clean Architecture**: Separation of concerns with layers for Domain, Application, Infrastructure, and Presentation.
- **Code-First Approach**: Simplified database management using Entity Framework Core.

### Design Patterns
- **CQRS**: Separation of commands and queries for scalability and performance.
- **Generic Repository**: Abstracted data access layer for reusability and simplicity.

### Security
- **Authentication**: Integrated **JWT Tokens** for secure user authentication.
- **Authorization**: Role-based and claims-based access control.

### API Enhancements
- **Pagination**: Efficient data retrieval with paginated responses.
- **Localization**: Multi-language support for API responses.
- **Swagger Integration**: Built-in API documentation and testing.

### Utilities
- **Email Service**: Send emails directly from the application.
- **File Upload Service**: Supports uploading and managing images.

### Advanced Database Operations
- **Stored Procedures**, **Views**, and **Functions** with dedicated endpoints.

### Developer Tools
- **FluentValidation**: Streamlined validation for input data.
- **CORS**: Configured to allow cross-origin requests.
- **Filters**: Custom action filters for logging and request validation.
- **Unit Testing**: Comprehensive test coverage with **XUnit**.
