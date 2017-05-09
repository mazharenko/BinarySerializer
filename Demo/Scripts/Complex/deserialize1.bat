cd /d %~dp0

..\..\BinarySerializer.Console.exe deserialize -a "..\..\Contracts.dll" -t Contracts.ComplexObject -i deserialize1.input.bin -o deserialize1.output.json