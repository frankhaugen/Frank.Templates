param (
    [Parameter(Mandatory=$true)]
    [ValidateSet('Debug', 'Release')]
    [string]$configuration,
    [Parameter(Mandatory=$true)]
    [string]$version
)

$publishDir = "./.artifacts/publish"
$packageDir = "./.artifacts/packages"

# Build the solution in the specified mode
Write-Host "Building solution in $configuration mode with version $version..." -ForegroundColor DarkCyan
dotnet build --configuration $configuration /p:Version=$version -v m
Write-Host "Build in $configuration mode completed." -ForegroundColor Green

# Publish the solution and pack nugets
Write-Host "Publishing the solution..." -ForegroundColor DarkCyan
dotnet publish --configuration $configuration --output $publishDir /p:Version=$version /p:PackageVersion=$version -v m
Write-Host "Solution has been published." -ForegroundColor Green

# Pack NuGet packages
Write-Host "Packing NuGet packages..." -ForegroundColor DarkCyan
dotnet pack --configuration $configuration --output $packageDir /p:Version=$version /p:PackageVersion=$version -v m
Write-Host "NuGet packages have been packed." -ForegroundColor Green

# Clean up
Write-Host "Cleaning up..." -ForegroundColor DarkCyan
dotnet clean --configuration $configuration -v m
Write-Host "Clean up completed." -ForegroundColor Green

# Exit with a success code
exit 0