#!/usr/bin/env bash

cd `dirname $0`
../../BinarySerializer.Console.exe serialize -a "../../Contracts.dll" -t Contracts.ComplexObject < serialize1.input.json > serialize1.output.bin