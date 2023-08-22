$scriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
Clear-Host

Get-ChildItem -Path $scriptDir -Directory | ForEach-Object {
    $subDirName = $_.Name
    if (-not ($subDirName -like ".scripts")) {
        Set-Location $_
        dotnet clean
        Set-Location ..
    }

    $binDirs = Get-ChildItem -Path $_.FullName -Directory -Filter "bin" -Recurse
    $binDirs | ForEach-Object {
        $binDir = $_.FullName
        $binDirName = $_.Name
        if ($binDirName -like "bin") {
            Remove-Item -Path $binDir -Recurse -Force
        }
    }

    $objDirs = Get-ChildItem -Path $_.FullName -Directory -Filter "obj" -Recurse
    $objDirs | ForEach-Object {
        $objDir = $_.FullName
        $objDirName = $_.Name
        if ($objDirName -like "obj") {
            Remove-Item -Path $objDir -Recurse -Force
        }
    }
}