# Define parameters
param (
    [string]$Version
)

# Get template name from directory name
$templateName = Split-Path -Leaf $PSScriptRoot

# Output to console
Write-Host "Building Template name: $templateName Version: $Version"

# Restore packages
dotnet restore $templateName.sln

# Check if restore was successful
if ($LASTEXITCODE -ne 0) {
    Write-Error "dotnet restore failed with exit code $LASTEXITCODE"
    exit $LASTEXITCODE
}

# Build solution
dotnet build $templateName.sln --configuration Release --no-restore /p:Version=$Version

# return exit code from dotnet build
exit $LASTEXITCODE