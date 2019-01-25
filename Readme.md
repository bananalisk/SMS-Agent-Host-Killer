# "SMS Agent Host" Killer

This is a windows service that stops the service "SMS Agent Host" if it is not already stopped.

It will only act during weekdays between 08:00 and 19:00.

## Installation

Build the project, then run the follwing command as admin:

```
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe <PATH TO PROJECT>\bin\Debug\SMSKiller.exe
```

## Uninstallation

Same command as installation, but with the parameter flag "-u"

```
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe -u <PATH TO PROJECT>\bin\Debug\SMSKiller.exe
```