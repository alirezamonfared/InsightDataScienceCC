SET FrameworkDir=%SystemRoot%\Microsoft.NET\Framework\
SET FrameworkVersion=v3.5
PATH=%PATH%;%FrameworkDir%\%FrameworkVersion%
DEL InsightDataScienceCC.exe
DEL .\tweet_output\*
csc.exe /define:DEBUG /optimize /out:InsightDataScienceCC.exe -nologo .\src\*.cs
InsightDataScienceCC.exe
MD tweet_output
MOVE ft1.txt .\tweet_output\ft1.txt
MOVE ft2.txt .\tweet_output\ft2.txt
