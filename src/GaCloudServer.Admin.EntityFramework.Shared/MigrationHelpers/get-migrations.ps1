$projectName = "GaCloudServer";
$currentPath = Get-Location
Set-Location "../../$projectName.Admin"



#Initialze db context and define the target directory
$targetContexts = @{ 
    dbContext= "Migrations\Resources"
}

#Initialize the db providers and it's respective projects
$dpProviders = @{
    SqlServer  = "..\..\src\$projectName.Admin.EntityFramework.SqlServer\$projectName.Admin.EntityFramework.SqlServer.csproj";
    PostgreSQL = "..\..\src\$projectName.Admin.EntityFramework.PostgreSQL\$projectName.Admin.EntityFramework.PostgreSQL.csproj";
    MySql      = "..\..\src\$projectName.Admin.EntityFramework.MySql\$projectName.Admin.EntityFramework.MySql.csproj";
}

$projectPath=(Get-Item -Path $dpProviders['SqlServer'] -Verbose).FullName;
$context='ResourcesDbContext';

dotnet ef migrations list -c $context -p $projectPath

Set-Location $currentPath

