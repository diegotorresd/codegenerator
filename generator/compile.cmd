@ECHO OFF
SET basedir=.\TestSuite
SET resultdir=%basedir%\MiCaseCodeGeneratorResult
copy Results\DAL\*.cs "%resultdir%\DAL"
copy Results\Entities\*.cs "%resultdir%\Entities"
copy Results\Logic\*.cs "%resultdir%\Logic"
copy Results\MiCaseCodeGeneratorResult.csproj "%resultdir%"
msbuild "%resultdir%\MiCaseCodeGeneratorResult.csproj" /t:Build /p:Configuration=Debug;Platform=AnyCPU