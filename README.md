# 🧾 Reimbursement App

This is a simple full-stack web application that allows employees to submit receipts for reimbursement. The frontend is built with **Angular**, and the backend API is built with **ASP.NET Core** using **SQLite** for local development. There are also tests written with **Jest** in frontend and **xUnit** in back end.

## ✨ Features

- Submit receipts for reimbursement via a web form
- Store and retrieve reimbursement data using SQLite
- RESTful API built with ASP.NET Core (only post call)
- Frontend built with Angular
- Unit testing with xUnit (backend) and Jest (frontend)
- Planned Azure deployment with Auth0 authentication

---

## 🛠️ Tech Stack

- **Frontend**: Angular (latest)
- **Backend**: ASP.NET Core Web API (.Net 9)
- **Database**: SQLite (local development)
- **Authentication**: Auth0 (coming soon)
- **Testing**: xUnit, Moq (backend), Jest (frontend)

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/reimbursement-app.git
cd reimbursement-app
```

### 2. BackEnd Set up.
#### Prerequisites
-**.Net Sdk**(latest version)
-**Sqlite**

```bash
cd ReimbursementApi
dotnet restore
dotnet ef database update
dotnet run
```
### 3. To Run the BackEndTest.
```bash
cd..
cd ReimbursementApiTest
dotnet test
```
### 4. Front End Set Up.
#### Prerequisites
**Node.js** (latest LTS version recommended)

**Angular CLI**
#### 5. Run The Angular App.
```bash
cd..
cd /reimbursement-app
npm install
ng serve
```
### Note: Run the api application first and then update the url in which api is opening in app.component.ts file in the reimbursement-app. It is hardcoded for now.

### 5. Running Front End Tests
```bash
cd /reimbursement-app
npm test

```
## Things to do 
1. Complete the tests.
2. Deploy in azure.
3. Would like to add authentication and authorization.

## Features to add in the App
1. Show the added record(receipts)and their details in the front end.
