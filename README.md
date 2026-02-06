
# Keimhean Cafe POS - Restaurant Management System
[![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)
[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Avalonia](https://img.shields.io/badge/Avalonia-11.x-8B44AC)](https://avaloniaui.net/)
[![MySQL](https://img.shields.io/badge/MySQL-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)
[![Docker](https://img.shields.io/badge/Docker-2496ED?logo=docker&logoColor=white)](https://hub.docker.com/_/phpmyadmin)

**Keimhean Cafe POS** — A comprehensive Point-of-Sale restaurant management system built with Avalonia UI and .NET 9, demonstrating 5 design patterns for academic purposes.

![Desktop POS Screenshot](public/images/Web.png)

## 🎯 Project Overview

This is an educational project demonstrating the implementation of **5 classic design patterns** in a real-world restaurant/cafe POS system:
- 🎨 **Decorator** - Dynamic menu item customizations
- 🌉 **Bridge** - Order types and payment methods separation
- 🌲 **Composite** - Hierarchical menu structure
- 🔌 **Adapter** - Payment gateway integration
- 📋 **Prototype** - Object cloning for efficiency

## ✨ Features

### Current Features
- ✅ User authentication (Staff & Admin roles)
- ✅ Product catalog with 54 pre-seeded items
- ✅ Transaction management
- ✅ Desktop POS UI (Avalonia)
- ✅ REST API
- ✅ **5 Design Patterns** fully implemented

### Planned Features (Database Ready)
- 📋 Menu Management - Category CRUD, item customization
- 🛒 Order Management - Create, update, clone orders
- 🪑 Table Management - Visual layout, status management
- 👥 Customer Management - Profiles, loyalty points
- 💳 Payment Processing - Multiple methods, split payments
- 📊 Reporting - Sales, analytics, exports

## 🏗️ Design Patterns

### 1. Decorator Pattern 🎨
Add customizations dynamically to menu items without modifying their structure.

```csharp
IMenuItem espresso = new BaseMenuItem("Espresso", 3.00m);
espresso = new MilkDecorator(espresso);        // +$0.50
espresso = new ExtraShotDecorator(espresso);   // +$1.00
// Result: "Espresso + Milk + Extra Shot" = $4.50
```

### 2. Bridge Pattern 🌉
Separate order abstractions from payment implementations.

```csharp
var creditCard = new CreditCardPayment();
var order = new DineInOrder(creditCard) { TotalAmount = 25.00m };
order.ProcessPayment(); // Can switch payment methods at runtime
```

### 3. Composite Pattern 🌲
Create hierarchical menu structures and combo meals.

```csharp
var category = new MenuCategory("Coffee");
category.Add(new MenuItem("Espresso", 2.50m));

var combo = new ComboMeal("Breakfast", 5.50m);
combo.Add(new MenuItem("Coffee", 3.00m));
combo.Add(new MenuItem("Croissant", 3.00m));
```

### 4. Adapter Pattern 🔌
Integrate multiple payment gateways with unified interface.

```csharp
IPaymentGateway stripe = new StripeAdapter();
IPaymentGateway aba = new ABAAdapter(); // Cambodia local
var result = await stripe.ProcessPaymentAsync(request);
```

### 5. Prototype Pattern 📋
Clone objects efficiently for repeat operations.

```csharp
var order = GetOrder(5);
var clonedOrder = order.Clone(); // "Same as Table 5"
```

**📖 Full Documentation**: [docs/DesignPatterns.md](docs/DesignPatterns.md)

## Prerequisites
- .NET 10 SDK
- Docker & Docker Compose (for MySQL local DB)

# coffee-management-system

Keimhean Cafe POS — Point-of-sale application (API, Desktop client, Web front-end)

Contents

- `KeimheanCafePOS.sln` — solution containing API, Desktop, Web, Domain, Infrastructure, Application
- `src/KeimheanCafePOS.API` — ASP.NET Web API
- `src/KeimheanCafePOS.Desktop` — Avalonia desktop client (MVVM)
- `src/KeimheanCafePOS.Web` — optional web UI
- `.github/workflows/ci.yml` — GitHub Actions CI workflow

## Features

- User authentication (seeded `staff` and `admin` users)
- Products and transactions endpoints
- Desktop POS UI (Avalonia)

## Prerequisites

- .NET 9 SDK
- Docker & Docker Compose (for MySQL local DB)

## Local development (quick start)

1. Start MySQL and phpMyAdmin (from repo root):

```sh
docker compose -f KeimheanCafePOS/docker-compose.yml up -d --build
```

2. Build the solution:

```sh
dotnet restore KeimheanCafePOS.sln
dotnet build KeimheanCafePOS.sln -c Release
```

3. Run the API (default dev port used in this repo is `http://localhost:5138`):

```sh
cd src/KeimheanCafePOS.API
dotnet run
```

4. Run the Desktop app (Avalonia):

```sh
cd src/KeimheanCafePOS.Desktop
dotnet run
```

5. Test login (example using `curl`):

```sh
curl -X POST http://localhost:5138/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{"username":"staff","password":"<sha256-hash-of-password>"}'
```

Notes:

- The repo seeds `staff` and `admin` accounts. The Desktop client currently hashes the password client-side using SHA256 before sending; the API compares that hash to the stored `PasswordHash`.

## Configuration

- Connection strings and environment-specific settings live in `src/KeimheanCafePOS.API/appsettings.json` and `appsettings.Development.json`.
- If you run MySQL via the provided `docker-compose.yml`, the service name and credentials are configured there.

## CI (GitHub Actions)

- A basic CI workflow is provided at `.github/workflows/ci.yml` that:
  - Restores and builds the solution
  - Publishes the API and desktop artifacts
  - Optionally builds & pushes a Docker image when `DOCKERHUB_USERNAME` and `DOCKERHUB_TOKEN` secrets are set and a `Dockerfile` exists at `src/KeimheanCafePOS.API/Dockerfile`.

If you enable Docker publishing, add the Docker Hub secrets in the repository settings.

## Troubleshooting

- If your CI fails because of missing `Dockerfile`, either add one to `src/KeimheanCafePOS.API/` or remove the `docker-push` job from the workflow.
- To keep the repository clean, avoid committing `bin/` and `obj/` folders — `.gitignore` has standard .NET ignores.

## 📚 Documentation

- [Quick Start Guide](docs/QUICKSTART.md) - Get up and running quickly
- [Design Patterns](docs/DesignPatterns.md) - Detailed explanation of all 5 patterns
- [Implementation Summary](docs/IMPLEMENTATION_SUMMARY.md) - Current status and roadmap

## 🗂️ Project Structure

```
├── src/
│   ├── KeimheanCafePOS.Domain/          # Business logic & design patterns
│   │   ├── DesignPatterns/              # 5 design patterns implementation
│   │   └── Entities/                    # Database entities
│   ├── KeimheanCafePOS.Infrastructure/  # Data access & adapters
│   ├── KeimheanCafePOS.Application/     # Application services
│   ├── KeimheanCafePOS.API/             # REST API
│   └── KeimheanCafePOS.Desktop/         # Avalonia UI
└── docs/                                 # Documentation
```

## 🎓 Academic Context

This project is developed for an academic assignment requiring:
- ✅ Implementation of at least 5 design patterns
- ⏳ 6 complete features with CRUD operations
- ⏳ Presentation/demo preparation
- **Deadline**: Mid-March 2026

**Status**: Design patterns complete, database schema ready, features in progress.

## Contributing

- Open issues or PRs on the repository. Follow the existing project structure and run the local build steps before creating PRs.

## License

Educational project for academic purposes.
