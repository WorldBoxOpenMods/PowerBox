# Define basic info about mod to distribute
$MOD_NAME = "PowerBox"
$NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME = "KEYMASTERER__DON_NIKON_POWERBOX"
$DISTRIBUTION_KIND = "source"  # "source" or "binary"

# Init mod related path variables
if ($args.Count -eq 0) {
    Write-Host "No arguments supplied, using default paths. To see available paths, run with -h or --help."
    $MOD_PROJECT_PATH = "$env:USERPROFILE\RiderProjects\Modding\KeyMods\$MOD_NAME"
    $MOD_BINARY_PATH = "$MOD_PROJECT_PATH\bin\Release"
    $NML_MODS_FOLDER_PATH = "$env:USERPROFILE\Library\Application Support\Steam\steamapps\common\worldbox\Mods"
    $DISTRIBUTABLE_ARCHIVE_PATH = "$NML_MODS_FOLDER_PATH\$MOD_NAME.zip"
} elseif ($args[0] -eq "-h" -or $args[0] -eq "--help") {
    Write-Host "Usage: .\assemble_mod_distributable.ps1 [ModProjectPath] [ModBinaryPath] [NMLModsFolderPath] [(optional) DistributableArchivePath]"
    Write-Host "If no arguments are supplied, default paths will be used."
    exit 0
} else {
    $MOD_PROJECT_PATH = $args[0]
    $MOD_BINARY_PATH = $args[1]
    $NML_MODS_FOLDER_PATH = $args[2]
    if ($args.Count -eq 4) {
        $DISTRIBUTABLE_ARCHIVE_PATH = $args[3]
    } else {
        Write-Host "Distributable archive path not supplied, using default path."
        $DISTRIBUTABLE_ARCHIVE_PATH = "$NML_MODS_FOLDER_PATH\$MOD_NAME.zip"
    }
}

# Init mod distributable folder structure
Set-Location -Path $NML_MODS_FOLDER_PATH
Remove-Item -Recurse -Force -ErrorAction SilentlyContinue "$MOD_NAME"
if (Test-Path "$NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME") {
    Remove-Item -Recurse -Force "$NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME"
}
New-Item -ItemType Directory -Path "$MOD_NAME" | Out-Null

if ($DISTRIBUTION_KIND -eq "binary") {
    Set-Location -Path $MOD_BINARY_PATH
    Copy-Item "$MOD_NAME.dll" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\$MOD_NAME.dll"
    Copy-Item "$MOD_NAME.pdb" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\$MOD_NAME.pdb"
}

# Copy build assets into distributable folder
Set-Location -Path $MOD_PROJECT_PATH

if ($DISTRIBUTION_KIND -eq "source") {
    Copy-Item "Code" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\" -Recurse
} elseif ($DISTRIBUTION_KIND -eq "binary") {
    if (Test-Path "OutdatedNml.cs") {
        Copy-Item "OutdatedNml.cs" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\"
    }
}
if (Test-Path "Assemblies") {
    Copy-Item "Assemblies" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\" -Recurse
}
if (Test-Path "EmbeddedResources") {
    Copy-Item "EmbeddedResources" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\" -Recurse
}
if (Test-Path "GameResources") {
    Copy-Item "GameResources" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\" -Recurse
}
Copy-Item "Locales" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\" -Recurse
Copy-Item "icon.png" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\icon.png"
Copy-Item "mod.json" -Destination "$NML_MODS_FOLDER_PATH\$MOD_NAME\mod.json"

# Compress distributable folder into zip file
Set-Location -Path $NML_MODS_FOLDER_PATH
if (Test-Path $DISTRIBUTABLE_ARCHIVE_PATH) {
    Remove-Item $DISTRIBUTABLE_ARCHIVE_PATH -Force
}
Compress-Archive -Path "$MOD_NAME\*" -DestinationPath "./$MOD_NAME.zip"
Move-Item -Path "./$MOD_NAME.zip" -Destination $DISTRIBUTABLE_ARCHIVE_PATH -Force
