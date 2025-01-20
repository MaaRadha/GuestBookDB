# Feedback API - Digital Guestbook

![Screenshot 2025-01-20 235748](https://github.com/user-attachments/assets/04d963b5-768a-4540-833b-599d8314617a)

## .Net Version 8

An ASP.NET Core Web API designed to collect and manage feedback entries for a digital guestbook. The API provides endpoints for submitting, retrieving, and managing user feedback. Additionally, users can react to posts by liking or adding other types of reactions.

## Features
- Submit feedback entries.
- Submit Reaction on Feedback.
- Retrieve a list of all feedback.
- Retrieve a list of all Reactions.
- Manage (Create, update, delete).
- React to feedback posts (like, etc.).
- Swagger UI for easy interaction with the API.

## Technology Stack
- **ASP.NET Core**: Web API framework for building the backend.
- **Swagger**: API documentation and testing interface.
- **DTOs**: Data Transfer Objects for abstraction and data flow.
- **AutoMapper**: For mapping entities to DTOs.
- **Entity Framework Core (EF Core)**: ORM used for database interactions.
- **SQL Server**: Database for storing feedback entries and reactions.
- **Docker**: Containerization for deploying the application.
- **Swagger UI**: Interactive API documentation and testing tool.
- **Tools/Packages**:
  - `Swashbuckle.AspNetCore`: Swagger integration.
  - `AutoMapper`: Object-to-object mapping.
  - `Microsoft.EntityFrameworkCore`: EF Core for database interactions.
  - `Microsoft.Extensions.DependencyInjection`: Dependency Injection for loose coupling.
  - `Microsoft.AspNetCore.SwaggerGen`: Swagger generation.

## Docker
- The project also includes a **Docker** repository for containerizing the application. You can pull the Docker image from the following link:
  - [Docker Repository](https://hub.docker.com/repositories/maaradha)
 
## Installation and setup
Clone the repository by running the command:

## API Endpoints

### Feedback Endpoints

#### 1. **/api/PostComments**
Submit a new feedback entry.

##### Request Body:
```json
[
  {
    "id": 0,
    "fullName": "string",
    "content": "string"
  }
]
```
#### 1. **/api/PostReactions**
Submit a new feedback entry.
##### Request Body:
```json
 {
  "likes": 0,
  "dislikes": 0,
  "hearts": 0
}
```
