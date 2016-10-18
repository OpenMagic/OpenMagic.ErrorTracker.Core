@echo off
rem Build script used by myget.org. If required it can be run locally.
call npm install --no-optional
if "%errorlevel%" NEQ "0" exit /b %errorlevel%
call %~dp0build.cmd 
if "%errorlevel%" NEQ "0" exit /b %errorlevel%