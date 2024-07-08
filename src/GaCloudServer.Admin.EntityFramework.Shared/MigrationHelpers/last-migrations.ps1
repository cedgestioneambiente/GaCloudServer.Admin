$projectName = "GaCloudServer"
$currentPath = Get-Location
Set-Location "../../$projectName.Admin.EntityFramework.SqlServer"

# Directory delle migrazioni
$migrationsDir = "Migrations\Resources"

# Variabile opzionale per filtro
$filterString = $args[0]

# Ottieni tutti i file di migrazione, escludendo il ModelSnapshot
$migrationFiles = Get-ChildItem $migrationsDir -Filter "*.cs" | 
                  Where-Object { $_.Name -notmatch "ModelSnapshot" }

# Applica il filtro se $filterString è valorizzato
if ($filterString) {
    $migrationFiles = $migrationFiles | Where-Object { $_.Name -like "*$filterString*" }
}

# Ordina i file per data di creazione (dal più recente al più vecchio)
$migrationFiles = $migrationFiles | Sort-Object LastWriteTime -Descending

# Verifica se ci sono abbastanza file per ottenere il penultimo
if ($migrationFiles.Count -ge 1) {
    # Il penultimo file se esiste
    $latestMigration = $migrationFiles[0]
    Write-Output "Ultima migrazione: $($latestMigration.Name)"
} else {
    Write-Output "Nessuna migrazione trovata."
}

Set-Location $currentPath