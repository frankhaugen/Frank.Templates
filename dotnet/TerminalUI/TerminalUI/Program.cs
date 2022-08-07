// See https://aka.ms/new-console-template for more information
using Terminal.Gui;
using Home;

Console.WriteLine("Hello, World!");

Application.Init();
var top = Application.Top;
top.Add(new BasicView());
Application.Run();