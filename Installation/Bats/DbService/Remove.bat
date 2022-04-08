echo Check paths ...
set REL_PATH=..\nssm-2.24\win64\nssm.exe
set ABS_PATH=%~dp0%
set NSSM_PATH="%ABS_PATH%%REL_PATH%"
echo %NSSM_PATH%
echo Start ConPass.DbService  stopping ...

%NSSM_PATH% remove ConPass.DbService confirm

pause