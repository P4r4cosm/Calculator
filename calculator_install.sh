#!/usr/bin/env bash
#
# Скрипт для непрерывной интеграции и установки Python-калькулятора на Debian/Ubuntu

# Прерывать выполнение при ошибке
set -e

# 1. Проверка и установка необходимых зависимостей
echo "=== 1. Checking and installing dependencies (git, python3, pip, fpm) ==="
sudo apt-get update

# Проверка git
if ! command -v git &>/dev/null; then
  echo "Git not found. Installing..."
  sudo apt-get install -y git
else
  echo "Git is already installed."
fi

# Проверка python3, pip
if ! command -v python3 &>/dev/null; then
  echo "Python3 not found. Installing..."
  sudo apt-get install -y python3
else
  echo "Python3 is already installed."
fi

if ! command -v pip3 &>/dev/null; then
  echo "pip3 not found. Installing..."
  sudo apt-get install -y python3-pip
else
  echo "pip3 is already installed."
fi

# Проверка fpm (часто пакет называется ruby-fpm)
if ! command -v fpm &>/dev/null; then
  echo "fpm not found. Installing..."
  # В некоторых системах пакет fpm называется ruby-fpm, либо нужно ставить через gem
  # попробуем через apt:
  sudo apt-get install -y ruby ruby-dev rubygems build-essential
  sudo gem install --no-document fpm
else
  echo "fpm is already installed."
fi

# 2. Клонирование или обновление репозитория
echo "=== 2. Cloning or pulling the repository ==="
REPO_URL="https://github.com/P4r4cosm/Calculator.git"
# Локальная папка, куда будем клонировать
LOCAL_REPO_PATH="$HOME/calculator_repo"

if [ ! -d "$LOCAL_REPO_PATH/.git" ]; then
  echo "Local repo not found. Cloning to $LOCAL_REPO_PATH..."
  git clone "$REPO_URL" "$LOCAL_REPO_PATH"
else
  echo "Local repo found. Pulling latest changes..."
  cd "$LOCAL_REPO_PATH"
  git pull
  cd -
fi

# 3. Установка Python-зависимостей (в файле requirements.txt, если он есть)
#    Для примера предположим, что requirements.txt находится в папке "linux/"
#    или в корне — подкорректируйте путь при необходимости.

echo "=== 3. Installing Python dependencies ==="
cd "$LOCAL_REPO_PATH/linux"
if [ -f "requirements.txt" ]; then
  pip3 install --upgrade -r requirements.txt
else
  echo "No requirements.txt found. Skipping pip install..."
fi

# 4. Запуск тестов (unittest)
echo "=== 4. Running unittests ==="
# Предположим, что все тесты лежат в папке tests/
# При необходимости можно уточнить путь: python3 -m unittest discover -s ./tests
python3 -m unittest discover -s tests

echo "Unit tests passed successfully."

# 5. Создание deb-пакета.
#    Для этого используем fpm, упакуем файлы из папки linux/
#    в пакет с именем my-calculator_<version>_all.deb
#
#    Ниже простой пример: берём всю папку linux (где лежат main.py, *.py, tests/),
#    устанавливаем их в /opt/my_calculator (или /usr/local/bin — на ваше усмотрение),
#    а в post-install script создаём символическую ссылку в /usr/local/bin.

APP_NAME="my_calculator"
APP_VERSION="1.0.0"
INSTALL_DIR="/opt/$APP_NAME"   # куда сложим python-файлы

echo "=== 5. Building .deb package with fpm ==="
cd "$LOCAL_REPO_PATH"

# (Опционально) очищаем мусор, если уже собирали ранее
rm -f "${APP_NAME}"*.deb

# Создадим временную папку сборки
BUILD_DIR="$LOCAL_REPO_PATH/package_build"
rm -rf "$BUILD_DIR"
mkdir -p "$BUILD_DIR/$INSTALL_DIR"

# Скопируем файлы из папки linux/ в BUILD_DIR
cp -r linux/* "$BUILD_DIR/$INSTALL_DIR"

# Напишем post-install скрипт, который сделает shortcut/символьную ссылку
# например, чтобы можно было запускать "my_calculator" в консоли напрямую.
mkdir -p "$BUILD_DIR/scripts"
cat << 'EOF' > "$BUILD_DIR/scripts/postinstall"
#!/bin/bash
set -e
# Создаем (или обновляем) ссылку в /usr/local/bin
ln -sf /opt/my_calculator/main.py /usr/local/bin/my_calculator
chmod +x /usr/local/bin/my_calculator
echo "my_calculator is installed. Run it via 'my_calculator'"
EOF
chmod +x "$BUILD_DIR/scripts/postinstall"

# Собираем deb-пакет
fpm \
  -s dir \
  -t deb \
  -n "$APP_NAME" \
  -v "$APP_VERSION" \
  --deb-no-default-config-files \
  --prefix / \
  --post-install "$BUILD_DIR/scripts/postinstall" \
  --description "Python Calculator App" \
  --url "https://github.com/P4r4cosm/Calculator" \
  -C "$BUILD_DIR" \
  .

echo "Deb-package has been created."
ls -lh "${APP_NAME}"*.deb

# 6. Установка приложения
#    Установим созданный .deb при помощи dpkg -i
echo "=== 6. Installing the .deb package ==="
sudo dpkg -i "${APP_NAME}"*.deb

echo "Installation complete. You can run the app by typing 'my_calculator' in the terminal."
