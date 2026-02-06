# Quick Start Guide
# ការណែនាំបើកដំណើរការ

This guide helps you get started with the Keimhean Cafe POS system that includes 5 design patterns.

## Prerequisites / តម្រូវការ

- .NET 9 SDK
- Docker & Docker Compose (for MySQL)
- IDE: Visual Studio, VS Code, or Rider

## Getting Started / ចាប់ផ្តើម

### 1. Clone the Repository

```bash
git clone https://github.com/Keimhean/coffee-management-system.git
cd coffee-management-system
```

### 2. Start the Database / បើក Database

```bash
docker compose -f KeimheanCafePOS/docker-compose.yml up -d
```

This starts:
- MySQL on port 3306
- phpMyAdmin on http://localhost:8080

Default credentials:
- User: `root`
- Password: `root`

### 3. Run Database Migration / បង្កើត Database Tables

```bash
cd src/KeimheanCafePOS.Infrastructure

# Create migration
dotnet ef migrations add AddDesignPatternsEntities

# Apply migration
dotnet ef database update
```

This creates all tables including:
- products (existing)
- tables (new)
- customers (new)
- orders (new)
- order_items (new)
- menu_categories (new)
- combo_meals (new)
- payment_transactions (new)

### 4. Build the Solution / Build Project

```bash
# From repository root
dotnet restore KeimheanCafePOS.sln
dotnet build KeimheanCafePOS.sln -c Release
```

### 5. Run the Application / បើក Application

**Option A: Desktop Application (Avalonia UI)**
```bash
cd src/KeimheanCafePOS.Desktop
dotnet run
```

**Option B: API Server**
```bash
cd src/KeimheanCafePOS.API
dotnet run
```

API will be available at: http://localhost:5138

### 6. Login / ចូលប្រើ

Default accounts:
- **Staff**: username: `staff`, password: `staff123`
- **Admin**: username: `admin`, password: `admin123`

---

## Design Patterns Overview / ទិដ្ឋភាពទូទៅ Design Patterns

### 1. Decorator Pattern 🎨
**Purpose**: Add customizations to menu items

```csharp
IMenuItem coffee = new BaseMenuItem("Coffee", 2.00m);
coffee = new MilkDecorator(coffee);      // +$0.50
coffee = new SugarDecorator(coffee);     // +$0.25
// Result: "Coffee + Milk + Sugar" at $2.75
```

### 2. Bridge Pattern 🌉
**Purpose**: Separate order types from payment methods

```csharp
var payment = new CreditCardPayment { CardNumber = "4111..." };
var order = new DineInOrder(payment) { TotalAmount = 25.00m };
order.ProcessPayment();
```

### 3. Composite Pattern 🌲
**Purpose**: Hierarchical menu structure and combos

```csharp
var category = new MenuCategory("Coffee");
category.Add(new MenuItem("Espresso", 2.50m));
category.Add(new MenuItem("Latte", 4.00m));

var combo = new ComboMeal("Breakfast", 5.50m);
combo.Add(new MenuItem("Coffee", 3.00m));
combo.Add(new MenuItem("Croissant", 3.00m));
```

### 4. Adapter Pattern 🔌
**Purpose**: Integrate payment gateways

```csharp
IPaymentGateway stripe = new StripeAdapter();
var result = await stripe.ProcessPaymentAsync(new PaymentRequest { Amount = 50.00m });

IPaymentGateway aba = new ABAAdapter(); // Cambodia local
var abaResult = await aba.ProcessPaymentAsync(request);
```

### 5. Prototype Pattern 📋
**Purpose**: Clone orders and items

```csharp
var originalOrder = GetOrder(5);
var clonedOrder = originalOrder.Clone(); // Deep copy

var customer = GetCustomer(1);
var familyMember = customer.CloneForFamilyMember("Name", "Phone", "Email");
```

---

## Project Structure / រចនាសម្ព័ន្ធ Project

```
coffee-management-system/
├── src/
│   ├── KeimheanCafePOS.Domain/          # Business logic & design patterns
│   │   ├── DesignPatterns/
│   │   │   ├── Decorator/              # Decorator pattern
│   │   │   ├── Bridge/                 # Bridge pattern
│   │   │   ├── Composite/              # Composite pattern
│   │   │   ├── Prototype/              # Prototype pattern
│   │   └── Entities/                   # Database entities
│   ├── KeimheanCafePOS.Infrastructure/  # Data access & adapters
│   │   ├── DesignPatterns/
│   │   │   └── Adapter/                # Adapter pattern (payment gateways)
│   │   └── Data/
│   │       └── ApplicationDbContext.cs # EF Core context
│   ├── KeimheanCafePOS.Application/     # Application services
│   ├── KeimheanCafePOS.API/             # Web API
│   └── KeimheanCafePOS.Desktop/         # Avalonia UI
├── docs/
│   ├── DesignPatterns.md               # Design patterns documentation
│   ├── IMPLEMENTATION_SUMMARY.md       # Implementation status
│   └── Presentation/                   # Presentation materials
└── README.md
```

