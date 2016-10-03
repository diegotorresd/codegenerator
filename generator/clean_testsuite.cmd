@ECHO OFF
SET basedir=.\TestSuite
:: prevent the necessary files from being deleted
attrib +r %basedir%\MiCaseCodeGeneratorResult\Entities\BaseEntity.cs
attrib +r %basedir%\MiCaseCodeGeneratorResult\Logic\BaseLogic.cs

del /Q %basedir%\MiCaseCodeGeneratorResult\DAL\*.cs 2>&1 NUL
del /Q %basedir%\MiCaseCodeGeneratorResult\Entities\*.cs 2>&1 NUL
del /Q %basedir%\MiCaseCodeGeneratorResult\Logic\*.cs 2>&1 NUL
del /Q %basedir%\MiCaseCodeGeneratorResult\*.csproj 2>&1 NUL

attrib -r %basedir%\MiCaseCodeGeneratorResult\Entities\BaseEntity.cs
attrib -r %basedir%\MiCaseCodeGeneratorResult\Logic\BaseLogic.cs

:: tests
del /Q %basedir%\MiCaseCodeGeneratorResultTests\DAL\*.cs 2>&1 NUL
del /Q %basedir%\MiCaseCodeGeneratorResultTests\Logic\*.cs 2>&1 NUL
del /Q %basedir%\MiCaseCodeGeneratorResultTests\*.csproj 2>&1 NUL