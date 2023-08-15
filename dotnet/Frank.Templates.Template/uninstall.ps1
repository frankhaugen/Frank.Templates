# Get the current script file's directory
$currentDir = Split-Path $MyInvocation.MyCommand.Path

# Uninstall the template in the current directory
dotnet new uninstall $currentDir