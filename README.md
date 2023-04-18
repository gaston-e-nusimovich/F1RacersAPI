# F1RacersAPI
Simple example of ASP.NET Core Web API; Clean Architecture (Ports and Adapters); EF Core 7

Connection string is declared  and assigned in Connection String section (DefaultConnection key) at appsettings.json configuration file.

This application uses EF Core migrations to set up and apply changes to app DB; before running the app for the first time, app DB must be created by dev (then, adjust connection string in appsettings.json to proper value for app DB created), then EF migration must be run in order to create DB schema in app DB. Once the app DB and its DB schema are created, the application can be executed.



The app was developed incrementally, following a simple agile slicing technique inspired by Alistair Cockburn's [Elephant Carpaccio](https://alistair.cockburn.us/wp-content/uploads/2018/02/Elephant-Carpaccio-exercise-instructions.pdf). Each increment of the slices has been committed to a branch (GEN-DEV), and then merged into main, in sequence. If interested on the slicing technique, just check out each commit at GEN-DEV.






