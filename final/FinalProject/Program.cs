using System;
using System.Diagnostics;

class Program {
    static void Main(string[] args)
    {
        Console.WriteLine("To install the dependencies, do the following:");
        Console.WriteLine("Install NuGet package manager");
        Console.WriteLine("Install NuGet package manager GUI for vscode");
        Console.WriteLine("Install ExifLibNet and TagLibSharp for this project");
        Console.WriteLine("Otherwise, code will not run");

        ProgramFlow programFlow = new();
        programFlow.Init();
    }
}