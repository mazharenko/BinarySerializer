#!/usr/bin/env bash

cd `dirname $0`
echo "\"Foo © bar 𝌆 baz ☃ qux\"" | ../../BinarySerializer.Console.exe serialize -t System.String > serialize3.output.bin