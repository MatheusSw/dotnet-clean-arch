# Clean Architecture Example in C#

This repository provides an implementation of the **CLEAN architecture** in a C# solution integrating with a weather
HTTP API,
integrating essential modern tools like **Prometheus** and **Grafana** for monitoring and
observability.

## Project Structure

This project follows the CLEAN architecture structure:

- **`CleanArch.Api`**: The Web API layer, containing controllers, configuration, and dependency
  injection setup.
- **`CleanArch.Domain`**: Core business logic and domain entities.
- **`CleanArch.Application`**: Application-specific logic and use cases.
- **`CleanArch.Infrastructure`**: Infrastructure code such as external service integration and data
  persistence.

## Libraries and Tools

The project uses the following libraries and tools:

- **ASP.NET Core**: For building the Web API.
- **Serilog**: For logging.
- **Prometheus.NET**: For exposing application metrics.
- **Docker Compose**: For orchestrating services like the API, Prometheus, and Grafana.

## Monitoring and Observability

The project includes a **`docker-compose.yml`** file that sets up:

- **Prometheus**: To scrape metrics exposed by the API.
- **Grafana**: For visualizing metrics from Prometheus.

### Metrics Endpoint

The application exposes metrics at `/metrics` using the **Prometheus.NET** library.

## Setup Instructions

### Prerequisites

- Docker and Docker Compose installed.
- WeatherStack API key for the Weather API integration.

### Steps

1. Clone the repository:

 ```bash
 git clone https://github.com/MatheusSw/dotnet-clean-arch.git
 cd CleanArch
 ```

2. Add your WeatherStack API key to your system environment variables
3. Build and run the application using Docker Compose:

 ```bash
 docker-compose up --build
 ```

4. Access the services:

- **API**: [http://localhost:8080](http://localhost:8080)
- **Prometheus**: [http://localhost:9090](http://localhost:9090)
- **Grafana**: [http://localhost:3000](http://localhost:3000)

### Visualizing Metrics

1. Log into Grafana at [http://localhost:3000](http://localhost:3000) (default admin/admin).
2. Add Prometheus as a data source. (Use prometheus:9090 as the URL)
3. Import pre-configured dashboards or create custom ones to monitor API performance.

## Example API Endpoints

- **GET `/weathers?location=Brasil Sao Paulo`**: Fetches weather information for a specific location using
  WeatherStack API.