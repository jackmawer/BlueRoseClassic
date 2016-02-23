Name "Blue Rose"

Outfile "BlueRoseOnline.exe"

RequestExecutionLevel admin

Page directory
Page instfiles

InstallDir "$PROFILE\FreeSO"

Section "Main"

	SetOutPath '$INSTDIR'

	File "BlueRoseUpdate\bin\Release\SimplyUpdate.exe"
	File "BlueRoseUpdate\bin\Release\SimplyUpdate.exe.config"
	File "BlueRoseUpdate\bin\Release\SimplyUpdate.pdb"
	File "BlueRoseUpdate\bin\Release\ZACKUpdater.dll"
	File "BlueRoseUpdate\bin\Release\ZACKUpdater.pdb"
	
	 # create the uninstaller
    WriteUninstaller "$INSTDIR\Uninstall BlueRoseLauncher.exe"
	
	# create start menu shortcut
	CreateDirectory "$SMPROGRAMS\FreeSO\"
    CreateShortCut "$SMPROGRAMS\FreeSO\FreeSO.lnk" "$INSTDIR\SimplyUpdate.exe"
	CreateShortCut "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk" "$INSTDIR\Uninstall BlueRoseLauncher.exe"

	# create desktop shortcut
  	CreateShortCut "$DESKTOP\Viewer Launcher.lnk" "$INSTDIR\SimplyUpdate.exe"
	
SectionEnd


Section "Uninstall"
 
    # first, delete installed files
	Delete "$INSTDIR\SimplyUpdate.exe"
	Delete "$INSTDIR\SimplyUpdate.exe.config"
	Delete "$INSTDIR\SimplyUpdate.pdb"
	Delete "$INSTDIR\ZACKUpdater.dll"
	Delete "$INSTDIR\ZACKUpdater.pdb"
	Delete "$INSTDIR\BlueRoseLauncher.exe"
	Delete "$INSTDIR\BlueRoseLauncher.exe.config"
	Delete "$INSTDIR\BlueRoseLauncher.pdb"
 
    # second, the shortcuts
    Delete "$DESKTOP\Viewer Launcher.lnk"
	Delete "$SMPROGRAMS\FreeSO\FreeSO.lnk"
	Delete "$SMPROGRAMS\FreeSO\Uninstall Blue Rose.lnk"
	Delete "$SMPROGRAMS\FreeSO\"
 
SectionEnd