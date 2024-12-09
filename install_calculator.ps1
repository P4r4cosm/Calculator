# Установка кодировки консоли для поддержки кириллицы
[Console]::OutputEncoding = [System.Text.Encoding]::UTF8

# Проверка и установка Git
Write-Host "Проверка установки Git..."
if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Write-Host "Git не установлен. Установка..."
    Invoke-WebRequest -Uri "https://github.com/git-for-windows/git/releases/latest/download/Git-2.42.0-64-bit.exe" -OutFile "$env:TEMP\GitInstaller.exe"
    Start-Process -FilePath "$env:TEMP\GitInstaller.exe" -ArgumentList "/VERYSILENT" -Wait
    Remove-Item -Path "$env:TEMP\GitInstaller.exe"
    Write-Host "Git установлен."
}

# Проверка и установка MSBuild
$msbuildPath = "C:\Program Files (x86)\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\msbuild.exe"
Write-Host "Проверка установки MSBuild..."
if (-not (Test-Path -Path $msbuildPath)) {
    Write-Host "MSBuild не установлен. Установка..."
    Invoke-WebRequest -Uri "https://aka.ms/vs/17/release/vs_BuildTools.exe" -OutFile "$env:TEMP\VSBuildToolsInstaller.exe"
    Start-Process -FilePath "$env:TEMP\VSBuildToolsInstaller.exe" -ArgumentList "--quiet --norestart --wait --add Microsoft.VisualStudio.Workload.MSBuildTools" -Wait
    Remove-Item -Path "$env:TEMP\VSBuildToolsInstaller.exe"
    Write-Host "MSBuild установлен."
}

# Проверка и установка NuGet
Write-Host "Проверка установки NuGet..."
$nugetPath = "$env:TEMP\nuget.exe"
if (-not (Test-Path -Path $nugetPath)) {
    Write-Host "NuGet не установлен. Загрузка..."
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
    Write-Host "NuGet установлен."
}

# Проверка и установка Inno Setup
Write-Host "Проверка установки Inno Setup..."
$isccPath = "C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
if (-not (Test-Path -Path $isccPath)) {
    Write-Host "Inno Setup не установлен. Установка..."
    Invoke-WebRequest -Uri "https://jrsoftware.org/download.php/is.exe" -OutFile "$env:TEMP\InnoSetupInstaller.exe"
    Start-Process -FilePath "$env:TEMP\InnoSetupInstaller.exe" -ArgumentList "/VERYSILENT" -Wait
    Remove-Item -Path "$env:TEMP\InnoSetupInstaller.exe"
    Write-Host "Inno Setup установлен."
}

# Проверка наличия локального репозитория
Write-Host "Проверка локального репозитория..."
$localRepoPath = "C:\Projects\Calculator"
if (!(Test-Path -Path $localRepoPath)) {
    Write-Host "Локальный репозиторий отсутствует. Клонирование..."
    git clone "https://github.com/P4r4cosm/Calculator.git" $localRepoPath
} else {
    Set-Location -Path $localRepoPath
    git pull
}

# Восстановление NuGet пакетов
Write-Host "Восстановление NuGet пакетов..."
& $nugetPath restore "$localRepoPath\Calculator.sln"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Не удалось восстановить пакеты NuGet. Проверьте настройки."
    exit 1
}

# Сборка проекта
Write-Host "Сборка проекта..."
& $msbuildPath "$localRepoPath\Calculator.sln" /p:Configuration=Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Сборка проекта завершилась с ошибкой."
    exit 1
}

# Создание установщика через Inno Setup
Write-Host "Создание установщика..."
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
    Write-Error "Ошибка при создании установщика."
    exit 1
}

Write-Host "Скрипт завершен успешно."
