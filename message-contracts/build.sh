#!/bin/bash
set -e

if [ ! -f "tools/bin/protoc" ]; then
    mkdir -p tools && cd tools
    wget -O protoc.zip https://github.com/google/protobuf/releases/download/v3.5.1/protoc-3.5.1-linux-x86_64.zip
    unzip protoc.zip
    rm -f protoc.zip
    chmod +x bin/protoc
    cd ..
fi

rm -rf dist ../Retro.Net.Api/RealTime/Messages ../gameboy-client/src/app/messages
mkdir -p dist/dotnet dist/js ../Retro.Net.Api/RealTime/Messages ../gameboy-client/src/app/messages
./tools/bin/protoc --proto_path=src \
                   --js_out=import_style=commonjs,binary:dist/js \
                   --csharp_out=dist/dotnet \
                   --csharp_opt="base_namespace=Retro.Net.Api.RealTime.Messages" \
                   `echo src/*.proto`
cp -r dist/dotnet/* ../Retro.Net.Api/RealTime/Messages
cp -r dist/js/* ../gameboy-client/src/app/messages