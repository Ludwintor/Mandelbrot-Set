@echo off
dotnet-coverage collect -f xml -o coverage.xml dotnet test MandelbrotSet.Tests

reportgenerator -reports:coverage.xml -targetdir:.\report -assemblyfilters:+MandelbrotSet.dll -classfilters:+MandelbrotSet.Plot.*;+MandelbrotSet.Utils.*

pause