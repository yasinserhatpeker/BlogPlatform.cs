# Blog Platform Project

A modern blog platform built with .NET Entity Framework Core and MySQL, designed for publishing content about News, Politics, Sports, and various other topics.

## 🚀 Features

- **Multi-Category Content**: Support for News, Politics, Sports, and custom categories
- **User Management**: Registration, authentication, and user profiles
- **Content Management**: Create, edit, delete, and publish blog posts
- **Responsive Design**: Mobile-friendly interface
- **Database Integration**: MySQL database with Entity Framework Core
- **Modern Architecture**: Clean, maintainable .NET Core structure

## 🛠 Technologies Used

- **.NET Core**: Backend framework
- **Entity Framework Core**: Object-Relational Mapping (ORM)
- **MySQL**: Database management system
- **C#**: Primary programming language
- **HTML/CSS/JavaScript**: Frontend technologies
- **Bootstrap**: CSS framework for responsive design

## 📋 Prerequisites

Before running this project, make sure you have the following installed:

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) 8.0 or later
- [Visual Studio](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/)

## ⚡ Quick Start

### 1. Clone the Repository

```bash
git clone https://github.com/yasinserhatpeker/BlogPlatform.cs.git
cd BlogPlatform.cs
```

### 2. Configure Database Connection

Update the connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BlogPlatformDB;User=your_username;Password=your_password;"
  }
}
```

### 3. Install Dependencies

```bash
dotnet restore
```

### 4. Run Database Migrations

```bash
dotnet ef database update
```

### 5. Build and Run

```bash
dotnet build
dotnet run
```

The application will be available at `https://localhost:5001` or `http://localhost:5000`.

## 🗄 Database Setup

### Create MySQL Database

```sql
CREATE DATABASE BlogPlatformDB;
CREATE USER 'blog_user'@'localhost' IDENTIFIED BY 'your_secure_password';
GRANT ALL PRIVILEGES ON BlogPlatformDB.* TO 'blog_user'@'localhost';
FLUSH PRIVILEGES;
```

### Entity Framework Commands

```bash
# Add a new migration
dotnet ef migrations add MigrationName

# Update database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## 📁 Project Structure

```
BlogPlatform.cs/
├── Controllers/          # MVC Controllers
├── Models/              # Data models and entities
├── Views/               # Razor view templates
├── Data/                # DbContext and database configuration
├── Services/            # Business logic services
├── wwwroot/             # Static files (CSS, JS, images)
├── Migrations/          # Entity Framework migrations
├── appsettings.json     # Configuration settings
└── Program.cs           # Application entry point
```

## 🔧 Configuration

### Application Settings

Key configuration options in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your MySQL connection string"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Environment Variables

For production deployment, consider using environment variables:

- `ASPNETCORE_ENVIRONMENT`
- `ConnectionStrings__DefaultConnection`
- `ASPNETCORE_URLS`

## 🚀 Deployment

### Local Development

```bash
dotnet run --environment Development
```

### Production Deployment

```bash
dotnet publish -c Release -o ./publish
```

### Docker (Optional)

If you prefer using Docker, create a `Dockerfile`:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlogPlatform.cs.csproj", "."]
RUN dotnet restore "./BlogPlatform.cs.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BlogPlatform.cs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlogPlatform.cs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BlogPlatform.cs.dll"]
```

## 🧪 Testing

Run the test suite:

```bash
dotnet test
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines

- Follow C# coding conventions
- Write unit tests for new features
- Update documentation as needed
- Ensure all tests pass before submitting PR

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Yasin Serhat Peker**
- GitHub: [@yasinserhatpeker](https://github.com/yasinserhatpeker)

## 🙏 Acknowledgments

- .NET Core team for the excellent framework
- Entity Framework Core contributors
- MySQL development team
- Open source community

## 📞 Support

If you have any questions or need help with the project:

- Create an [issue](https://github.com/yasinserhatpeker/BlogPlatform.cs/issues)
- Check existing [discussions](https://github.com/yasinserhatpeker/BlogPlatform.cs/discussions)

---

⭐ **Star this repository if you find it helpful!**
