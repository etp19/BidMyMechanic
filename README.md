# BidMyMechanic

BidMyMechanic is a .Net Core & Angular web application.

## Installation

Use the package Ef tools to install and use database migrations, use -g or --global for global usage.

```bash
dotnet tool install --global dotnet-ef
```

## Migrations

Use the following code to create a migration and update the database based on the previously ran migration.

```bash
dotnet ef migrations add initialMigration

dotnet ef database update
```
