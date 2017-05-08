#!/usr/bin/env bash

cd `dirname $0`
echo -e "\x13\x01\x00\x01" | ../../BinarySerializer.Console.exe deserialize -t System.Int32 > deserialize2.output.json