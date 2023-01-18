@ECHO OFF

set PATH=%systemroot%

echo Installing WindowsService...
echo ---------------------------------------------------
sc.exe create "SyncDbService" binpath="D:\publish\SyncDbService\SyncDbs.exe"
echo ---------------------------------------------------
echo Done.
sc start "SyncDbService"
pause