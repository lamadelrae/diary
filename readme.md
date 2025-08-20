# Personal Diary CLI App

A simple command-line diary application built with .NET Core and Entity Framework Core with SQLite storage.

## Features

- ✅ Add new diary entries with title and content
- ✅ View all diary entries with preview
- ✅ View specific entries by ID
- ✅ Update existing entries
- ✅ Delete entries with confirmation
- ✅ Local SQLite database storage
- ✅ Clean console interface

## Requirements

- .NET 8.0 or later
- No additional dependencies required

## Installation & Usage

1. Clone or download this repository
2. Navigate to the project directory
3. Run the application:

```bash
dotnet run
```

## Project Structure

```
├── Models/
│   └── DiaryEntry.cs         # Data model for diary entries
├── Data/
│   └── DiaryContext.cs       # Entity Framework context
├── Handlers/
│   ├── AddEntryHandler.cs    # Handler for adding new entries
│   ├── FetchEntryByIdHandler.cs    # Handler for fetching specific entry
│   ├── FetchAllEntriesHandler.cs   # Handler for fetching all entries
│   ├── UpdateEntryHandler.cs       # Handler for updating entries
│   └── DeleteEntryHandler.cs       # Handler for deleting entries
├── Utils/
│   └── ConsoleHelper.cs      # Console utilities and helpers
├── Program.cs                # Main application entry point
└── diary.db                  # SQLite database (created automatically)
```

## Database Schema

The application uses a simple SQLite database with the following table:

**DiaryEntries**
- Id (int, primary key, auto-increment)
- Title (string, max 200 characters, required)
- Content (string, required)
- CreatedAt (DateTime, required)
- UpdatedAt (DateTime, nullable)

## Architecture

This application follows a simple handler pattern with:
- **No dependency injection** - Pure .NET approach for fast processing
- **No repository layer** - Direct use of EF Core context
- **Handler separation** - Each operation has its own handler class
- **Single project structure** - All components in main project

## Database Operations

The application automatically creates the SQLite database file (`diary.db`) on first run. All data is stored locally and persists between application sessions.
