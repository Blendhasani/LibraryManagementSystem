# 📚 Library Management System (TDD Project)

## Overview
This project implements a small library system following Test-Driven Development (TDD).  
The goal is to iteratively design, test, and implement features while keeping clean architecture, CI validation, and measurable test coverage.

---

## 📅 Progress by Iteration

### ✅ Week 1 — Planning & Setup
- Created project structure and repository
- Added CI pipeline (GitHub Actions)
- Wrote first failing tests (Red Phase)
- Defined project scope and user stories

### 🛠️ Week 2 — Core Feature (Iteration 1)
- Implemented **AddBook** and **ListBooks**
- Basic validation applied
- All tests passing (Red → Green)
- CI pipeline working successfully

### 🚀 Week 3 — Extend & Refactor (Iteration 2)
- Implemented **BorrowBook**
- Refactored service logic (helper method introduced)
- Updated architecture diagram and documentation
- CI passing
- `ReturnBook` test added but skipped (planned for Week 4)
- Recorded first code coverage snapshot

### 🎯 Week 4 — Polish & Optimize (Iteration 3)
- Implemented **ReturnBook** feature
- Added edge-case validation:
  - Throw if returning a non-existing book  
  - Throw if returning an already available book
- Expanded test suite with new assertions
- Improved design (shared helper method, cleaner logic)
- Achieved high test coverage (>85%)
- Removed skipped test — all tests now active and passing

### 🧱 Week 5 — Mocks, Repository Abstraction & Console Demo
- Introduced **ILibraryRepository** abstraction and **LibraryRepository** in-memory implementation
- Refactored **LibraryService** to depend on `ILibraryRepository` (dependency injection)
- Tests now use a **FakeRepository** as a lightweight mock for isolated unit testing
- Added `ignoreAvailability` parameter to `BorrowBook` and dedicated tests for this branch
- Added a test for `GetAllBooks` to cover the read path
- Marked `LibraryRepository` with `ExcludeFromCodeCoverage` to focus metrics on domain logic
- Added **LibraryManagementSystem.ConsoleApp** with a simple text menu to:
  - Add books
  - Borrow books
  - Return books
  - List all books
- Tuned tests and configuration to reach **100% line coverage** and **100% branch coverage**

---

## ✅ Feature Status

| Feature                                  | Status |
|------------------------------------------|--------|
| Add new books                            | ✔ Done |
| List all books                           | ✔ Done |
| Borrow books                             | ✔ Done |
| Return books                             | ✔ Done |
| Prevent invalid / duplicate entries      | ✔ Done |
| Repository abstraction (ILibraryRepository) | ✔ Done |
| FakeRepository-based tests (mocks)       | ✔ Done |
| Console demo app                         | ✔ Done |
| CI Integration                           | ✔ Active |
| 100% test coverage (line & branch)       | ✔ Achieved in Week 5 |

---

## 🧰 Technologies Used
- **C# (.NET 8)**
- **xUnit** for unit testing
- **Coverlet + ReportGenerator** for coverage reports
- **GitHub Actions** for CI
- Simple **Console App** for interactive demo


---
```bash
## 📁 Architecture (Updated — Week 5)
LibraryManagementSystem/
│
├── LibraryManagementSystem.Core/
│   ├── Models/
│   │   └── Book.cs
│   ├── Abstractions/
│   │   └── ILibraryRepository.cs
│   ├── Services/
│   │   ├── LibraryService.cs
│   │   └── LibraryRepository.cs
│
├── LibraryManagementSystem.Tests/
│   └── LibraryServiceTests.cs
│       ├── AddBook_ShouldIncreaseBookCount()
│       ├── AddBook_ShouldThrow_WhenTitleIsEmpty()
│       ├── AddBook_ShouldThrow_WhenTitleAlreadyExists()
│       ├── BorrowBook_ShouldMarkBookAsUnavailable()
│       ├── BorrowBook_ShouldThrow_WhenBookAlreadyBorrowed()
│       ├── BorrowBook_ShouldSkipAvailabilityCheck_WhenIgnoreIsTrue()
│       ├── ReturnBook_ShouldMarkBookAsAvailable()
│       ├── ReturnBook_ShouldThrow_WhenTitleIsWhitespace()
│       ├── ReturnBook_ShouldThrow_WhenTitleIsEmpty()
│       ├── ReturnBook_ShouldThrow_WhenBookDoesNotExist()
│       ├── ReturnBook_ShouldThrow_WhenBookIsAlreadyAvailable()
│       └── GetAllBooks_ShouldReturnAllBooks()
│
├── LibraryManagementSystem.ConsoleApp/
│   └── Program.cs
│
├── .github/
│   └── workflows/
│       └── dotnet.yml  (CI passing)
│
└── README.md
---
```
---


## 🧪 Test Coverage Results (Week 4)
| Metric          | Value               |
| --------------- | ------------------- |
| Line Coverage   | **100%**            |
| Branch Coverage | **100%**            |
| Test Status     | ✔ All tests passing |


📁 HTML coverage report path:  
`LibraryManagementSystem.Tests/TestResults/.../coverage-report/index.html`

---

## Running Tests

```bash
dotnet restore
dotnet test