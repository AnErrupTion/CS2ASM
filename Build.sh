#!/usr/bin/env bash
dotnet build
cd bin/net6.0
./CS2ASM -a0x100000 -camd64 -felf -tiso -omosaic.iso MosaicOS.dll