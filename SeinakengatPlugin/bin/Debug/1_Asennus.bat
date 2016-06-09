@ECHO OFF
candle.exe Installer.wxs
light.exe -ext WixUIExtension -cultures:fi-fi Installer.wixobj
pause