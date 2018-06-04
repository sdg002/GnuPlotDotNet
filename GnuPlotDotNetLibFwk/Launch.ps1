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
try
{
	[System.Reflection.Assembly]::LoadFrom("$PSScriptRoot\GnuPlotDotNetLibFwk.dll")
	$wrapper=New-Object -TypeName "GnuplotDotNetLib.Wrapper"
	$wrapper.XAxisLabel="this is xaxis label";
	$wrapper.YAxisLabel="this is yaxis label";
	$wrapper.IsGridVisible=$true;
	$wrapper.ChartTitle="this is chart title 001";
	$wrapper.Redraw();
	pause
	$wrapper.ChartTitle="this is chart title 002";
	$wrapper.IsGridVisible=$false;
	$wrapper.XAxisLabel="this is a new label";
	$wrapper.Redraw();

	write-host "Loaded assembly all done"
	pause
	Write-Host "Going to clear"
	$wrapper.Clear();
	pause

}
catch
{
	Write-Host $_.Exception
	pause
}