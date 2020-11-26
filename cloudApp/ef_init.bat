dotnet ef migrations add Initial --context DataContext --output-dir Migrations/SqlServerMigrations -v
dotnet ef database update -v