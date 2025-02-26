@echo off
setlocal

set KC_HOME=%~dp0
set KCBIN=%KC_HOME%bin\kc.bat
cd /d %KC_HOME%

call "%KCBIN%" %* start-dev --http-port=8040 --https-port=8041 --http-management-port=9040
pause