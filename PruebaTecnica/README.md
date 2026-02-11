# Product API – Technical Test (.NET 8)

# Description

This project is a RESTful API developed with **.NET 8** that implements a complete CRUD for managing products.  
It follows a layered architecture (Controller → Service → Repository) and uses **Entity Framework Core** with **SQL Server Developer**.

Additionally, soft delete and DTO pattern were implemented to improve security and separation of concerns.



# Technologies Used

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Developer
- Swagger
- Git


# Project Structure

The solution follows a layered architecture:

Controllers  
Services  
Repositories  
Data (DbContext)  
Models (Entities)  
DTOs  

- **Controllers**: Handle HTTP requests and responses.
- **Services**: Contain business logic.
- **Repositories**: Handle data access.
- **DTOs**: Prevent over-posting and avoid exposing internal entities.



# Database

- SQL Server Developer Edition
- Entity Framework Core with Migrations
- Soft Delete implemented using `IsActive` field



# How to Run the Project

# 1. Clone the repository

```bash
git clone <repository-url>
cd ProductApi
```

# 2️. Configure Connection String

Update `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=ProductDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Replace `YOUR_SERVER` with your SQL Server instance (example: `localhost\\SQLEXPRESS`).


# 3️. Apply Migrations

Using Package Manager Console:

```powershell
Update-Database
```

Or using CLI:

```bash
dotnet ef database update
```



# 4️. Run the API

```bash
dotnet run
```

Swagger will be available at:

```
https://localhost:<port>/swagger
```


# API Endpoints

# Get All Products

GET /api/products  

Returns only active products (`IsActive = true`).


# Get Product by Id

GET /api/products/{id}


# Create Product

POST /api/products

Example Request:

```json
{
  "name": "Laptop",
  "description": "Gaming laptop",
  "price": 2500
}
```


# Update Product

PUT /api/products/{id}

Example Request:

```json
{
  "name": "Updated Laptop",
  "description": "Updated description",
  "price": 2700
}
```

# Delete Product (Soft Delete)

DELETE /api/products/{id}

This does not remove the record physically.  
Instead, it sets:

IsActive = false  

Deleted products are excluded from GET endpoints.


# Security Considerations

# DTO Pattern

DTOs were implemented to:

- Prevent over-posting vulnerabilities
- Avoid exposing internal entity structure
- Improve API boundary control

# Soft Delete

Instead of physically deleting records, products are marked as inactive using `IsActive`.


# Architectural Decisions

- Layered architecture for separation of concerns
- Repository pattern for data access abstraction
- Service layer for business logic
- DTO pattern for secure data transfer
- Soft delete implementation for data integrity
