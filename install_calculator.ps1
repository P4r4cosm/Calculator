# Установка кодировки консоли для поддержки кириллицы
[Console]::OutputEncoding = [System.Text.Encoding]::GetEncoding("cp866")

# Проверка прав администратора
if (-not ([Security.Principal.WindowsPrincipal][Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")) {
    Write-Host "Скрипт должен быть запущен от имени администратора."
    exit 1
}

# Функция для скачивания и установки инструментов
function Install-Tool {
    param(
        [string]$Url,
        [string]$InstallerPath,
        [string]$Arguments
    )
    Write-Host "Загрузка и установка: $Url"
    try {
        Invoke-WebRequest -Uri $Url -OutFile $InstallerPath -ErrorAction Stop
        Start-Process -FilePath $InstallerPath -ArgumentList $Arguments -Wait
        Remove-Item -Path $InstallerPath
        Write-Host "Успешно установлено."
    } catch {
        Write-Error "Ошибка установки с URL $Url: $_"
        exit 1
    }
}

# Проверка и установка Git
Write-Host "Проверка наличия Git..."
if (-not (Get-Command git -ErrorAction SilentlyContinue)) {
    Install-Tool -Url "https://github.com/git-for-windows/git/releases/latest/download/Git-2.42.0-64-bit.exe" `
                 -InstallerPath "$env:TEMP\GitInstaller.exe" `
                 -Arguments "/VERYSILENT"
}

# Проверка и установка MSBuild
Write-Host "Проверка наличия MSBuild..."
$msbuildPath = Get-Command msbuild.exe -ErrorAction SilentlyContinue
if (-not $msbuildPath) {
    Install-Tool -Url "https://aka.ms/vs/17/release/vs_BuildTools.exe" `
                 -InstallerPath "$env:TEMP\VSBuildToolsInstaller.exe" `
                 -Arguments "--quiet --norestart --wait --add Microsoft.VisualStudio.Workload.MSBuildTools"
    $msbuildPath = Get-Command msbuild.exe -ErrorAction SilentlyContinue
    if (-not $msbuildPath) {
        Write-Error "MSBuild не найден после установки. Проверьте настройки."
        exit 1
    }
}

# Проверка и установка NuGet
Write-Host "Проверка наличия NuGet..."
$nugetPath = "$env:TEMP\nuget.exe"
if (-not (Test-Path -Path $nugetPath)) {
    Install-Tool -Url "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" `
                 -InstallerPath $nugetPath `
                 -Arguments ""
}

# Проверка и установка Inno Setup
Write-Host "Проверка наличия Inno Setup..."
$isccPath = "C:\Program Files (x86)\Inno Setup 6\ISCC.exe"
if (-not (Test-Path -Path $isccPath)) {
    Install-Tool -Url "https://jrsoftware.org/download.php/is.exe" `
                 -InstallerPath "$env:TEMP\InnoSetupInstaller.exe" `
                 -Arguments "/VERYSILENT"
}

# Проверка существования локального репозитория
Write-Host "Проверка наличия локального репозитория..."
$localRepoPath = "C:\Projects\Calculator"
if (-not (Test-Path -Path $localRepoPath)) {
    Write-Host "Локальный репозиторий не найден. Клонирование..."
    git clone "https://github.com/P4r4cosm/Calculator.git" $localRepoPath
} else {
    Write-Host "Локальный репозиторий найден. Обновление..."
    Set-Location -Path $localRepoPath
    git pull
}

# Восстановление пакетов NuGet
Write-Host "Восстановление NuGet пакетов..."
& $nugetPath restore "$localRepoPath\Calculator.sln"
if ($LASTEXITCODE -ne 0) {
    Write-Error "Не удалось восстановить NuGet пакеты."
    exit 1
}

# Сборка проекта
Write-Host "Сборка проекта..."
& $msbuildPath "$localRepoPath\Calculator.sln" /p:Configuration=Release
if ($LASTEXITCODE -ne 0) {
    Write-Error "Сборка проекта завершилась с ошибкой."
    exit 1
}

# Создание инсталлятора с помощью Inno Setup
Write-Host "Создание инсталлятора..."
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
    Write-Error "Ошибка при создании инсталлятора."
    exit 1
}

Write-Host "Скрипт успешно завершён."
