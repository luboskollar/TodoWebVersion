# TodoWebVersion

A full-stack task manager built with ASP.NET Core and vanilla JavaScript, with a terminal-inspired interface.

This is a web rewrite of my earlier console [task-manager](https://github.com/luboskollar/task-manager) project — same domain model, but rebuilt as a REST API with a real database and a browser frontend.

## Features

- Create tasks with a title, due date and priority
- Mark tasks as completed (`[ ]` / `[x]`)
- Delete tasks
- Filter by status (all / pending / completed)
- Completed-task counter
- Client-side validation with inline error messages
- Data persisted in a SQLite database

## Tech stack

**Backend**
- ASP.NET Core 8 Web API (controller-based)
- Entity Framework Core 8
- SQLite
- Swagger / OpenAPI for API documentation

**Frontend**
- Plain HTML, CSS and JavaScript — no frameworks
- `fetch()` for all API communication

## API

| Method | Endpoint                  | Description                  |
|--------|---------------------------|------------------------------|
| GET    | `/api/Todo`               | Get all tasks                |
| GET    | `/api/Todo/{id}`          | Get a single task            |
| GET    | `/api/Todo/status/{status}` | Get tasks by status        |
| POST   | `/api/Todo`               | Create a task                |
| PUT    | `/api/Todo/{id}`          | Update a task                |
| DELETE | `/api/Todo/{id}`          | Delete a task                |

`Priority`: `0` = Low, `1` = Medium, `2` = High
`Status`: `0` = Pending, `1` = InProgress, `2` = Completed

## Project structure

```
TodoWebVersion/
├── Controllers/
│   └── TodoController.cs      # REST endpoints
├── Data/
│   └── TodoDbContext.cs       # EF Core database context
├── Enums/
│   ├── Priority.cs
│   └── Status.cs
├── Models/
│   ├── TodoItem.cs            # Domain model
│   └── DTOs/
│       ├── CreateTodoDto.cs
│       └── UpdateTodoDto.cs
├── Migrations/                # EF Core migrations
├── wwwroot/                   # Frontend
│   ├── index.html
│   ├── style.css
│   └── script.js
└── Program.cs
```

## Running locally

Requires the [.NET 8 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/luboskollar/TodoWebVersion.git
cd TodoWebVersion

# create the database from the migrations
dotnet ef database update

dotnet run
```

Then open `https://localhost:7233/index.html` in your browser (check the console output for the actual port). Swagger UI is available at `/swagger`.

If you don't have the EF Core CLI tools installed:

```bash
dotnet tool install --global dotnet-ef
```

## Notes

This is a learning project — I built it to get familiar with ASP.NET Core, Entity Framework and frontend development after working mostly with console applications. Pay in mind, I used AI for learning and explaining me the concepts, so not everything could be right.

Possible future additions: showing due dates in the task list, user accounts so everyone has their own tasks, and calendar integration.
