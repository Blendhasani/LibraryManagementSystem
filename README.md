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
- Recorded code coverage snapshot

### 🎯 Week 4 — Polish & Optimize (Iteration 3)
- Implemented **ReturnBook** feature
- Added edge-case validation:
  - Throw if returning a non-existing book  
  - Throw if returning an already available book
- Expanded test suite with new assertions
- Improved design (shared helper method, cleaner logic)
- Achieved increased test coverage (>85%)
- Removed skipped test — all tests now active and passing

---

## Feature Status

| Feature | Status |
|--------|--------|
| Add new books | ✔ Done |
| List available books | ✔ Done |
| Borrow books | ✔ Done |
| Return books | ✔ Completed (Week 4) |
| Prevent invalid/duplicate entries | ✔ Done |
| CI Integration | ✔ Active |
| Test coverage improvement | ✔ Completed |

---

## Technologies Used
- **C# (.NET 8)**
- **xUnit** for testing
- **Coverlet + ReportGenerator** for coverage reports
- **GitHub Actions** for CI

---
```bash

## 📁 Architecture (Updated — Week 3)
LibraryManagementSystem/
│
├── LibraryManagementSystem.Core/
│ ├── Models/
│ │ └── Book.cs
│ ├── Services/
│ │ └── LibraryService.cs
│
├── LibraryManagementSystem.Tests/
│ └── LibraryServiceTests.cs
│ ├── AddBook_ShouldIncreaseBookCount() ✔️
│ ├── AddBook_ShouldThrow_WhenTitleIsEmpty() ✔️
│ ├── BorrowBook_ShouldMarkBookAsUnavailable() ✔️
│ └── ReturnBook_ShouldMarkBookAsAvailable() ⏭ Skipped (Week 4)
│
├── .github/
│ └── workflows/
│ └── dotnet.yml (CI passing)
│
└── README.md

---
```
---

## 🧪 Test Coverage Results (Week 4)

| Metric | Value |
|--------|-------|
| Line Coverage | **95%** |
| Branch Coverage | **85%** |
| Test Status | ✔ All tests passing |

📁 HTML coverage report path:  
`LibraryManagementSystem.Tests/TestResults/.../coverage-report/index.html`

---

## Running Tests

```bash
dotnet restore
dotnet test