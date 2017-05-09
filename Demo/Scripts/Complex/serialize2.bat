cd /d %~dp0

..\..\BinarySerializer.Console.exe serialize -a "..\..\Contracts.dll" -t "Contracts.ListComplexObject" < serialize2.input.json > serialize2.output.bin