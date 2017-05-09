#!/usr/bin/env bash

cd `dirname $0`
../../BinarySerializer.Console.exe deserialize -a "../../Contracts.dll" -t "Contracts.ListComplexObject" -i deserialize2.input.bin -o deserialize2.output.json