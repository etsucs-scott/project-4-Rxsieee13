[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-22041afd0340ce965d47ae6ef1cefeee28c7c493a6346c4f15d667ab976d596c.svg)](https://classroom.github.com/a/qJo95Bxr)
# CSCI 1260 — Project

## Project Instructions
All project requirements, grading criteria, and submission details are provided on **D2L**.  
Refer to D2L as the *authoritative source* for this assignment.

This repository is intentionally minimal. You are responsible for:
- Creating the solution and projects
- Designing the class structure
- Implementing the required functionality

---

## Getting Started (CLI)

You may use **Visual Studio**, **VS Code**, or the **terminal**.

### Create a solution
```bash
dotnet new sln -n ProjectName
```

### Create a project (example: console app)
```bash
dotnet new console -n ProjectName.App
```

### Add the project to the solution
```bash
dotnet sln add ProjectName.App
```

### Build and run
```bash
dotnet build
dotnet run --project ProjectName.App
```

## Notes
- Commit early and commit often.
- Your repository history is part of your submission.
- Update this README with build/run instructions specific to your project.

# Recipe Organizer Project
- The Recipe Organizer is a web-based application built using Blazor 
- that allows users to manage recipes, search by name, view detailed instructions,
- and generate shopping lists based on ingredients.

# Project Features
- Add, view, and delete recipes
- Search recipes by name
- Mark recipes as favorites
- Click a recipe to view ingredients and instructions
- Generate a shopping list based on a selected recipe
- View statistics of most-used ingredients
- Custom pink-themed UI design

# Technologies Used
- Blazor WebAssembly
- C# (.NET / Blazor)
- Razor Components
- HTML & CSS
- JSON (for data storage)

# Run Project 
- dotnet build 
- dotnet run
- Then open your browser and navigate to:
- https://localhost:7051

# How to Run Unit Tests
- Open Test Explorer in Visual Studio 2022
- Click:
- Run All Tests
- Or use the command line:
- dotnet test
- This will execute all unit tests and display the results in the terminal.

# Data Storage
-All recipe data is stored in: wwwroot/data/recipes.json
- The application uses file I/O to: Save recipes and Load recipes on startup

# UML Diagram
- A UML diagram was created using draw.io and includes:
- Classes: Recipe, Ingredient, RecipeManager, FileService, ShoppingListService
- Relationships between data models and services
- System structure and responsibilities

# Submission Note
- This project was completed as part of the CSCI-1260 Object-Oriented Programming course where I created a 
- Blazor web application for managing recipes.
- The application meets all specified requirements, including OOP design principles, data structures, file I/O operations, 
- UI development, and unit testing. 
- The code is well-organized and documented, demonstrating a clear understanding of the concepts taught in the course.
- It meets the requirements for OOP design, data structures, file I/O, UI development, and testing.
- The project was built using Blazor WebAssembly, allowing for a responsive and interactive user experience.

# References / Citations
- Microsoft Blazor Documentation
  https://learn.microsoft.com/en-us/aspnet/core/blazor
- C# JSON Serialization
  https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json
- draw.io UML Tool
  https://app.diagrams.net
