# Windows Service Template #

Boiler plate for new projects.

## Projects in solution ##

* ConsoleDebugger - console application for debugging
* Shell - windows service shell and installer.
* ServiceExec - Main entry point ServiceRunner, shared code, interfaces, etc.

## Dependancies ##

* Autofac
* log4net
* nunit

## Other Information ##

* DI setup for console and shell. Add additional features by adding services, following pattern with IAppService
* To change windows service install parameters use the app.config
* Auto error logging
* Configuration transforms for dev, test, prod
* Shared assembly versioning
* Need to add appender for shell project.
* Windows service installation
  1. Install: c:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe [project path]\Ws.Shell.exe
  2. Uninstall: c:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe /u [project path]\Ws.Shell.exe

