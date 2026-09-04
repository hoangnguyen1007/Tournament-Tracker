# Tournament Tracker

Tournament Tracker is a C# Windows Forms desktop application designed to streamline the management of competitive tournaments. It provides a complete workflow for registering teams, configuring brackets, logging match scores, and tracking overall tournament progress using a Microsoft SQL Server database.

## Key Features

- **Tournament Configuration**: Set up new tournaments, define entry fees, and allocate prize distributions.
- **Team Management**: Register teams, add players, and manage participant data.
- **Bracket Generation**: Automatically schedule matchups and organize rounds based on the number of participating teams.
- **Match Scoring**: Record scores for individual fixtures and automatically advance winning teams to the next round.
- **Dashboard Overview**: Monitor active tournaments, view upcoming fixtures, and track completed matches from a centralized dashboard.
- **Data Persistence**: Reliable data management using SQL Server, ensuring consistent state tracking across application sessions.

## Tech Stack

- **Language**: C# (.NET Framework)
- **UI Framework**: Windows Forms (WinForms)
- **Database Engine**: Microsoft SQL Server
- **Data Access**: ADO.NET (encapsulated within `DatabaseHelper`)

## Project Structure

The application is structured to separate data access from UI logic:

- `Database/TournamentTracker.sql`: The SQL script containing the schema, tables, and relationships.
- `App.config`: Stores the database connection string and application settings.
- `DatabaseHelper.cs`: A utility class handling SQL connection pooling, command execution, and data retrieval.
- `Home.cs`: The main dashboard for viewing tournament progress and matchups.
- `CreaTourForm.cs`: The interface for creating and configuring new tournaments.
- `InfoMatchForm.cs`: The interface for inspecting match details and submitting scores.

## Setup and Installation

### 1. Database Configuration
1. Open SQL Server Management Studio (SSMS) or Azure Data Studio.
2. Open and execute the `TournamentTracker/Database/TournamentTracker.sql` script.
3. Verify that the `TournamentTracker` database and all required tables have been created successfully.

### 2. Application Configuration
1. Open the solution file (`TournamentTracker.sln`) in Visual Studio.
2. Locate the `App.config` file in the main project directory.
3. Update the `connectionStrings` section to point to your local SQL Server instance:

    <connectionStrings>
      <add name="TournamentTracker" 
           connectionString="Server=YOUR_SERVER_NAME;Database=TournamentTracker;Trusted_Connection=True;" 
           providerName="System.Data.SqlClient" />
    </connectionStrings>

### 3. Build and Run
1. Set the build configuration to `Debug` or `Release`.
2. Build the solution (Ctrl + Shift + B).
3. Run the application (F5).

## Usage Flow

1. Launch the application to access the `Home` dashboard.
2. Navigate to `CreaTourForm` to initialize a new tournament, add teams, and configure the prize pool.
3. Once the tournament is created, the system will generate the first round of matchups.
4. Select a matchup from the dashboard to open `InfoMatchForm`.
5. Enter the final score for the match and submit. The system will automatically move the winner to the next bracket until a champion is crowned.
