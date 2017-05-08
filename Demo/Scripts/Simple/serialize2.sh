#!/usr/bin/env bash

cd `dirname $0`
echo -65538 | ../../BinarySerializer.Console.exe serialize -t System.Int32 > serialize2.output.bin