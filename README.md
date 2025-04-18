# Job Tracker Dotnet

This project is built using .NET framework and is complementary to the Job Tracker Client project. It requires certain environment variables to be set up for proper configuration.

## Environment Setup

Before running the project, you need to set up your PostgreSQL DB.
Start by running the `CREATE_TABLES` script in `PostgreSQL Db` folder.
After that, you'll need to set some variables in order to construct a ConnectionString within the .NET project.
In `JobTrackerAPI.WebAPI/appsettings.json`, replace `DB_NAME`,`DB_USERNAME` and `DB_PASSWORD` with your own values in order to establish connection with your PostgreSQL Db.
