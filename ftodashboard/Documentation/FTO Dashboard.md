# FTO Dashboard - Technical Documentation

## Table of Contents
1. [High-Level Overview](#high-level-overview)
2. [System Architecture](#system-architecture)
3. [Libraries and Frameworks](#libraries-and-frameworks)
4. [Third-Party Dependencies](#third-party-dependencies)
5. [Technical Specifications](#technical-specifications)
6. [Developer Quick Start Guide](#developer-quick-start-guide)
7. [API Documentation](#api-documentation)
8. [Database Schema](#database-schema)
9. [Configuration Management](#configuration-management)
10. [Testing & Deployment](#testing--deployment)
11. [Common Issues & Troubleshooting](#common-issues--troubleshooting)

---

## High-Level Overview

### Purpose and Business Context
The **FTO Dashboard** is a comprehensive web-based application designed to manage and monitor Field Training Officer (FTO) operations within organizational training programs. The system provides real-time visibility into training progress, officer assignments, trainee performance metrics, and administrative oversight capabilities.

### Key Business Scenarios
- **Training Coordination**: Administrators can assign FTOs to new recruits and track training milestones
- **Performance Monitoring**: Real-time dashboards display trainee progress, completion rates, and performance indicators
- **Resource Management**: Optimize FTO assignments based on availability, expertise, and workload distribution
- **Compliance Tracking**: Ensure all training requirements meet regulatory standards and organizational policies
- **Reporting & Analytics**: Generate comprehensive reports for management review and audit purposes

### System Architecture Overview
The FTO Dashboard follows a modern web application architecture with clear separation of concerns:

```
┌─────────────────────────────────────────────────────────────┐
│                    Client Layer                             │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐│
│  │  Admin Portal   │  │  FTO Interface  │  │ Trainee Portal  ││
│  │  (React SPA)    │  │  (React SPA)    │  │  (React SPA)    ││
│  └─────────────────┘  └─────────────────┘  └─────────────────┘│
└─────────────────────────────────────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                 API Gateway Layer                           │
│  ┌─────────────────────────────────────────────────────────┐│
│  │           ASP.NET Core Web API                          ││
│  │  ┌─────────────┐  ┌─────────────┐  ┌─────────────────┐  ││
│  │  │ Auth Service│  │ Training API│  │ Reporting API   │  ││
│  │  └─────────────┘  └─────────────┘  └─────────────────┘  ││
│  └─────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                 Business Logic Layer                        │
│  ┌─────────────────────────────────────────────────────────┐│
│  │              Core Services                              ││
│  │  ┌─────────────┐  ┌─────────────┐  ┌─────────────────┐  ││
│  │  │ User Mgmt   │  │ Training    │  │ Notification    │  ││
│  │  │ Service     │  │ Service     │  │ Service         │  ││
│  │  └─────────────┘  └─────────────┘  └─────────────────┘  ││
│  └─────────────────────────────────────────────────────────┘│
└─────────────────────────────────────────────────────────────┘
                               │
                               ▼
┌─────────────────────────────────────────────────────────────┐
│                    Data Layer                               │
│  ┌─────────────────┐  ┌─────────────────┐  ┌─────────────────┐│
│  │  SQL Server     │  │  Redis Cache    │  │  File Storage   ││
│  │  (Primary DB)   │  │  (Sessions)     │  │  (Documents)    ││
│  └─────────────────┘  └─────────────────┘  └─────────────────┘│
└─────────────────────────────────────────────────────────────┘
```

### Main Components
1. **Frontend Applications**: React-based single-page applications for different user roles
2. **API Gateway**: Centralized entry point for all client requests
3. **Business Services**: Core logic for training management, user operations, and reporting
4. **Data Layer**: Persistent storage and caching mechanisms
5. **Authentication & Authorization**: Identity management and role-based access control

### Data Flow and Process Workflow
```
1. User Authentication → 2. Role Validation → 3. Dashboard Loading
         │                       │                    │
         ▼                       ▼                    ▼
4. Real-time Updates ← 5. API Calls ← 6. User Actions
         │                       │                    │
         ▼                       ▼                    ▼
7. WebSocket Events → 8. Data Processing → 9. Database Updates
```

---

## System Architecture

### Component Relationships
The system is built using a microservices-inspired architecture with the following key relationships:

- **Frontend-to-API**: React applications communicate with backend services through RESTful APIs
- **Service-to-Service**: Internal services communicate via HTTP/HTTPS with proper authentication
- **Database Access**: Entity Framework Core provides ORM capabilities for SQL Server interactions
- **Caching Layer**: Redis serves as both session storage and application-level caching
- **Real-time Communication**: SignalR enables live updates for dashboard components

### Security Architecture
- **Authentication**: JWT tokens with refresh capability
- **Authorization**: Role-based access control (RBAC) with granular permissions
- **Data Protection**: SSL/TLS encryption for all communications
- **Input Validation**: Comprehensive server-side validation for all endpoints

---

## Libraries and Frameworks

### Frontend Libraries
#### React Framework Stack
```typescript
// Core React setup with TypeScript
import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';

// Example dashboard component structure
const FTODashboard: React.FC = () => {
  const [trainingData, setTrainingData] = useState<TrainingData[]>([]);
  
  useEffect(() => {
    fetchTrainingData();
  }, []);

  return (
    <div className="dashboard-container">
      <TrainingOverview data={trainingData} />
      <PerformanceMetrics />
      <AssignmentPanel />
    </div>
  );
};
```

#### State Management (Redux Toolkit)
```typescript
// Redux store configuration
import { configureStore } from '@reduxjs/toolkit';
import { trainingSlice } from './slices/trainingSlice';
import { authSlice } from './slices/authSlice';

export const store = configureStore({
  reducer: {
    training: trainingSlice.reducer,
    auth: authSlice.reducer,
  },
});

// Training slice example
const trainingSlice = createSlice({
  name: 'training',
  initialState: {
    assignments: [],
    loading: false,
    error: null,
  },
  reducers: {
    fetchAssignmentsStart: (state) => {
      state.loading = true;
    },
    fetchAssignmentsSuccess: (state, action) => {
      state.assignments = action.payload;
      state.loading = false;
    },
  },
});
```

#### UI Components (Material-UI)
```typescript
// Custom dashboard components using Material-UI
import { Card, CardContent, Grid, Typography } from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';

const TrainingMetricsCard: React.FC<{ metrics: MetricsData }> = ({ metrics }) => {
  return (
    <Card sx={{ minWidth: 275 }}>
      <CardContent>
        <Typography variant="h5" component="div">
          Training Progress
        </Typography>
        <Typography variant="body2">
          Completion Rate: {metrics.completionRate}%
        </Typography>
      </CardContent>
    </Card>
  );
};
```

### Backend Libraries
#### ASP.NET Core Web API
```csharp
// Main API controller structure
[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TrainingController : ControllerBase
{
    private readonly ITrainingService _trainingService;
    private readonly ILogger<TrainingController> _logger;

    public TrainingController(
        ITrainingService trainingService,
        ILogger<TrainingController> logger)
    {
        _trainingService = trainingService;
        _logger = logger;
    }

    [HttpGet("assignments")]
    public async Task<IActionResult> GetAssignments()
    {
        try
        {
            var assignments = await _trainingService.GetAssignmentsAsync();
            return Ok(assignments);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching assignments");
            return StatusCode(500, "Internal server error");
        }
    }

    [HttpPost("assignments")]
    public async Task<IActionResult> CreateAssignment([FromBody] CreateAssignmentRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var assignment = await _trainingService.CreateAssignmentAsync(request);
        return CreatedAtAction(nameof(GetAssignment), new { id = assignment.Id }, assignment);
    }
}
```

#### Entity Framework Core
```csharp
// DbContext configuration
public class FTODbContext : DbContext
{
    public FTODbContext(DbContextOptions<FTODbContext> options) : base(options) { }

    public DbSet<TrainingAssignment> TrainingAssignments { get; set; }
    public DbSet<FTOOfficer> FTOOfficers { get; set; }
    public DbSet<Trainee> Trainees { get; set; }
    public DbSet<TrainingModule> TrainingModules { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrainingAssignment>()
            .HasKey(ta => ta.Id);

        modelBuilder.Entity<TrainingAssignment>()
            .HasOne(ta => ta.FTOOfficer)
            .WithMany(fto => fto.Assignments)
            .HasForeignKey(ta => ta.FTOOfficerId);

        modelBuilder.Entity<TrainingAssignment>()
            .HasOne(ta => ta.Trainee)
            .WithMany(t => t.Assignments)
            .HasForeignKey(ta => ta.TraineeId);
    }
}
```

#### SignalR for Real-time Updates
```csharp
// SignalR Hub for real-time dashboard updates
public class DashboardHub : Hub
{
    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
    }
}

// Service to broadcast updates
public class NotificationService
{
    private readonly IHubContext<DashboardHub> _hubContext;

    public NotificationService(IHubContext<DashboardHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task NotifyAssignmentUpdate(int assignmentId, string status)
    {
        await _hubContext.Clients.All.SendAsync("AssignmentUpdated", new
        {
            AssignmentId = assignmentId,
            Status = status,
            Timestamp = DateTime.UtcNow
        });
    }
}
```

---

## Third-Party Dependencies

### Frontend Dependencies

| Package | Version | Purpose | Usage Example |
|---------|---------|---------|---------------|
| `react` | ^18.2.0 | Core UI library | Component development |
| `react-router-dom` | ^6.4.0 | Client-side routing | Navigation between dashboard views |
| `@reduxjs/toolkit` | ^1.9.0 | State management | Global application state |
| `@mui/material` | ^5.10.0 | UI component library | Dashboard components and styling |
| `@mui/x-data-grid` | ^5.17.0 | Data grid component | Training records display |
| `recharts` | ^2.5.0 | Chart library | Performance metrics visualization |
| `axios` | ^1.1.0 | HTTP client | API communication |
| `@microsoft/signalr` | ^7.0.0 | Real-time communication | Live dashboard updates |

#### Configuration Examples
```json
// package.json dependencies
{
  "dependencies": {
    "react": "^18.2.0",
    "react-dom": "^18.2.0",
    "react-router-dom": "^6.4.0",
    "@reduxjs/toolkit": "^1.9.0",
    "@mui/material": "^5.10.0",
    "@mui/x-data-grid": "^5.17.0",
    "recharts": "^2.5.0",
    "axios": "^1.1.0",
    "@microsoft/signalr": "^7.0.0"
  }
}
```

```typescript
// Axios configuration for API calls
import axios from 'axios';

const apiClient = axios.create({
  baseURL: process.env.REACT_APP_API_BASE_URL,
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

// Request interceptor for authentication
apiClient.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('authToken');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);
```

### Backend Dependencies

| Package | Version | Purpose | Usage Example |
|---------|---------|---------|---------------|
| `Microsoft.AspNetCore.App` | 7.0.0 | Web API framework | REST API development |
| `Microsoft.EntityFrameworkCore.SqlServer` | 7.0.0 | Database ORM | Data access layer |
| `Microsoft.AspNetCore.Authentication.JwtBearer` | 7.0.0 | JWT authentication | API security |
| `Microsoft.AspNetCore.SignalR` | 7.0.0 | Real-time communication | Live updates |
| `Swashbuckle.AspNetCore` | 6.4.0 | API documentation | Swagger/OpenAPI |
| `AutoMapper` | 12.0.0 | Object mapping | DTO transformations |
| `Serilog.AspNetCore` | 6.0.0 | Logging framework | Application logging |
| `StackExchange.Redis` | 2.6.0 | Redis client | Caching and sessions |

#### Configuration Examples
```xml
<!-- Project file dependencies -->
<PackageReference Include="Microsoft.AspNetCore.App" />
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.0" />
<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="7.0.0" />
<PackageReference Include="Microsoft.AspNetCore.SignalR" Version="7.0.0" />
<PackageReference Include="Swashbuckle.AspNetCore" Version="6.4.0" />
<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.0" />
<PackageReference Include="Serilog.AspNetCore" Version="6.0.0" />
<PackageReference Include="StackExchange.Redis" Version="2.6.0" />
```

```csharp
// Startup.cs service configuration
public void ConfigureServices(IServiceCollection services)
{
    // Database configuration
    services.AddDbContext<FTODbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    // Authentication configuration
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });

    // Redis configuration
    services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = Configuration.GetConnectionString("Redis");
    });

    // AutoMapper configuration
    services.AddAutoMapper(typeof(MappingProfile));

    // SignalR configuration
    services.AddSignalR();

    // Custom services
    services.AddScoped<ITrainingService, TrainingService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<INotificationService, NotificationService>();
}
```

---

## Technical Specifications

### File Structure and Organization
```
FTO_Dashboard/
├── src/
│   ├── Frontend/
│   │   ├── public/
│   │   │   ├── index.html
│   │   │   └── favicon.ico
│   │   ├── src/
│   │   │   ├── components/
│   │   │   │   ├── Dashboard/
│   │   │   │   │   ├── TrainingOverview.tsx
│   │   │   │   │   ├── MetricsCard.tsx
│   │   │   │   │   └── AssignmentPanel.tsx
│   │   │   │   ├── Common/
│   │   │   │   │   ├── Layout.tsx
│   │   │   │   │   ├── Navigation.tsx
│   │   │   │   │   └── LoadingSpinner.tsx
│   │   │   │   └── Auth/
│   │   │   │       ├── LoginForm.tsx
│   │   │   │       └── ProtectedRoute.tsx
│   │   │   ├── services/
│   │   │   │   ├── api.ts
│   │   │   │   ├── authService.ts
│   │   │   │   └── signalRService.ts
│   │   │   ├── store/
│   │   │   │   ├── index.ts
│   │   │   │   └── slices/
│   │   │   │       ├── authSlice.ts
│   │   │   │       └── trainingSlice.ts
│   │   │   ├── types/
│   │   │   │   ├── auth.ts
│   │   │   │   └── training.ts
│   │   │   ├── utils/
│   │   │   │   ├── constants.ts
│   │   │   │   └── helpers.ts
│   │   │   ├── App.tsx
│   │   │   └── index.tsx
│   │   ├── package.json
│   │   └── tsconfig.json
│   ├── Backend/
│   │   ├── FTO.API/
│   │   │   ├── Controllers/
│   │   │   │   ├── TrainingController.cs
│   │   │   │   ├── AuthController.cs
│   │   │   │   └── ReportsController.cs
│   │   │   ├── Hubs/
│   │   │   │   └── DashboardHub.cs
│   │   │   ├── Middleware/
│   │   │   │   ├── ErrorHandlingMiddleware.cs
│   │   │   │   └── JwtMiddleware.cs
│   │   │   ├── appsettings.json
│   │   │   ├── Program.cs
│   │   │   └── Startup.cs
│   │   ├── FTO.Core/
│   │   │   ├── Models/
│   │   │   │   ├── TrainingAssignment.cs
│   │   │   │   ├── FTOOfficer.cs
│   │   │   │   └── Trainee.cs
│   │   │   ├── Services/
│   │   │   │   ├── ITrainingService.cs
│   │   │   │   ├── TrainingService.cs
│   │   │   │   └── UserService.cs
│   │   │   └── DTOs/
│   │   │       ├── CreateAssignmentRequest.cs
│   │   │       └── AssignmentResponse.cs
│   │   ├── FTO.Data/
│   │   │   ├── Context/
│   │   │   │   └── FTODbContext.cs
│   │   │   ├── Repositories/
│   │   │   │   ├── ITrainingRepository.cs
│   │   │   │   └── TrainingRepository.cs
│   │   │   └── Migrations/
│   │   └── FTO.Tests/
│   │       ├── Unit/
│   │       ├── Integration/
│   │       └── E2E/
├── docs/
│   ├── api-documentation.md
│   ├── deployment-guide.md
│   └── user-manual.md
├── scripts/
│   ├── build.sh
│   ├── deploy.sh
│   └── database-setup.sql
├── docker-compose.yml
├── Dockerfile
├── README.md
└── .gitignore
```

### Key Configuration Files

#### Frontend Configuration (tsconfig.json)
```json
{
  "compilerOptions": {
    "target": "es5",
    "lib": [
      "dom",
      "dom.iterable",
      "es6"
    ],
    "allowJs": true,
    "skipLibCheck": true,
    "esModuleInterop": true,
    "allowSyntheticDefaultImports": true,
    "strict": true,
    "forceConsistentCasingInFileNames": true,
    "module": "esnext",
    "moduleResolution": "node",
    "resolveJsonModule": true,
    "isolatedModules": true,
    "noEmit": true,
    "jsx": "react-jsx"
  },
  "include": [
    "src"
  ]
}
```

#### Backend Configuration (appsettings.json)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FTO_Dashboard;Trusted_Connection=true;MultipleActiveResultSets=true",
    "Redis": "localhost:6379"
  },
  "Jwt": {
    "Key": "your-secret-key-here",
    "Issuer": "FTO-Dashboard",
    "Audience": "FTO-Dashboard-Users",
    "ExpiryHours": 24
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

### Database Schema

#### Core Entity Models
```csharp
public class TrainingAssignment
{
    public int Id { get; set; }
    public int FTOOfficerId { get; set; }
    public int TraineeId { get; set; }
    public int TrainingModuleId { get; set; }
    public DateTime AssignedDate { get; set; }
    public DateTime? CompletedDate { get; set; }
    public TrainingStatus Status { get; set; }
    public string Notes { get; set; }
    
    // Navigation properties
    public FTOOfficer FTOOfficer { get; set; }
    public Trainee Trainee { get; set; }
    public TrainingModule TrainingModule { get; set; }
}

public class FTOOfficer
{
    public int Id { get; set; }
    public string EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public DateTime HireDate { get; set; }
    public bool IsActive { get; set; }
    
    // Navigation properties
    public List<TrainingAssignment> Assignments { get; set; }
}

public class Trainee
{
    public int Id { get; set; }
    public string EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime StartDate { get; set; }
    public TraineeStatus Status { get; set; }
    
    // Navigation properties
    public List<TrainingAssignment> Assignments { get; set; }
}

public enum TrainingStatus
{
    Assigned = 1,
    InProgress = 2,
    Completed = 3,
    Failed = 4,
    Cancelled = 5
}
```

---

## Developer Quick Start Guide

### Prerequisites
- **Node.js** (v16+)
- **npm** or **yarn**
- **.NET 7.0 SDK**
- **SQL Server** (LocalDB acceptable for development)
- **Redis** (optional for development, uses in-memory cache fallback)
- **Visual Studio 2022** or **VS Code**

### Local Development Setup

#### 1. Clone and Setup Repository
```bash
# Clone the repository
git clone https://github.com/frankrogerrm/FTO_Dashboard.git
cd FTO_Dashboard

# Install frontend dependencies
cd src/Frontend
npm install

# Restore backend dependencies
cd ../Backend
dotnet restore
```

#### 2. Database Setup
```bash
# Navigate to the data project
cd FTO.Data

# Create and apply migrations
dotnet ef migrations add InitialCreate --startup-project ../FTO.API
dotnet ef database update --startup-project ../FTO.API
```

#### 3. Configuration
```bash
# Backend - Update appsettings.Development.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FTO_Dashboard_Dev;Trusted_Connection=true;",
    "Redis": "localhost:6379"
  },
  "Jwt": {
    "Key": "development-secret-key-at-least-32-characters-long",
    "Issuer": "FTO-Dashboard-Dev",
    "Audience": "FTO-Dashboard-Dev-Users",
    "ExpiryHours": 24
  }
}

# Frontend - Create .env file in Frontend directory
REACT_APP_API_BASE_URL=https://localhost:5001/api
REACT_APP_SIGNALR_URL=https://localhost:5001/dashboardHub
```

#### 4. Running the Application
```bash
# Terminal 1: Start backend API
cd src/Backend/FTO.API
dotnet run

# Terminal 2: Start frontend development server
cd src/Frontend
npm start
```

### Key Entry Points for New Developers

#### Backend Entry Points
1. **Program.cs** - Application startup and configuration
2. **TrainingController.cs** - Main API endpoints for training operations
3. **TrainingService.cs** - Core business logic implementation
4. **FTODbContext.cs** - Database context and entity configuration

#### Frontend Entry Points
1. **App.tsx** - Main application component and routing
2. **components/Dashboard/TrainingOverview.tsx** - Main dashboard component
3. **services/api.ts** - API communication layer
4. **store/slices/trainingSlice.ts** - State management for training data

### Most Frequently Modified Files
- **Frontend**: `TrainingOverview.tsx`, `MetricsCard.tsx`, `api.ts`
- **Backend**: `TrainingController.cs`, `TrainingService.cs`, `TrainingAssignment.cs`
- **Database**: Migration files when schema changes occur

### Testing Strategy
```bash
# Backend unit tests
cd src/Backend/FTO.Tests
dotnet test

# Frontend tests
cd src/Frontend
npm test

# Integration tests
cd src/Backend/FTO.Tests/Integration
dotnet test
```

---

## API Documentation

### Authentication Endpoints
```
POST /api/auth/login
Content-Type: application/json

{
  "username": "admin@example.com",
  "password": "password123"
}

Response: 200 OK
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expires": "2024-07-10T09:25:00Z",
  "user": {
    "id": 1,
    "username": "admin@example.com",
    "roles": ["Admin"]
  }
}
```

### Training Management Endpoints
```
GET /api/training/assignments
Authorization: Bearer {token}

Response: 200 OK
[
  {
    "id": 1,
    "ftoOfficerId": 5,
    "traineeId": 10,
    "trainingModuleId": 2,
    "assignedDate": "2024-07-01T00:00:00Z",
    "status": "InProgress",
    "notes": "Making good progress on defensive tactics"
  }
]

POST /api/training/assignments
Authorization: Bearer {token}
Content-Type: application/json

{
  "ftoOfficerId": 5,
  "traineeId": 10,
  "trainingModuleId": 2,
  "notes": "Initial assignment for new recruit"
}

Response: 201 Created
{
  "id": 15,
  "ftoOfficerId": 5,
  "traineeId": 10,
  "trainingModuleId": 2,
  "assignedDate": "2024-07-09T14:30:00Z",
  "status": "Assigned",
  "notes": "Initial assignment for new recruit"
}
```

### Reporting Endpoints
```
GET /api/reports/training-progress?startDate=2024-07-01&endDate=2024-07-31
Authorization: Bearer {token}

Response: 200 OK
{
  "totalAssignments": 145,
  "completedAssignments": 98,
  "inProgressAssignments": 32,
  "completionRate": 67.6,
  "averageCompletionTime": "14.5 days",
  "byStatus": {
    "Assigned": 15,
    "InProgress": 32,
    "Completed": 98,
    "Failed": 0,
    "Cancelled": 0
  }
}
```

---

## Configuration Management

### Environment-Specific Settings
```csharp
// appsettings.Production.json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=prod-sql-server;Database=FTO_Dashboard;User Id=fto_user;Password=****;",
    "Redis": "prod-redis-cluster:6379"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "Microsoft.AspNetCore": "Error"
    }
  },
  "AllowedHosts": "*.yourdomain.com"
}
```

### Docker Configuration
```dockerfile
# Dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FTO.API/FTO.API.csproj", "FTO.API/"]
RUN dotnet restore "FTO.API/FTO.API.csproj"
COPY . .
WORKDIR "/src/FTO.API"
RUN dotnet build "FTO.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FTO.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FTO.API.dll"]
```

```yaml
# docker-compose.yml
version: '3.8'

services:
  fto-api:
    build: .
    ports:
      - "5000:80"
    depends_on:
      - sql-server
      - redis
    environment:
      - ASPNETCORE_ENVIRONMENT=Production
      - ConnectionStrings__DefaultConnection=Server=sql-server;Database=FTO_Dashboard;User Id=sa;Password=YourStrong@Passw0rd;
      - ConnectionStrings__Redis=redis:6379

  sql-server:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - SA_PASSWORD=YourStrong@Passw0rd
      - ACCEPT_EULA=Y
    ports:
      - "1433:1433"

  redis:
    image: redis:7-alpine
    ports:
      - "6379:6379"

  fto-frontend:
    build: ./src/Frontend
    ports:
      - "3000:80"
    depends_on:
      - fto-api
```

---

## Testing & Deployment

### Unit Testing Examples
```csharp
// TrainingServiceTests.cs
[TestClass]
public class TrainingServiceTests
{
    private Mock<ITrainingRepository> _mockRepository;
    private TrainingService _trainingService;

    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<ITrainingRepository>();
        _trainingService = new TrainingService(_mockRepository.Object);
    }

    [TestMethod]
    public async Task GetAssignmentsAsync_ShouldReturnAssignments()
    {
        // Arrange
        var expectedAssignments = new List<TrainingAssignment>
        {
            new TrainingAssignment { Id = 1, FTOOfficerId = 1, TraineeId = 1 }
        };
        _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(expectedAssignments);

        // Act
        var result = await _trainingService.GetAssignmentsAsync();

        // Assert
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual(1, result[0].Id);
    }
}
```

### Frontend Testing
```typescript
// TrainingOverview.test.tsx
import { render, screen } from '@testing-library/react';
import { Provider } from 'react-redux';
import { store } from '../store';
import TrainingOverview from './TrainingOverview';

describe('TrainingOverview', () => {
  test('renders training overview component', () => {
    render(
      <Provider store={store}>
        <TrainingOverview />
      </Provider>
    );
    
    expect(screen.getByText('Training Overview')).toBeInTheDocument();
  });
});
```

### Deployment Pipeline
```yaml
# .github/workflows/deploy.yml
name: Deploy to Production

on:
  push:
    branches: [ main ]

jobs:
  test:
    runs-on: ubuntu-latest
    steps:
    - uses: actions/checkout@v3
    - name: Setup .NET
      uses: actions/setup-dotnet@v3
      with:
        dotnet-version: '7.0.x'
    - name: Run tests
      run: dotnet test

  deploy:
    needs: test
    runs-on: ubuntu-latest
    steps:
    - name: Deploy to Azure
      uses: azure/webapps-deploy@v2
      with:
        app-name: 'fto-dashboard'
        package: './publish'
```

---

## Common Issues & Troubleshooting

### Database Connection Issues
```csharp
// Common error: Unable to connect to SQL Server
// Solution: Check connection string and ensure SQL Server is running
// Add to appsettings.Development.json:
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=FTO_Dashboard_Dev;Trusted_Connection=true;ConnectRetryCount=0"
  }
}
```

### CORS Issues
```csharp
// Add to Startup.cs ConfigureServices method
services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

// Add to Configure method
app.UseCors("AllowReactApp");
```

### SignalR Connection Issues
```typescript
// Frontend: SignalR connection troubleshooting
const connection = new HubConnectionBuilder()
    .withUrl("/dashboardHub", {
        withCredentials: true,
        headers: {
            "Authorization": `Bearer ${token}`
        }
    })
    .withAutomaticReconnect()
    .build();

connection.onreconnecting(() => {
    console.log("SignalR reconnecting...");
});

connection.onreconnected(() => {
    console.log("SignalR reconnected");
});
```

### Performance Optimization
```csharp
// Add caching to frequently accessed data
public class TrainingService
{
    private readonly IMemoryCache _cache;
    
    public async Task<List<TrainingAssignment>> GetAssignmentsAsync()
    {
        return await _cache.GetOrCreateAsync("training-assignments", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            return await _repository.GetAllAsync();
        });
    }
}
```

### Common Debugging Commands
```bash
# Check application logs
dotnet run --verbosity diagnostic

# Clear Entity Framework cache
dotnet ef database drop --force
dotnet ef database update

# Reset npm cache
npm cache clean --force
rm -rf node_modules package-lock.json
npm install

# Check Redis connection
redis-cli ping
```

---

## Bottom Line Up Front (BLUF)

The **FTO Dashboard** is a comprehensive training management system built with React frontend and ASP.NET Core backend. Key architectural decisions include:

- **Modern Stack**: React 18 + TypeScript, ASP.NET Core 7, SQL Server, Redis
- **Real-time Updates**: SignalR for live dashboard updates
- **Security**: JWT authentication with role-based access control
- **Scalability**: Microservices-ready architecture with Docker support
- **Developer Experience**: Comprehensive testing, clear documentation, and automated deployment

**Quick Start**: Clone repository → Install dependencies → Setup database → Run `dotnet run` (backend) + `npm start` (frontend)

**Key Files to Modify**: `TrainingController.cs`, `TrainingService.cs`, `TrainingOverview.tsx`, `api.ts`
