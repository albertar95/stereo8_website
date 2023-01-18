@ECHO OFF

sc stop "SyncDbService"
sc delete "SyncDbService"
pause