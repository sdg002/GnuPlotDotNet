#
#This is a helper scipt which will lauch the Windows Forms that have been created in this project
#
cls
$ErrorActionPreference="Stop"
#
#Load required assemblies
#
"displaying path below"
"path={0}" -f $PSScriptRoot
[System.Reflection.Assembly]::LoadFrom("$PSScriptRoot\GnuPlotDotNetLibFwk.dll")
$wrapper=New-Object -TypeName "GnuPlotDotNetLib.Wrapper"
$wrapper.Clear();
$wrapper.XAxisTitle="this is xaxis";
$wrapper.Redraw();

write-host "Loaded assembly all done"
pause
