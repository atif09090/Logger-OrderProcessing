# 🧾 Logger-OrderProcessing

This is a .NET 8 Web API project that demonstrates **good vs bad logging practices** using `ILogger` and `Serilog`. The application simulates a real-world order processing endpoint.

---

## 🚀 Project Goals

- Demonstrate the **importance of structured logging**
- Show how **bad logging** can expose sensitive data or be noisy
- Provide a clear, real-world **contrast between poor and proper logging** techniques
- Use **Serilog** for structured logging
- Introduce **correlation ID middleware** to trace requests across services

---

## 🏗️ Project Structure

OrderProcessing.Api/
│
├── Controllers/
│ ├── LegacyLoggerController.cs <-- Bad logging practices
│ └── EfficientLoggerController.cs <-- Secure, structured logging
│
├── Middleware/
│ └── CorrelationIdMiddleware.cs <-- Adds correlation ID per request
│
├── Models/
│ └── Order.cs <-- Simple Order model
│
├── Program.cs <-- Serilog + middleware setup
└── README.md


---

## 📦 Required NuGet Packages

Install the following NuGet packages before running:

```bash
dotnet add package Serilog.AspNetCore
dotnet add package Serilog.Sinks.Console
