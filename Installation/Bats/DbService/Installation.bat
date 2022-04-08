@echo OFF
echo Check paths ...

set SERV_PATH=D:\Repository\ConPassNet\Sources\Services\ConPass.DBService\ConPass.DBService\bin\Debug\netcoreapp3.1\ConPass.DBService.exe
echo %SERV_PATH%
set NSSM_PATH=D:\Bats\nssm-2.24\win64\nssm.exe
echo %NSSM_PATH%
echo Start service installation ...

%NSSM_PATH% install ConPass.DbService %SERV_PATH%
%NSSM_PATH% set ConPass.DbService Description This service works DB

pause



























































