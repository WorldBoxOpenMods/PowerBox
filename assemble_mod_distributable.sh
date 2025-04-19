#!/bin/sh
# Init PowerBox related path variables
if test $# -eq 0; then
  echo "No arguments supplied, using default paths. To see available paths, run with -h or --help."
  POWERBOX_PROJECT_PATH=~/RiderProjects/Modding/KeyMods/PowerBox
  NML_MODS_FOLDER_PATH=~/Library/Application\ Support/Steam/steamapps/common/worldbox/Mods
  DISTRIBUTABLE_ARCHIVE_PATH="$NML_MODS_FOLDER_PATH/PowerBox.zip"
else
  if test "$1" = "-h" || test "$1" = "--help"; then
    echo "Usage: ./assemble_mod_distributable.sh [PowerBoxProjectPath] [NMLModsFolderPath] [(optional) DistributableArchivePath]"
    echo "If no arguments are supplied, default paths will be used."
    exit 0
  else
    POWERBOX_PROJECT_PATH=$1
    NML_MODS_FOLDER_PATH=$2
    if test $# -eq 3; then
      DISTRIBUTABLE_ARCHIVE_PATH=$3
    else
      echo "Distributable archive path not supplied, using default path."
      DISTRIBUTABLE_ARCHIVE_PATH="$NML_MODS_FOLDER_PATH/PowerBox.zip"
    fi
  fi
fi

# Init PowerBox distributable folder structure
cd "$NML_MODS_FOLDER_PATH" || exit 1
rm "./PowerBox.zip"
rm -rf "./PowerBox"
rm -rf "./KEYMASTERER__DON_NIKON_POWERBOX" # mod folder that NML auto generates if PowerBox.zip is unzipped by it
mkdir "./PowerBox"

# Copy build assets into distributable folder
cd "$POWERBOX_PROJECT_PATH" || exit 1
cp -R "./Code" "$NML_MODS_FOLDER_PATH/PowerBox/"
if test -d "./Assemblies"; then
  cp -R "./Assemblies" "$NML_MODS_FOLDER_PATH/PowerBox/"
fi
if test -d "./EmbeddedResources"; then
  cp -R "./EmbeddedResources" "$NML_MODS_FOLDER_PATH/PowerBox/"
fi
if test -d "./GameResources"; then
  cp -R "./GameResources" "$NML_MODS_FOLDER_PATH/PowerBox/"
fi
cp -R "./Locales" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./icon.png" "$NML_MODS_FOLDER_PATH/PowerBox/icon.png"
cp -R "./mod.json" "$NML_MODS_FOLDER_PATH/PowerBox/mod.json"

# Compress distributable folder into zip file
cd "$NML_MODS_FOLDER_PATH" || exit 1
zip -r "./PowerBox.zip" "./PowerBox"
mv "./PowerBox.zip" "$DISTRIBUTABLE_ARCHIVE_PATH"
