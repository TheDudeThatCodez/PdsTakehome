# pds-takehome

Solution for Pacific Dental take-home project.

## Prerequisites

- [Docker](https://www.docker.com/get-started) installed on your machine.

## Getting Started

You can run the application using either the provided Makefile or by running Docker commands manually.

---

### Option 1: Using the Makefile

1. **Build the Docker image:**

   ```sh
   make build

   ```

2. **Run the application:**

   ```sh
   make run

   ```

3. **Build and run in one step:**
   ```sh
   make rebuild
   ```

### Option 2: Using Docker Compose

1. **Build the Docker image:**

   ```sh
   docker-compose build

   ```

2. **Run the application:**
   ```sh
   docker-compose run --rm pds-takehome
   ```

### Option 3: Building and Running Manually (Without Docker or Makefile)

1. **Install .NET SDK**

   Make sure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed (version 9.0).

   Check your installation:

   ```sh
   dotnet --version

   ```

2. **Restore Dependencies**

   ```sh
   dotnet restore

   ```

3. **Build the application**

   ```sh
   dotnet build

   ```

4. **Run the application**
   ```sh
   dotnet run --project src/PdsTakehome
   ```
