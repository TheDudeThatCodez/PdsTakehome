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
