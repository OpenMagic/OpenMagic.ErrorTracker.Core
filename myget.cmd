@echo off
rem Build script used by myget.org. If required it can be run locally.

call build.cmd 
if "%errorlevel%" NEQ "0" exit /b %errorlevel%