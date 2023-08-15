$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$sourceSubDir = "$scriptDir\.scripts"

$sourceScripts = Get-ChildItem -Path $sourceSubDir -File #"*.ps1"

$sourceScripts | Format-Table

Get-ChildItem -Path "$scriptDir" -Directory | ForEach-Object {
    $targetScriptsDir = $_.FullName

    $targetScriptsDir | Out-Host
    
    if ($sourceSubDir -eq $targetScriptsDir) {
        Write-Host "  Skipping $($_.Name)"
    }
    else {        
        $sourceScripts | ForEach-Object {
            $sourceScript = $_.FullName
            $targetScript = "$($targetScriptsDir)\$($_.Name)"
            if (Test-Path -Path $targetScript) {
                Write-Host "  $($_.Name) already exists, forcing copy"
                Copy-Item -Path $sourceScript -Destination $targetScript -Force
            } else {
                Write-Host "  Copying $($_.Name)"
                Copy-Item -Path $sourceScript -Destination $targetScript
            }
            $targetScriptsDir | Out-Host
        }
    }
}
