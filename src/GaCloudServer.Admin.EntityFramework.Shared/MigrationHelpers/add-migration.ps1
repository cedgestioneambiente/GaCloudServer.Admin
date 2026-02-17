param([string] $migration = 'DbInit', [string] $migrationProviderName = 'SqlServer', [string] $targetContext = 'All')
$projectName = "GaCloudServer";
$currentPath = Get-Location
Set-Location "../../$projectName.Admin"
Copy-Item appsettings.json -Destination appsettings-backup.json
$settings = Get-Content appsettings.json -raw

#Initialze db context and define the target directory
$targetContexts = @{ 
    ResourcesDbContext= "Migrations/Resources"
}

#Initialize the db providers and it's respective projects
$dpProviders = @{
    SqlServer  = "../../src/$projectName.Admin.EntityFramework.SqlServer/$projectName.Admin.EntityFramework.SqlServer.csproj";
    PostgreSQL = "../../src/$projectName.Admin.EntityFramework.PostgreSQL/$projectName.Admin.EntityFramework.PostgreSQL.csproj";
    MySql      = "../../src/$projectName.Admin.EntityFramework.MySql/$projectName.Admin.EntityFramework.MySql.csproj";
}

#Fix issue when the tools is not installed and the nuget package does not work see https://github.com/MicrosoftDocs/azure-docs/issues/40048
# Required EF Tools version (match your project EF Core major)
$requiredEfVersion = "8.0.11"

Write-Host "Checking dotnet-ef tools version..."
$efInstalled = $false
$efVersion = $null

try {
    $efVersionOutput = dotnet ef --version 2>$null
    if ($LASTEXITCODE -eq 0 -and $efVersionOutput) {
        $efInstalled = $true
        $efVersion = $efVersionOutput.Trim()
    }
}
catch {
    $efInstalled = $false
}

if (-not $efInstalled) {
    Write-Host "dotnet-ef not installed. Installing version $requiredEfVersion"
    dotnet tool install --global dotnet-ef --version $requiredEfVersion
}
else {
    Write-Host "dotnet-ef installed version: $efVersion"

    if ($efVersion -notlike "$requiredEfVersion*") {
        Write-Host "Updating dotnet-ef to required version $requiredEfVersion"
        dotnet tool update --global dotnet-ef --version $requiredEfVersion
    }
    else {
        Write-Host "dotnet-ef version is correct."
    }
}

Write-Host "Start migrate projects"
foreach ($provider in $dpProviders.Keys) {

    if ($migrationProviderName -eq 'All' -or $migrationProviderName -eq $provider) {
    
        $projectPath = (Get-Item -Path $dpProviders[$provider] -Verbose).FullName;
        Write-Host "Generate migration for db provider:" $provider ", for project path - " $projectPath

        $providerName = '"ProviderType": "' + $provider + '"'

        $settings = $settings -replace '"ProviderType".*', $providerName
        $settings | set-content appsettings.json
        if ((Test-Path $projectPath) -eq $true) {
            foreach ($context in $targetContexts.Keys) {
                
                if ($targetContext -eq 'All' -or $context -eq $targetContext) {

                    $migrationPath = $targetContexts[$context];

                    Write-Host "Migrating context " $context
                    dotnet-ef migrations add $migration -c $context -o $migrationPath -p $projectPath
                }
            } 
        }
        
    }
}

Remove-Item appsettings.json
Copy-Item appsettings-backup.json -Destination appsettings.json
Remove-Item appsettings-backup.json
Set-Location $currentPath