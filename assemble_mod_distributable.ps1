# PowerBox.ps1

param (
    [string]$PowerBoxProjectPath = "$env:USERPROFILE\RiderProjects\Modding\KeyMods\PowerBox",
    [string]$NmlModsFolderPath = "$env:USERPROFILE\Library\Application Support\Steam\steamapps\common\worldbox\Mods",
    [string]$DistributableArchivePath
)

# Show help
if ($args -contains "-h" -or $args -contains "--help") {
    Write-Host "Usage: .\PowerBox.ps1 [PowerBoxProjectPath] [NmlModsFolderPath] [(optional) DistributableArchivePath]"
    Write-Host "If no arguments are supplied, default paths will be used."
    exit 0
}

# Set Distributable path if not provided
if (-not $DistributableArchivePath) {
    Write-Host "Distributable archive path not supplied, using default path."
    $DistributableArchivePath = Join-Path $NmlModsFolderPath "PowerBox.zip"
}

# Ensure target directory exists
if (-Not (Test-Path -Path $NmlModsFolderPath)) {
    Write-Error "NML Mods folder path does not exist: $NmlModsFolderPath"
    exit 1
}

# Change to NML Mods folder
Set-Location $NmlModsFolderPath

# Clean up old distributables
Remove-Item -Path ".\PowerBox.zip" -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\PowerBox" -Recurse -Force -ErrorAction SilentlyContinue
Remove-Item -Path ".\KEYMASTERER__DON_NIKON_POWERBOX" -Recurse -Force -ErrorAction SilentlyContinue

# Create new distributable folder
New-Item -Path ".\PowerBox" -ItemType Directory | Out-Null

# Copy build assets
$filesToCopy = @("Code", "Assemblies", "EmbeddedResources", "GameResources", "Locales", "icon.png", "mod.json")
foreach ($item in $filesToCopy) {
    $sourcePath = Join-Path $PowerBoxProjectPath $item
    $destinationPath = Join-Path "$NmlModsFolderPath\PowerBox" (Split-Path $item -Leaf)

    if (Test-Path $sourcePath) {
        Copy-Item -Path $sourcePath -Destination $destinationPath -Recurse -Force
    } else {
        Write-Warning "Missing: $sourcePath"
    }
}

# Zip the folder
$zipPath = Join-Path $NmlModsFolderPath "PowerBox.zip"
Compress-Archive -Path ".\PowerBox\*" -DestinationPath $zipPath -Force

# Move the archive to final destination if needed
if ($zipPath -ne $DistributableArchivePath) {
    Move-Item -Path $zipPath -Destination $DistributableArchivePath -Force
}
