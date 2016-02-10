#/bin/bash


echo "Building Mastercard-Core-CSharp"
#mcs -sdk:4.5 -r:bin/Newtonsoft.Json.dll,bin/RestSharp.dll,System.Runtime.Serialization.dll -target:library -out:bin/MastercardLibrary.dll -recurse:src/*.cs -doc:bin/MastercardLibrary.xml -platform:anycpu
xbuild
