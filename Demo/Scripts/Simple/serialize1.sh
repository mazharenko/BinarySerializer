#!/usr/bin/env bash

cd `dirname $0`
echo 45 | ../../BinarySerializer.Console.exe serialize -t System.Int32 > serialize1.output.bin