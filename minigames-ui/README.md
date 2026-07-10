# 🎮 Angular Mini Games

A collection of interactive browser games built with Angular and Bootstrap.

The application features 2 games, score tracking, responsive layouts, and a customizable dark mode experience.

---

## Features

### 🧩 Formula Game
- Generate and solve mathematical expressions
- Multiple difficulty levels
- Real-time answer validation
- Score tracking
- Game instructions accordion

### 🎯 Hangman Game
- Random word generation
- Visual life tracker
- Letter guessing system
- Win/Loss detection
- Score tracking

### 🏆 Leaderboard
- Stores high scores
- Ranking display
- Top player statistics

### 🌙 Dark Mode
- Global theme toggle
- Consistent styling across all pages
- Bootstrap component customization
- Responsive color scheme

---

## Technologies Used

- Angular
- .NET 10
- ASP.NET Core Web API
- Swagger
- SQL Server
- TypeScript
- Bootstrap 5
- HTML5
- SCSS

---

## Project Structure

```text

 Minigames/
  ├── Minigames.Api/
  ├── Minigames.Domain/
  ├── Minigames.Infrastructure/
  ├── Minigames.Persistence/
  └── minigames-ui/

```

### Domain
Contains core entities and business rules:
- Player
- PlayerGameSummary
- HangmanGameResult
- FormulaGameResult

### Application
Contains:
- DTOs
- Interfaces
- Services
- Use-case logic

### Persistence
Contains:
- Entity Framework Core
- SQL Server configuration
- MinigamesDbContext
- PlayerRepository
- Word file provider

### Infrastructure
- Reserved for technical or external services.

### Api
Contains:
- Controllers
- Swagger
- CORS
- Global exception middleware
- Dependency injection setup

### Onion Architecture
Dependencies point inward:
 Api -> Application -> Domain
 Persistence -> Application and Domain
 Infrastructure -> Application and Domain

The Domain layer does not depend on any outer layer.

Dependency Injection
Service registrations are grouped by layer:
- builder.Services.AddApplication();
- builder.Services.AddInfrastructure();
- builder.Services.AddPersistence(builder.Configuration);

Controllers and services receive dependencies through constructor injection.

### Global Exception Handling
The API uses global exception middleware.
- ArgumentException returns 400
- KeyNotFoundException returns 404
- Unexpected errors return 500

This avoids repeating try/catch blocks in controllers.

### Design Pattern Decisions

#### Repository Pattern
Used in:
- IPlayerRepository
- PlayerRepository

It separates database access from application logic.

### Dependency Injection
Used throughout controllers, services and repositories.
It allows classes to depend on interfaces instead of creating concrete objects themselves.

### Strategy Pattern
Used through:
- IWordProvider
- TextFileWordProvider
- HangmanService

HangmanService does not directly read the text file. It depends on IWordProvider. This allows the word source to be replaced later with a database, API or fake implementation.

### Main Endpoints
#### Players
POST /api/players
GET /api/players/{playerName}
GET /api/players/{playerName}/game-summary
#### Hangman
POST /api/hangman/start/{playerName}
POST /api/hangman/guess
#### Formula Game
GET /api/formula/start/{playerName}
POST /api/formula/submit
#### Leaderboard
GET /api/leaderboard
GET /api/leaderboard/hangman
GET /api/leaderboard/formula

## Installation

Clone the repository:

```bash
git clone <repository-url>
```

Navigate to the project folder:

```bash
cd angular-mini-games
```

Install dependencies:

```bash
npm install
```

---

## Running the Application

Start the development server:

```bash
ng serve
```

Open the application in your browser:

```text
http://localhost:4200
```

The application will automatically reload whenever source files are modified.

---

## Build

Create a production build:

```bash
ng build
```

Build artifacts will be generated in:

```text
dist/
```

---

## Styling

The application supports both Light Mode and Dark Mode using SCSS variables.

Example:

```scss
:root {
  --page-bg: #faf9f0;
  --page-text: #121435;
}

body.dark-mode {
  --page-bg: #222831;
  --page-text: #faf9f0;
}
```

Theme changes are applied globally across all pages and game components.

---

## Future Improvements

- Additional game modes
- Player profiles
- Player statistics dashboard
- Sound effects and animations
- Persistent user preferences and settings

---

## Author

Developed by **KarishJo** as part of an Angular learning project.
