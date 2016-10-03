@ECHO OFF
SET basedir=.\TestSuite
SET testdir=%basedir%\MiCaseCodeGeneratorResultTests
copy Results\Tests\DAL\*.cs "%testdir%\DAL"
copy Results\Tests\Logic\*.cs "%testdir%\Logic"
copy Results\Tests\MiCaseCodeGeneratorResultTests.csproj "%testdir%"
:: build test project & run tests
msbuild "%testdir%\MiCaseCodeGeneratorResultTests.csproj" /t:Build /p:Configuration=Debug;Platform=AnyCPU
nunit-console /nologo "%testdir%\bin\Debug\MiCaseCodeGeneratorResultTests.dll"