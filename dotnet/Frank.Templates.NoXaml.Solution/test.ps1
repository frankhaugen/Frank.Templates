# Define parameters
param (
    [Parameter(Mandatory=$true)][string]$Version
)

# Get template name from directory name
$templateName = Split-Path -Leaf $PSScriptRoot

# Output to console
Write-Host "Testing $templateName version $Version"

# Test solution
dotnet test $templateName.sln --configuration Release --no-build --verbosity normal

# return exit code from dotnet test
exit $LASTEXITCODE