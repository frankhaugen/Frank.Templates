# Define parameters
param (
    [Parameter(Mandatory=$true)][string]$Version,
    [Parameter(Mandatory=$true)][string]$NuGetApiKey,
    [Parameter(Mandatory=$true)][string]$NuGetFeedUrl = "https://api.nuget.org/v3/index.json"
)

# Get template name from directory name
$templateName = Split-Path -Leaf $PSScriptRoot

# Censor API key
$censoredApiKey = $NuGetApiKey.Substring(0, 5) + "..."

# Output to console
Write-Host "Pushing template name: $templateName Version: $Version NuGetApiKey: $censoredApiKey NuGetFeedUrl: $NuGetFeedUrl"

# Pack template
dotnet pack $templateName/$templateName.csproj --configuration Release --output ./artifacts --version-suffix $Version

# Publish template to NuGet
dotnet nuget push ./artifacts/$templateName.$Version.nupkg --api-key $NuGetApiKey --source $NuGetFeedUrl

# Check if publish was successful
if ($LASTEXITCODE -ne 0) {
    Write-Host "Failed to push template name: $templateName Version: $Version NuGetApiKey: $censoredApiKey NuGetFeedUrl: $NuGetFeedUrl"
    exit $LASTEXITCODE
}

# Delete artifacts
Remove-Item -Path ./artifacts -Recurse -Force

# Output to console
Write-Host "Finished pushing template name: $templateName Version: $Version NuGetApiKey: $censoredApiKey NuGetFeedUrl: $NuGetFeedUrl"

# Exit
exit 0
