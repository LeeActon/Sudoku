# Sudoku

This repository contains the source code for a Sudoku puzzle game implemented in **C#** using the **Blazor WebAssembly** technology.

It builds in the Visual Studio 2019 development environment (requiring Version 16.6.0 Preview 2.1 at minimum).

It uses Blazor WebAssembly 3.2.0 Preview 4 (https://devblogs.microsoft.com/aspnet/blazor-webassembly-3-2-0-preview-4-release-now-available/).

Component Projects:
- BlazingSudoku.Client - Implements the UI that runs in a web browser using WebAssembly technology.
- BlazingSudoku.Server - ASP.NET Core server that serves up the client (not required).
- Sudoku class library - The **C#** representation of the Sudoku puzzle + solver.
- PuzzleTester - A program for testing the Sudoku class library.

See:
- https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor
- https://en.wikipedia.org/wiki/Blazor
