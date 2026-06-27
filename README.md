# DesignPatterns-COM6031

C# console application for the COM6031 Design Patterns coursework.

**Student:** Francisco Castillo
**Student ID:** 22233580

The project demonstrates design pattern implementations across four scenarios:

* Document Creation System — Factory Method, Builder, Template Method
* Support Ticket System — Chain of Responsibility, Strategy
* File System Structure — Composite, Iterator
* Smart Home System — Command, Façade

## Running the application

A pre-built executable is available from the GitHub Release:

[Download latest executable](https://github.com/fjc-22233580/DesignPatterns-COM6031/releases/tag/Release)

Download the build artifact, extract it, and run the executable.

## System requirements

The submitted build is published as a self-contained Windows executable, so a separate .NET runtime installation should not be required.

Recommended environment:

* Windows 10 or later
* x64 system
* Console/terminal access

The project source targets .NET 10.

## Building from source

To build the project locally, install the .NET 10 SDK and run:

```bash
dotnet build
```

To publish a self-contained Windows executable:

```bash
dotnet publish -c Release -r win-x64 --self-contained true
```

## Notes

The application is intended to demonstrate design pattern structure and behaviour through console-based scenarios rather than provide a production application. Supporting menu and console view infrastructure is included to make the demonstrations easier to run.
