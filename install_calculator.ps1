
# Check and install Git
Write-Host "Checking if Git is installed..."
$gitPath = "C:\Program Files\Git\cmd\git.exe"
if (-not (Test-Path -Path $gitPath)) {
    Write-Host "Git is not installed. Installing..."
    Invoke-WebRequest -Uri "https://github.com/git-for-windows/git/releases/download/v2.47.1.windows.1/Git-2.47.1-64-bit.exe" -OutFile "$env:TEMP\GitInstaller.exe"
    Start-Process -FilePath "$env:TEMP\GitInstaller.exe" -ArgumentList "/VERYSILENT" -Wait
    Remove-Item -Path "$env:TEMP\GitInstaller.exe"

    # Add Git to PATH
    $env:Path += ";C:\Program Files\Git\cmd"
    Write-Host "Git has been installed and added to PATH."
} else {
    Write-Host "Git is already installed."
}

# Check and install MSBuild
Write-Host "Checking if MSBuild is installed..."
$msbuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\msbuild.exe"
if (-not (Test-Path -Path $msbuildPath)) {
    Write-Host "MSBuild is not installed. Installing..."
    $installerUrl = "https://aka.ms/vs/17/release/vs_BuildTools.exe"
    $installerPath = "$env:TEMP\VSBuildToolsInstaller.exe"

    # Download and install
    Invoke-WebRequest -Uri $installerUrl -OutFile $installerPath
    Start-Process -FilePath $installerPath -ArgumentList "--quiet --norestart --add Microsoft.VisualStudio.Workload.MSBuildTools" -Wait

    Remove-Item -Path $installerPath
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

# Check for the local repository
Write-Host "Checking if the local repository exists..."
$localRepoPath = "C:\Projects\Calculator"
if (-not (Test-Path -Path $localRepoPath)) {
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

# Check for .NET Framework reference assemblies
Write-Host "Checking if reference assemblies for .NET Framework 4.8 are available..."
$referenceAssembliesPath = "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8"

if (-not (Test-Path -Path $referenceAssembliesPath)) {
    # Path to the folder where the installer will be downloaded
    $downloadFolder = "$localRepoPath"

    # Link to the file in Yandex.Cloud
    $installerUrl = "https://storage.yandexcloud.net/calc.install/NDP48-DevPack-ENU.exe"

    # Path where the installer will be saved
    $installerPath = "$downloadFolder\NDP48-DevPack-ENU.exe"

    # Download the installer
    Write-Host "Downloading .NET Framework Developer Pack installer from Yandex Cloud..."
    Invoke-WebRequest -Uri $installerUrl -OutFile $installerPath

    # Verify successful download
    if (Test-Path -Path $installerPath) {
        Write-Host "Installer downloaded successfully to $installerPath"
    } else {
        Write-Error "Failed to download the installer."
        exit 1
    }

    # Launch the .NET Framework Developer Pack installer in silent mode
    Write-Host "Launching the .NET Framework Developer Pack installer in silent mode..."
    Start-Process -FilePath $installerPath -ArgumentList "/quiet", "/norestart" -Wait

    Write-Host ".NET Framework Developer Pack installation completed. Resuming script execution..."
} else {
    Write-Host "Reference assemblies for .NET Framework 4.8 are available."
}

# Build the project
Write-Host "Building the project..."
& $msbuildPath "$localRepoPath\Calculator.sln" /p:Configuration=Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Project build failed."
    exit 1
}

# Create an installer with Inno Setup
Write-Host "Creating the installer..."
$outputDir = "$localRepoPath"
$sourceFilesDir = "$outputDir\bin\Release"

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
Source: "$sourceFilesDir\*"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\Calculator"; Filename: "{app}\Calculator.exe"
"@

$innoConfigPath = "$outputDir\CalculatorInstaller.iss"
$installerScript | Set-Content -Path $innoConfigPath

# Check if ISCC.exe exists
if (-not (Test-Path -Path $isccPath)) {
    Write-Error "Inno Setup is not installed or not found at '$isccPath'."
    exit 1
}

# Compile the installer
Write-Host "Compiling the installer..."
& $isccPath $innoConfigPath
if ($LASTEXITCODE -ne 0) {
    Write-Error "Error occurred while creating the installer."
    exit 1
}

Write-Host "Installer has been created successfully. Check the output directory: $outputDir"

Write-Host "Script completed successfully."
