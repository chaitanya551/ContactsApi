# Contacts API Backend

This project is the backend API for managing contacts, built with **ASP.NET Core**. The API provides endpoints for creating, reading, updating, and deleting contacts.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Setting Up the Project](#setting-up-the-project)
- [Running the Project](#running-the-project)
- [Endpoints](#endpoints)
- [Additional Configuration](#additional-configuration)

---

## Prerequisites

Before you can set up and run this API, ensure that the following software is installed on your machine:

- **.NET 6 SDK** (or higher): Download and install from [here](https://dotnet.microsoft.com/download/dotnet/6.0).
- **Visual Studio 2022** or **Visual Studio Code**: Ensure you have a development environment set up with C# support.

---

## Setting Up the Project

1. **Clone the Repository**:
   
   First, clone the repository to your local machine:
   ```bash
   git clone https://github.com/chaitanya551/ContactsApi.git
   cd contacts-api
   
2. **Install Dependencies**:
   dotnet restore
   
4. **Set HTTP Port to 5278**:
    "profiles": {
  "http": {
    "commandName": "Project",
    "dotnetRunMessages": true,
    "launchBrowser": true,
    "applicationUrl": "http://localhost:5278",
    "environmentVariables": {
      "ASPNETCORE_ENVIRONMENT": "Development"
    }
  }
}

5. **Running the Project**
   dotnet run