---

## Database Schema / រចនា Database

### Core Tables:
- **products** - Menu items
- **menu_categories** - Category hierarchy (Composite pattern)
- **combo_meals** - Combo meal deals
- **combo_meal_items** - Items in combos

### Order Management:
- **orders** - Customer orders
- **order_items** - Items in orders
- **order_customizations** - Decorator pattern tracking

### Customer & Tables:
- **customers** - Customer profiles
- **tables** - Restaurant tables

### Payments:
- **payment_transactions** - Payment records with gateway info

### Relationships:
- Orders → Customer (many-to-one)
- Orders → Table (many-to-one)
- Orders → OrderItems (one-to-many)
- OrderItems → OrderCustomizations (one-to-many)
- MenuCategory → Products (one-to-many)
- ComboMeal → ComboMealItems (one-to-many)

---

## Testing Design Patterns / ធ្វើតេស្ត Design Patterns

You can test the patterns in `Program.cs` or create a console app:

```csharp
// Test Decorator
var item = new BaseMenuItem("Coffee", 2.00m);
item = new MilkDecorator(item);
Console.WriteLine($"{item.GetDescription()} - ${item.GetPrice()}");

// Test Bridge
var cash = new CashPayment();
var order = new DineInOrder(cash) { TotalAmount = 10.00m };
order.ProcessPayment();

// Test Composite
var category = new MenuCategory("Drinks");
category.Add(new MenuItem("Coffee", 2.00m));
category.Display();

// Test Adapter
var stripe = new StripeAdapter();
var result = await stripe.ProcessPaymentAsync(new PaymentRequest { Amount = 10.00m });
Console.WriteLine($"Success: {result.Success}");

// Test Prototype
var order1 = new OrderPrototype { CustomerName = "Test" };
var order2 = order1.Clone();
Console.WriteLine($"Cloned: {order2.CustomerName}");
```

---

## Seed Data / ទិន្នន័យសាកល្បង

The system comes with seed data:

### Menu Categories:
- Coffee
- Tea
- Pastry
- Snack

### Tables:
- T1-T4 (Main section, capacity 2-6)
- T5-T6 (Outdoor section, capacity 2-4)
- VIP1-VIP2 (VIP section, capacity 6-8)

### Customers:
- Sokha Chan (150 loyalty points)
- Dara Keo (75 loyalty points)

### Combo Meals:
- Breakfast Combo (Coffee + Croissant) - $5.50
- Afternoon Tea Set (Tea + Cake) - $7.50

---

## Next Steps / ជំហានបន្ទាប់

1. ✅ Design patterns implemented
2. ✅ Database schema ready
3. ⚠️ Run database migration
4. ❌ Implement feature views (Menu, Order, Table, Customer, Payment, Reporting)
5. ❌ Complete documentation
6. ❌ Create presentation slides

---

## Troubleshooting / ដោះស្រាយបញ្ហា

### Database Connection Issues:
```bash
# Check if MySQL is running
docker ps

# Restart MySQL
docker compose -f KeimheanCafePOS/docker-compose.yml restart
```

### Build Errors:
```bash
# Clean and rebuild
dotnet clean
dotnet restore
dotnet build
```

### Migration Issues:
```bash
# Remove last migration
dotnet ef migrations remove

# Recreate
dotnet ef migrations add AddDesignPatternsEntities
dotnet ef database update
```

---

## Documentation / ឯកសារ

- [Design Patterns Guide](docs/DesignPatterns.md) - Detailed explanation of all 5 patterns
- [Implementation Summary](docs/IMPLEMENTATION_SUMMARY.md) - Current status and remaining work
- [API Documentation](http://localhost:5138/swagger) - When API is running

---

## Contact / ទំនាក់ទំនង

- Repository: https://github.com/Keimhean/coffee-management-system
- Issues: Report on GitHub Issues

---

## License

[Add your license here]

---

**Note**: This system demonstrates 5 design patterns for educational purposes. Features are partially implemented - see IMPLEMENTATION_SUMMARY.md for details.
