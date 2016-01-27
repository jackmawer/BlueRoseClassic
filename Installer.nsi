Name "Blue Rose 2.0 Stable"

Outfile "BlueRoseStable.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$PROFILE\FreeSO"

Section "Main"

	SetOutPath '$INSTDIR'

	File "BlueRose\bin\Release\BlueRoseLauncher.exe"
	File "BlueRose\bin\Release\BlueRoseLauncher.exe.config"
	File "BlueRose\bin\Release\BlueRoseLauncher.pdb"
	File "BlueRose\bin\Release\BlueRose.TeamCity.dll"
	File "BlueRose\bin\Release\BlueRose.TeamCity.pdb"
	File "BlueRose\bin\Release\Ionic.Zip.dll"
	File "BlueRose\bin\Release\Ionic.Zip.xml"
	
	 # create the uninstaller
    WriteUninstaller "$INSTDIR\Uninstall Blue Rose.exe"
	
	# create start menu shortcut
	CreateDirectory "$SMPROGRAMS\FreeSO\"
    CreateShortCut "$SMPROGRAMS\FreeSO\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	CreateShortCut "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk" "$INSTDIR\Uninstall Blue Rose.exe"

	# create desktop shortcut
  	CreateShortCut "$DESKTOP\FreeSO.lnk" "$INSTDIR\BlueRoseLauncher.exe"
	
SectionEnd


Section "Uninstall"
 
    # first, delete installed files
	Delete "$INSTDIR\BlueRoseLauncher.exe"
	Delete "$INSTDIR\BlueRoseLauncher.exe.config"
	Delete "$INSTDIR\BlueRoseLauncher.pdb"
	Delete "$INSTDIR\BlueRose.TeamCity.dll"
	Delete "$INSTDIR\BlueRose.TeamCity.pdb"
	Delete "$INSTDIR\Ionic.Zip.dll"
	Delete "$INSTDIR\Ionic.Zip.xml"
	Delete "$INSTDIR\Uninstall BlueRoseLauncher.exe"
 
    # second, the shortcuts
    Delete "$DESKTOP\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk"
	Delete "$SMPROGRAMS\FreeSO\"
 
SectionEnd