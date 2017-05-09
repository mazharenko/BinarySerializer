cd /d %~dp0
                               
echo rQ== | ..\..\BinarySerializer.Console.exe deserialize --base64 -t System.Int32 > deserialize1.output.json