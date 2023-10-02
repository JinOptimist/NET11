// See https://aka.ms/new-console-template for more information
using TaskExample;

Console.WriteLine("Hello, World!");

var bot = new DoStuff();
//bot.CountToUnfinity("Wally");
//bot.CountToUnfinity("Eva");

var taskForWally = new Task(() => bot.CountToUnfinity("Wally"));
taskForWally.Start();

var taskForEva = new Task(() => bot.CountToUnfinity("Eva"));
taskForEva.Start();


Console.ReadLine();