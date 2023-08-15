# Get the current script file's directory
$currentDir = Split-Path $MyInvocation.MyCommand.Path

# Install the template in the current directory
dotnet new install $currentDir