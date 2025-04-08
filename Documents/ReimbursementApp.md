# ReimbursementApp

## Description

The **Receipt Reimbursement App** allows employees to submit receipts for reimbursement. It includes:

- A **frontend** built with Angular
- A **backend** built with ASP.NET Core Web API
- A **SQLite** database (or in-memory DB for development/testing)
- **Tests** for both frontend (using **Jest**) and backend (using **xUnit**)

The application allows users to submit receipts, stores them in the database, and facilitates the reimbursement process. The API URL is currently hardcoded in the frontend, so you must start the backend **before** starting the frontend.

---

## Requirements

Before running the app, make sure you have the following installed:

- [.NET 6 or later](https://dotnet.microsoft.com/download)
- [Angular CLI](https://angular.io/cli)
- [Node.js and npm](https://nodejs.org/)
- [SQLite](https://www.sqlite.org/) (or use in-memory DB)
- [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli) *(optional for deployment)*

---

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/rajaniraju/ReceiptReimbursementApp.git
cd ReceiptReimbursementApp
