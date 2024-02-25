dotnet publish -c Release -r win-x64 --no-self-contained -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:IncludeAllContentForSelfExtract=true
move bin\Release\net6.0-windows10.0.22000.0\win-x64\publish\¦a¹Ï½s¿è¾¹.exe ../..
pause