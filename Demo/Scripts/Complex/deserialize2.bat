cd /d %~dp0

..\..\BinarySerializer.Console.exe deserialize -a "..\..\Contracts.dll" -t "Contracts.ListComplexObject" -i deserialize2.input.bin -o deserialize2.output.json