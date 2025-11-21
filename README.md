# Library Management System (TDD Project)

## Overview
This project implements a small library system using Test-Driven Development (TDD).

## Features
- Add, list, borrow, and return books.
- Prevent duplicate or invalid entries.
- Full unit test coverage using xUnit.

## Features (Week 2)
- Add books to library ✔️  
- List all available books ✔️  
- Borrow and return books (planned) ⏳  
- Prevent duplicate or invalid entries ✔️  
- Full unit test coverage using xUnit (incremental) ✔️

## Technologies
C# (.NET 8), xUnit, GitHub Actions CI.

## Project Sceleton
LibraryManagementSystem/
│
├── LibraryManagementSystem.Core/
│   ├── Models/
│   │   └── Book.cs
│   ├── Services/
│   │   └── LibraryService.cs
│
├── LibraryManagementSystem.Tests/
│   └── LibraryServiceTests.cs
│
├── .github/
│   └── workflows/
│       └── dotnet.yml
│
└── README.md


## How to Run Tests
dotnet restore  
dotnet test
