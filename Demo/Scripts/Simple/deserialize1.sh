#!/usr/bin/env bash

cd `dirname $0`
echo -e "\xAD" | ../../BinarySerializer.Console.exe deserialize -t System.Int32 > deserialize1.output.json