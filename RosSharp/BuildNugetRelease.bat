@echo off
nuget pack -Prop Configuration=Release
rem copy *.nupkg \\exiii-server\public\NugetPackageSource\External
move *.nupkg .\..\Nuget
pause