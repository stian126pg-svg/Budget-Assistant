# 💰 Budget Assistant CLI (v1.0)

A simple command-line budget management application written in C#.

This project was developed as part of a Kodehode assignment to practice object-oriented programming, file handling, and creating reusable application architecture.

---

## Features

✔ Multi-user support

- Create a new budget account by entering a unique username
- Existing users automatically load their saved data

✔ Income & Expenses

- Add income
- Add expenses
- Categorize transactions
- Automatic timestamping

✔ Transaction Management

- View all transactions
- Edit transactions (within 24 hours)
- Delete transactions (within 24 hours)

✔ Filtering

- Last 24 Hours
- Last Week
- Last Month
- Show All

✔ Account Summary

- Total income
- Total expenses
- Number of expense entries
- Current balance

✔ Automatic Saving

- JSON serialization
- Data automatically saves after every change
- User data loads automatically on startup

---

## Project Structure

```
Budget_Assistant
│
├── Models
│   ├── Transaction.cs
│   ├── TransactionType.cs
│   └── UserAccount.cs
│
├── Services
│   ├── UserService.cs
│   ├── TransactionService.cs
│   └── DataService.cs
│
├── Helpers
│   ├── ConsoleHelper.cs
│   └── InputHelper.cs
│
├── Core
│   └── Menu.cs
│
└── Program.cs
```

---

## Technologies

- C#
- .NET
- JSON Serialization
- Object-Oriented Programming (OOP)
- LINQ
- DateTime
- File Handling

---

## Learning Goals

This project focuses on:

- Object-oriented programming
- Reusable code
- Separation of concerns
- Working with JSON
- File handling
- Collections
- LINQ
- User input validation
- CLI application design

---

## Future Ideas

- Multiple bank accounts
- Budget goals
- Monthly reports
- CSV import/export
- Search by description
- Colorized console output
- Charts and statistics
- Recurring transactions

---

## Version

Current Release:

**v1.0**
