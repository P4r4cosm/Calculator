# Set console encoding to support Cyrillic
[Console]::OutputEncoding = [System.Text.Encoding]::GetEncoding("cp866")

# Check and install Git
Write-Host "Checking if Git is installed..."
if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Host "Git is not installed. Installing..."
    Invoke-WebRequest -Uri "https://github.com/git-for-windows/git/releases/latest/download/Git-2.42.0-64-bit.exe" -OutFile "$env:TEMP\GitInstaller.exe"
    Start-Process -FilePath "$env:TEMP\GitInstaller.exe" -ArgumentList "/VERYSILENT" -Wait
    Remove-Item -Path "$env:TEMP\GitInstaller.exe"
    Write-Host "Git has been installed."
}

# Check and install MSBuild
$msbuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\msbuild.exe"
Write-Host "Checking if MSBuild is installed..."
if (-not (Test-Path -Path $msbuildPath)) {
    Write-Host "MSBuild is not installed. Installing..."
    Invoke-WebRequest -Uri "https://aka.ms/vs/17/release/vs_BuildTools.exe" -OutFile "$env:TEMP\VSBuildToolsInstaller.exe"
    Start-Process -FilePath "$env:TEMP\VSBuildToolsInstaller.exe" -ArgumentList "--quiet --norestart --wait --add Microsoft.VisualStudio.Workload.MSBuildTools" -Wait
    Remove-Item -Path "$env:TEMP\VSBuildToolsInstaller.exe"
    Write-Host "MSBuild has been installed."
}

# Check and install NuGet
Write-Host "Checking if NuGet is installed..."
$nugetPath = "$env:TEMP\nuget.exe"
if (-not (Test-Path -Path $nugetPath)) {
    Write-Host "NuGet is not installed. Downloading..."
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
    Write-Host "NuGet has been installed."
}

# Check and install Inno Setup
Write-Host "Checking if Inno Setup is installed..."
$isccPath = "C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
if (-not (Test-Path -Path $isccPath)) {
    Write-Host "Inno Setup is not installed. Installing..."
    Invoke-WebRequest -Uri "https://jrsoftware.org/download.php/is.exe" -OutFile "$env:TEMP\InnoSetupInstaller.exe"
    Start-Process -FilePath "$env:TEMP\InnoSetupInstaller.exe" -ArgumentList "/VERYSILENT" -Wait
    Remove-Item -Path "$env:TEMP\InnoSetupInstaller.exe"
    Write-Host "Inno Setup has been installed."
}

# Check if the local repository exists
Write-Host "Checking if the local repository exists..."
$localRepoPath = "C:\Projects\Calculator"
if (!(Test-Path -Path $localRepoPath)) {
    Write-Host "Local repository not found. Cloning..."
    git clone "https://github.com/P4r4cosm/Calculator.git" $localRepoPath
} else {
    Set-Location -Path $localRepoPath
    git pull
}

# Restore NuGet packages
Write-Host "Restoring NuGet packages..."
& $nugetPath restore "$localRepoPath\Calculator.sln"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to restore NuGet packages. Check your configuration."
    exit 1
}

# Build the project
Write-Host "Building the project..."
& $msbuildPath "$localRepoPath\Calculator.sln" /p:Configuration=Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Project build failed."
    exit 1
}

# Create the installer using Inno Setup
Write-Host "Creating the installer..."
$outputDir = "$localRepoPath\bin\Release"
$installerScript = @"
[Setup]
AppName=Calculator
AppVersion=1.0
DefaultDirName={pf}\Calculator
DefaultGroupName=Calculator
OutputDir=$outputDir
OutputBaseFilename=CalculatorInstaller
Compression=lzma
SolidCompression=yes

[Files]
Source: "$outputDir\*"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Calculator"; Filename: "{app}\Calculator.exe"
"@
$innoConfigPath = "$outputDir\CalculatorInstaller.iss"
$installerScript | Set-Content -Path $innoConfigPath

& $isccPath $innoConfigPath
if ($LASTEXITCODE -ne 0) {
    Write-Error "Error occurred while creating the installer."
    exit 1
}

Write-Host "Script completed successfully."
