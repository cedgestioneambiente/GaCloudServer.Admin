@echo off
set migrationName=%1
echo "Aggiunta Migrazione " %migrationName%
dotnet ef migrations add %migrationName% -c ResourcesDbContext -o Migrations\Resources
