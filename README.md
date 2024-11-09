# Slim Financial

This repository contains two separate projects that together form a bank application. Each project is designed to run independently, allowing for flexibility in development and deployment. The frontend is developed with Angular, while the backend API is a .NET C# application. Both applications must be set up and run individually.

# Table of Contents
* Overview
* Architecture
* Prerequisites
* Setup Instructions
    * Frontend Setup
    * Backend Setup
* Running the Applications
* Api Documentation

# Overview
This bank application enables users to perform standard banking operations, such as viewing account balances, making transfers, and managing personal information. The frontend and backend components are modular, allowing each to be run, developed, and deployed independently.
* **Frontend - Slimfinancial.UI :** Angular application for the user interface.
* **Backend - SlimFinancial.Api :** C# .NET application that handles business logic and data management.
# Architecture
* **Frontend - Slimfinancial.UI:**
    Built with Angular, this project serves as the client-side application, providing a user-friendly interface for the bank application's features.
* **Backend - SlimFinancial.Api :**
    Developed with C# .NET, this application manages the business logic and interacts with a sqlite database built into the application (since this is for demonstration only) to handle transactions, user data and other related operations.
# Prerequisites
#### General
* Node.js (required for Angular and frontend development).
* .NET SDK (required for backend development).
* A code editor such as Visual Studio Code or Visual Studio.
#### Specific Versions
* **Angular CLI** : For version compatible with the Angular project check [slimfinancial.UI/package.json]().
* **.NET SDK** : For version compatible with the C# .NET project check [slimfinancial.Api/Presentation/slimfinancial.Api.csproj]().
# Setup Instructions
#### Frontend Setup
1.  Navigate to the frontend directory :
    `cd slimfinancial.UI`
2. Install Dependencies :
    `npm install`
3. Build the project (optional):
    `ng build`
#### Backend API Setup
1.  Navigate to the Backend directory in the presentation folder :
    `cd slimfinancial.Api\Presentation`
2.  Restore Dependencies :
`dotnet restore`
3. Build the project (optional) :
`dotnet build`
# Running the Applications
*   #### Frontend (Angular App):
    Start the Angular Development Server :
    `ng serve --open`
    The frontend would be available at *http://localhost:4200* by default.
* #### Backend Api (.NET)
  start the .NET API server
  `dotnet run`
  The Api will be available at *http://localhost:5210* by default.
# API Documentation
For details on the available API endpoints, refer to the swagger documentation included in the .NET project. The Swagger UI should be accessible at *http://localhost:5210/swagger*.



    
