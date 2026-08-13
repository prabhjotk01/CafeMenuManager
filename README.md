# Cafe Menu Manager

## Project Overview

The purpose of this application is to provide a simple way to manage cafe menu items, categories, and ingredients in one place.

The application uses Entity Framework Core with the Code-First approach and ASP.NET Core Identity for authentication and role-based authorization.

## Technologies Used

- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- Fluent API
- EF Core Migrations
- CSS

## Main Entities

The application contains three main domain entities:

1. MenuItem
2. Category
3. Ingredient

## Entity Relationships

### One-to-Many Relationship

One Category can have many Menu Items.


### Many-to-Many Relationship

One Menu Item can have many Ingredients, and one Ingredient can be used in many Menu Items.

## Simple ER Diagram

Category
   |
   | One-to-Many
   |
MenuItem
   |
   | Many-to-Many
   |
Ingredient

## Fluent API

Fluent API is configured in the DbContext using the OnModelCreating method.

It is used to configure:

- Primary Keys
- Foreign Keys
- Required fields
- Maximum field lengths
- Relationships
- Delete behavior
- Database constraints

## CRUD Functionality

The application provides CRUD operations:

- Create
- Read
- Update
- Delete

CRUD functionality is available for the main application data including Menu Items, Categories, and Ingredients.

## Authentication and Authorization

ASP.NET Core Identity is used for user authentication.

The application contains two roles:

- User
- Admin

### Standard User

A normal user can log in and access the standard features of the application.

### Admin

The Admin has additional permissions, including:

- Managing records
- Deleting records
- Accessing the Dashboard

## Test Accounts

### Admin Account

Email: admin@cafemanager.com

Password: Admin123!

### Standard User Account

Email: user@cafemanager.com

Password: User123!

## Dashboard

The Admin Dashboard displays a summary of application data, including:

- Total Menu Items
- Total Categories
- Total Ingredients


## Project Structure

CafeMenuManager
- MVC Web Application

CafeMenuManager.BLL
- Business Logic Layer

CafeMenuManager.DAL
- Data Access Layer

CafeMenuManager.Model
- Domain Models



