#!/bin/sh

# Ensure we're in a git repository
if [ ! -d ".git" ]; then
  echo "This directory does not seem to be a Git repository."
  exit 1
fi

# Fetch the full repository history
git fetch --unshallow || {
  echo "Notice: It seems the repository was already unshallowed or fetching the full history is not possible."
}

curl -sSL https://dot.net/v1/dotnet-install.sh > dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh -c 7.0
dotnet --version
dotnet publish Foxhole.Artillery -o output -c Release