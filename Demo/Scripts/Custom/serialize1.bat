cd /d %~dp0

echo "\u0000\u0000abc" | ..\..\BinarySerializer.Console.exe serialize -c "..\..\Demo.dll" -t System.String > serialize1.output.bin