# 📚 Library Management System (TDD Project)

## Overview
This project implements a small library system following Test-Driven Development (TDD).  
The goal is to incrementally design, test, and implement functionality while maintaining continuous integration and clean code principles.

---

## 📅 Progress by Iteration

### ✅ Week 1 — Planning & Setup
- Created solution structure
- Added README, Git repo setup, CI pipeline draft
- Defined user stories and project scope
- First failing tests written (Red Phase)

### 🛠️ Week 2 — Core Feature (Iteration 1)
- Implemented first feature based on failing tests:
  - Add book
  - List books
  - Validate title input
- CI pipeline running successfully
- All initial tests passing (Green Phase)

### 🚀 Week 3 — Extend & Refactor (Iteration 2)
- Added second feature: **BorrowBook**
- Refactored service logic for maintainability
- Updated architecture diagram
- CI passing after skipping next planned test:
  - `ReturnBook` test marked `[Skip]` for next iteration
- Test coverage snapshot recorded

---

## Features Progress

| Feature | Status |
|--------|--------|
| Add new books | ✔️ Done |
| List books | ✔️ Done |
| Borrow books | ✔️ Implemented (Week 3) |
| Return books | ⏳ Planned for Week 4 |
| Prevent invalid/duplicate entries | ✔️ Done |
| CI/CD | ✔️ Active |
| Full automated testing | 🧪 In progress |

---

## Technologies Used
- **C# (.NET 8)**
- **xUnit** (unit testing)
- **GitHub Actions** (continuous integration)

---

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

## 🧪 Test Summary (Week 3 Snapshot)


**Current Coverage Results:**

| Metric | Value |
|--------|-------|
| Line Coverage | **88%** |
| Branch Coverage | **75%** |
| Test Suite Status | ✔ All planned tests passing (1 skipped for next iteration) |

A detailed HTML report is stored in:  
`/LibraryManagementSystem.Tests/TestResults/.../coverage-report/index.html`

---

## Running Tests

```bash
dotnet restore
dotnet test

