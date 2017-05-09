#!/usr/bin/env bash

cd `dirname $0`
echo -e "\x05\x00\x00\x61\x62\x63" | ../../BinarySerializer.Console.exe deserialize -c "../../Demo.dll" -t System.String > deserialize1.output.json