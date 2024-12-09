# Проверка установленного Git
Write-Host "Checking if Git is installed..."
$gitPath = "C:\Program Files\Git\cmd\git.exe"
if (Get-Command git -ErrorAction SilentlyContinue) {
    Write-Host "Git is already installed. Skipping installation."
} else {
    Write-Host "Git is not installed. Installing..."
    $installerUrl = "https://github.com/git-for-windows/git/releases/download/v2.47.1.windows.1/Git-2.47.1-64-bit.exe"
    $installerPath = "$env:TEMP\GitInstaller.exe"

    # Скачиваем установщик
    Write-Host "Downloading Git installer..."
    Invoke-WebRequest -Uri $installerUrl -OutFile $installerPath

    # Установка
    Write-Host "Installing Git..."
    Start-Process -FilePath $installerPath -ArgumentList "/VERYSILENT" -Wait

    Remove-Item -Path $installerPath
    Write-Host "Git has been installed."
}

# Проверка наличия ссылочных сборок для .NET Framework
Write-Host "Checking if reference assemblies for .NET Framework 4.8 are available..."
$referenceAssembliesPath = "C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.8"

if (-not (Test-Path -Path $referenceAssembliesPath)) {
    Write-Error "Reference assemblies for .NET Framework 4.8 are missing. Ensure that .NET Framework Developer Pack 4.8 is installed correctly. Visit https://aka.ms/msbuild/developerpacks for more information."
    exit 1
} else {
    Write-Host "Reference assemblies for .NET Framework 4.8 are available."
}

# Проверка и установка MSBuild
Write-Host "Checking if MSBuild is installed..."
$msbuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\msbuild.exe"
if (-not (Test-Path -Path $msbuildPath)) {
    Write-Host "MSBuild is not installed. Installing..."
    $installerUrl = "https://aka.ms/vs/17/release/vs_BuildTools.exe"
    $installerPath = "$env:TEMP\VSBuildToolsInstaller.exe"

    # Скачиваем и устанавливаем
    Invoke-WebRequest -Uri $installerUrl -OutFile $installerPath
    Start-Process -FilePath $installerPath -ArgumentList "--quiet --norestart --add Microsoft.VisualStudio.Workload.MSBuildTools" -Wait

    Remove-Item -Path $installerPath
    Write-Host "MSBuild has been installed."
}

# Проверка и установка NuGet
Write-Host "Checking if NuGet is installed..."
$nugetPath = "$env:TEMP\nuget.exe"
if (-not (Test-Path -Path $nugetPath)) {
    Write-Host "NuGet is not installed. Downloading..."
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
    Write-Host "NuGet has been installed."
}

# Проверка и установка Inno Setup
Write-Host "Checking if Inno Setup is installed..."
$isccPath = "C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
if (-not (Test-Path -Path $isccPath)) {
    Write-Host "Inno Setup is not installed. Installing..."
    Invoke-WebRequest -Uri "https://jrsoftware.org/download.php/is.exe" -OutFile "$env:TEMP\InnoSetupInstaller.exe"
    Start-Process -FilePath "$env:TEMP\InnoSetupInstaller.exe" -ArgumentList "/VERYSILENT" -Wait
    Remove-Item -Path "$env:TEMP\InnoSetupInstaller.exe"
    Write-Host "Inno Setup has been installed."
}

# Проверка локального репозитория
Write-Host "Checking if the local repository exists..."
$localRepoPath = "C:\Projects\Calculator"
if (-not (Test-Path -Path $localRepoPath)) {
    Write-Host "Local repository not found. Cloning..."
    git clone "https://github.com/P4r4cosm/Calculator.git" $localRepoPath
} else {
    Set-Location -Path $localRepoPath
    git pull
}

# Восстановление NuGet пакетов
Write-Host "Restoring NuGet packages..."
& $nugetPath restore "$localRepoPath\Calculator.sln"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Failed to restore NuGet packages. Check your configuration."
    exit 1
}

# Сборка проекта
Write-Host "Building the project..."
& $msbuildPath "$localRepoPath\Calculator.sln" /p:Configuration=Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Project build failed."
    exit 1
}
# Создание установочного файла через Inno Setup
Write-Host "Creating the installer..."
$outputDir = "$localRepoPath"
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

# Проверка наличия ISCC.exe
if (-not (Test-Path -Path $isccPath)) {
    Write-Error "Inno Setup is not installed or not found at '$isccPath'."
    exit 1
}

# Компиляция установщика
Write-Host "Compiling the installer..."
& $isccPath $innoConfigPath
if ($LASTEXITCODE -ne 0) {
    Write-Error "Error occurred while creating the installer."
    exit 1
}

Write-Host "Installer has been created successfully. Check the output directory: $outputDir"


# Путь к созданному установщику
$installerFilePath = "$outputDir\CalculatorInstaller.exe"

# Проверка, что установочный файл существует
#if (-not (Test-Path -Path $installerFilePath)) {
#    Write-Error "Installer file not found at $installerFilePath. Something went wrong."
#    exit 1
#}

# Запуск установщика
#Write-Host "Launching the installer..."
#Start-Process -FilePath $installerFilePath -Wait


Write-Host "Script completed successfully."
