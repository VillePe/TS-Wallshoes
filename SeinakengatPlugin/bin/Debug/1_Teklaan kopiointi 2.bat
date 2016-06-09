
@ECHO OFF
cd /d "C:\Users\Ville\Documents\5_Csharp\Seinakengat\SeinakengatPlugin\bin\Debug\"

ECHO Kopioidaan "TS_Seinakengat_plugin.dll" tiedosto Teklan kansioon...
copy TS_Seinakengat_plugin.dll "C:\Program Files\Tekla Structures\21.1\nt\bin\plugins\MyPlugins\TS\TS_Seinakengat_plugin.dll"

ECHO Kopioidaan "TSUtils.dll" tiedosto Teklan kansioon...
copy TSUtils.dll "C:\Program Files\Tekla Structures\21.1\nt\bin\plugins\MyPlugins\TS\TSUtils.dll"

ECHO Kopioidaan "ComponentCatalog.dll" tiedosto Teklan kansioon...
copy ComponentCatalog.dll "C:\Program Files\Tekla Structures\21.1\nt\bin\plugins\MyPlugins\TS\ComponentCatalog.dll"
REM ECHO Kopioidaan "CreateColumn2.pdb" tiedosto Teklan kansioon...
REM copy CreateColumn2.pdb "C:\Program Files (x86)\TeklaStructuresLearning\21.1\nt\bin\plugins\MyPlugins\CreateColumn2.pdb"
pause