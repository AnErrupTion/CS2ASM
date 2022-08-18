cd CS2ASM/
dotnet build
cd ../Source/
dotnet build
cd ../
mv ../bin/net6.0/Mosaic.dll bin/net6.0/
cd bin/net6.0/
./CS2ASM -a0x100000 -camd64 -felf -tiso -omosaic.iso Mosaic.dll
cd ../../
