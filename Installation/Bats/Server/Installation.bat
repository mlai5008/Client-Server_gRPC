@echo OFF
echo Check paths ...

set SERV_PATH=D:\Repository\ConPassNet\Sources\Server\ConPass.Server\bin\Debug\netcoreapp3.1\ConPass.Server.exe
echo %SERV_PATH%
set NSSM_PATH=D:\Bats\nssm-2.24\win64\nssm.exe
echo %NSSM_PATH%
echo Start service installation ...

%NSSM_PATH% install ConPass.Server %SERV_PATH%
%NSSM_PATH% set ConPass.Server Description Main Server

pause



























































