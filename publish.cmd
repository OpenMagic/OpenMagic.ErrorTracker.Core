@echo off
rem Publish the NuGet package 
call node %~dp0scripts\tasks publish -- %*