cd /d %~dp0

echo BQAAYWJj | ..\..\BinarySerializer.Console.exe deserialize --base64 -c "..\..\Demo.dll" -t System.String > deserialize1.output.json