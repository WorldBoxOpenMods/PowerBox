# PowerShell equivalent of assemble_mod_distributable.sh

# Define basic mod info
$MOD_NAME = "PowerBox"
$NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME = "KEYMASTERER__DON_NIKON_POWERBOX"

# Handle arguments and set paths
param(
[string]$ModProjectPath,
[string]$NmlModsFolderPath,
[string]$DistributableArchivePath
)

function Show-Help {
    Write-Host "Usage: .\assemble_mod_distributable.ps1 [-ModProjectPath <path>] [-NmlModsFolderPath <path>] [-DistributableArchivePath <path>]"
    Write-Host "If no arguments are supplied, default paths will be used."
    exit 0
}

if ($args -contains "-h" -or $args -contains "--help") {
    Show-Help
}

if (-not $ModProjectPath) {
    Write-Host "No arguments supplied, using default paths. To see available paths, run with -h or --help."
    $ModProjectPath = "$HOME\RiderProjects\Modding\KeyMods\$MOD_NAME"
    $NmlModsFolderPath = "$HOME\AppData\Roaming\Steam\steamapps\common\worldbox\Mods"
    $DistributableArchivePath = Join-Path $NmlModsFolderPath "$MOD_NAME.zip"
} elseif (-not $DistributableArchivePath) {
    Write-Host "Distributable archive path not supplied, using default path."
    $DistributableArchivePath = Join-Path $NmlModsFolderPath "$MOD_NAME.zip"
}

# Prepare mod distributable folder
Set-Location $NmlModsFolderPath

$modFolderPath = Join-Path $NmlModsFolderPath $MOD_NAME
$autoUnzipPath = Join-Path $NmlModsFolderPath $NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME

Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $modFolderPath
Remove-Item -Recurse -Force -ErrorAction SilentlyContinue $autoUnzipPath

New-Item -ItemType Directory -Path $modFolderPath | Out-Null

# Copy build assets
Set-Location $ModProjectPath

Copy-Item -Recurse -Force "./Code" $modFolderPath

if (Test-Path "./Assemblies") {
    Copy-Item -Recurse -Force "./Assemblies" $modFolderPath
}
if (Test-Path "./EmbeddedResources") {
    Copy-Item -Recurse -Force "./EmbeddedResources" $modFolderPath
}
if (Test-Path "./GameResources") {
    Copy-Item -Recurse -Force "./GameResources" $modFolderPath
}

Copy-Item -Force "./Locales" $modFolderPath -Recurse
Copy-Item -Force "./icon.png" "$modFolderPath\icon.png"
Copy-Item -Force "./mod.json" "$modFolderPath\mod.json"

# Create distributable zip
Set-Location $NmlModsFolderPath

if (Test-Path $DistributableArchivePath) {
    Remove-Item -Force $DistributableArchivePath
}

Add-Type -AssemblyName 'System.IO.Compression.FileSystem'
[System.IO.Compression.ZipFile]::CreateFromDirectory($modFolderPath, "$NmlModsFolderPath\$MOD_NAME.zip")

Move-Item -Force "$NmlModsFolderPath\$MOD_NAME.zip" $DistributableArchivePath
