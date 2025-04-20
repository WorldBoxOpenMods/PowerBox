#!/bin/sh
# Define basic info about mod to distribute
MOD_NAME="PowerBox" # mod name, must be what the mod DLL is named if you're using binary distribution, otherwise can be whatever you want the mod folder/zip to be called
NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME="KEYMASTERER__DON_NIKON_POWERBOX" # if the mod.zip is placed in the NML Mods folder, NML will automatically unzip it upon opening the name with an auto generated folder name, specify said name here
DISTRIBUTION_KIND="source" # "source" or "binary", depending on whether mod should be distributed as source code of as DLL/PDB files

# Init mod related path variables
if test $# -eq 0; then
  echo "No arguments supplied, using default paths. To see available paths, run with -h or --help."
  MOD_PROJECT_PATH="$HOME/RiderProjects/Modding/KeyMods/$MOD_NAME"
  MOD_BINARY_PATH="$MOD_PROJECT_PATH/bin/Release"
  NML_MODS_FOLDER_PATH="$HOME/Library/Application Support/Steam/steamapps/common/worldbox/Mods"
  DISTRIBUTABLE_ARCHIVE_PATH="$NML_MODS_FOLDER_PATH/$MOD_NAME.zip"
else
  if test "$1" = "-h" || test "$1" = "--help"; then
    echo "Usage: ./assemble_mod_distributable.sh [ModProjectPath] [ModBinaryPath] [NMLModsFolderPath] [(optional) DistributableArchivePath]"
    echo "If no arguments are supplied, default paths will be used."
    exit 0
  else
    MOD_PROJECT_PATH=$1
    MOD_BINARY_PATH=$2
    NML_MODS_FOLDER_PATH=$3
    if test $# -eq 4; then
      DISTRIBUTABLE_ARCHIVE_PATH=$4
    else
      echo "Distributable archive path not supplied, using default path."
      DISTRIBUTABLE_ARCHIVE_PATH="$NML_MODS_FOLDER_PATH/$MOD_NAME.zip"
    fi
  fi
fi

# Init mod distributable folder structure
cd "$NML_MODS_FOLDER_PATH" || exit 1
rm -rf "./$MOD_NAME"
if test -d "./$NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME"; then
  rm -rf "./$NML_AUTO_UNZIP_OUTPUT_FOLDER_NAME" # mod folder that NML auto generates if ModName.zip is unzipped by it
fi
mkdir "./$MOD_NAME"

if test "$DISTRIBUTION_KIND" = "binary"; then
  # Copy built files into distributable folder
  cd "$MOD_BINARY_PATH" || exit 1
  cp -R "./$MOD_NAME.dll" "$NML_MODS_FOLDER_PATH/$MOD_NAME/$MOD_NAME.dll"
  cp -R "./$MOD_NAME.pdb" "$NML_MODS_FOLDER_PATH/$MOD_NAME/$MOD_NAME.pdb"
fi

# Copy build assets into distributable folder
cd "$MOD_PROJECT_PATH" || exit 1
if test "$DISTRIBUTION_KIND" = "source"; then
  cp -R "./Code" "$NML_MODS_FOLDER_PATH/$MOD_NAME/"
elif test "$DISTRIBUTION_KIND" = "binary"; then
  if test -e "./OutdatedNml.cs"; then
    cp -R "./OutdatedNml.cs" "$NML_MODS_FOLDER_PATH/$MOD_NAME/OutdatedNml.cs"
  fi
fi
if test -d "./Assemblies"; then
  cp -R "./Assemblies" "$NML_MODS_FOLDER_PATH/$MOD_NAME/"
fi
if test -d "./EmbeddedResources"; then
  cp -R "./EmbeddedResources" "$NML_MODS_FOLDER_PATH/$MOD_NAME/"
fi
if test -d "./GameResources"; then
  cp -R "./GameResources" "$NML_MODS_FOLDER_PATH/$MOD_NAME/"
fi
cp -R "./Locales" "$NML_MODS_FOLDER_PATH/$MOD_NAME/"
cp -R "./icon.png" "$NML_MODS_FOLDER_PATH/$MOD_NAME/icon.png"
cp -R "./mod.json" "$NML_MODS_FOLDER_PATH/$MOD_NAME/mod.json"

# Compress distributable folder into zip file
cd "$NML_MODS_FOLDER_PATH" || exit 1
if test -e "$DISTRIBUTABLE_ARCHIVE_PATH"; then
  rm "$DISTRIBUTABLE_ARCHIVE_PATH"
fi
zip -r "./$MOD_NAME.zip" "./$MOD_NAME"
mv "./$MOD_NAME.zip" "$DISTRIBUTABLE_ARCHIVE_PATH"
