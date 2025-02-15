# MyProject

## 🚀 About the Project
This project retrieves data from the SpaceX API and saves it into a database every hour using Hangfire for scheduling jobs.

- The **Web API** fetches data from the external SpaceX API.
- The **Worker Service** runs in the background and processes the scheduled job every hour.
- Data is stored in a **SQL Server** database.
- **Hangfire Dashboard** is available for job monitoring.

## 🛠️ Prerequisites
Make sure you have the following installed:

- **.NET 8 or higher**
- **SQL Server (Express or full version)**
- **PowerShell, CMD, or another terminal**

## 🏗️ Setting Up the Database
Before running the application, set up your database:

1. **Update the connection string** in `appsettings.json`:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=MyProjectDb;Trusted_Connection=True;TrustServerCertificate=True;"
   }
   ```

2. **Apply migrations** (run in the project root directory):

   ```sh
   dotnet ef database update --project MyProject.Persistence
   ```

## ▶️ Running the Application
The project consists of two main components: **Web API** and **Worker Service**.

### 1️⃣ Start the Web API
In the first terminal, run:

```sh
cd MyProject

dotnet run --project MyProject.Api
```

Expected output:
```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5168
```

### 2️⃣ Start the Worker Service
In a second terminal, run:

```sh
cd MyProject

dotnet run --project MyProject.Worker
```

Expected output:
```
info: Hangfire.BackgroundJobServer[0]
      Starting Hangfire Server using job storage: 'SQL Server: localhost\\SQLEXPRESS@MyProjectDb'
info: Hangfire.Server.BackgroundServerProcess[0]
      Server started...
```

## 🔍 Monitoring Jobs with Hangfire
Once both the API and Worker are running, you can access the Hangfire Dashboard:

🌐 **Open in your browser:**
```
http://localhost:5168/hangfire
```

Here, you can:
- See scheduled and executed jobs.
- Manually trigger a job by clicking "Run Now".

## 🔄 How the Synchronization Works
1. The worker runs every **hour** and fetches the latest SpaceX launches.
2. If a launch is **not already stored**, it will be added to the database.
3. You can test manually by executing the job from the Hangfire Dashboard.

---
**Now you're ready to run and monitor the project! 🚀**

