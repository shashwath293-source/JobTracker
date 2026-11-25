# Job Tracker API

A REST API for tracking job applications, built with ASP.NET Core (C#).

## Features
- Full CRUD: GET, POST, PUT and DELETE endpoints
- Controller and service layers, wired together with dependency injection
- Proper status codes: 200, 201, 204, 400 and 404

## Endpoints
| Method | Route | Description |
|--------|-------|-------------|
| GET | /api/applications | List all applications |
| GET | /api/applications/{id} | Get one application |
| POST | /api/applications | Create an application |
| PUT | /api/applications/{id} | Update an application |
| DELETE | /api/applications/{id} | Delete an application |

## Run it
dotnet run

## Notes
This is an AI-assisted learning project. Data is stored in memory, so it resets when the app restarts. Next steps: unit tests with xUnit and a database.