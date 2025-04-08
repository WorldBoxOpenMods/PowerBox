#!/bin/sh
# Init PowerBox related path variables
POWERBOX_PROJECT_PATH=~/RiderProjects/Modding/KeyMods/PowerBox
NML_MODS_FOLDER_PATH=~/Library/Application\ Support/Steam/steamapps/common/worldbox/Mods

# Init PowerBox distributable folder structure
cd "$NML_MODS_FOLDER_PATH" || exit
rm "./PowerBox.zip"
rm -rf "./PowerBox"
rm -rf "./KEYMASTERER__DON_NIKON_POWERBOX" # mod folder that NML auto generates if PowerBox.zip is unzipped by it
mkdir "./PowerBox"

# Copy build assets into distributable folder
cd "$POWERBOX_PROJECT_PATH" || exit
cp -R "./Code" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./Assemblies" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./EmbeddedResources" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./GameResources" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./Locales" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./icon.png" "$NML_MODS_FOLDER_PATH/PowerBox/icon.png"
cp -R "./mod.json" "$NML_MODS_FOLDER_PATH/PowerBox/mod.json"

# Compress distributable folder into zip file
cd "$NML_MODS_FOLDER_PATH" || exit
zip -r "./PowerBox.zip" "./PowerBox"
