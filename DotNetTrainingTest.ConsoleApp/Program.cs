// See https://aka.ms/new-console-template for more information
using DotNetTrainingTest.ConsoleApp.ADODotNetExamples;

Console.WriteLine("Hello, World!");

ADODotNetExample aDODotNetExample = new ADODotNetExample();
aDODotNetExample.Read();
aDODotNetExample.Edit(10);
aDODotNetExample.Edit(11);
aDODotNetExample.Create("title test", "author test", "content test");
aDODotNetExample.Update(11, "title test2", "author test2", "content test2");
aDODotNetExample.Delete(11);
Console.ReadKey();

