#!/bin/sh
# Init PowerBox related path variables
POWERBOX_BIN_PATH=~/RiderProjects/Modding/KeyMods/PowerBox/bin/Release
NML_MODS_FOLDER_PATH=~/Library/Application\ Support/Steam/steamapps/common/worldbox/Mods

# Init PowerBox distributable folder structure
cd "$NML_MODS_FOLDER_PATH" || exit
rm "./PowerBox.zip"
rm -rf "./PowerBox"
rm -rf "./KEYMASTERER__DON_NIKON_POWERBOX" # mod folder that NML auto generates if PowerBox.zip is unzipped by it
mkdir "./PowerBox"

# Copy built files into distributable folder
cd "$POWERBOX_BIN_PATH" || exit
mv "./PowerBox.dll" "$NML_MODS_FOLDER_PATH/PowerBox/PowerBox.dll"
mv "./PowerBox.pdb" "$NML_MODS_FOLDER_PATH/PowerBox/PowerBox.pdb"

# Copy build assets into distributable folder
cd "../../" || exit
cp -R "./Assemblies" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./EmbeddedResources" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./GameResources" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp -R "./Locales" "$NML_MODS_FOLDER_PATH/PowerBox/"
cp "./icon.png" "$NML_MODS_FOLDER_PATH/PowerBox/icon.png"
cp -R "./mod.json" "$NML_MODS_FOLDER_PATH/PowerBox/mod.json"

# Compress distributable folder into zip file
cd "$NML_MODS_FOLDER_PATH" || exit
zip -r "./PowerBox.zip" "./PowerBox"
