// See https://aka.ms/new-console-template for more information
using DotNetTrainingTest.ConsoleApp.ADODotNetExamples;
using DotNetTrainingTest.ConsoleApp.DapperExamples;
using DotNetTrainingTest.ConsoleApp.EFCoreExamples;

Console.WriteLine("Hello, World!");

//ADODotNetExample aDODotNetExample = new ADODotNetExample();
//aDODotNetExample.Read();
//aDODotNetExample.Edit(10);
//aDODotNetExample.Edit(11);
//aDODotNetExample.Create("title test", "author test", "content test");
//aDODotNetExample.Update(11, "title test2", "author test2", "content test2");
//aDODotNetExample.Delete(11);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Edit(11);
//dapperExample.Create("Title test", "Autor test", "Content test");
//dapperExample.Update(13, "Title", "Author", "Content");
//dapperExample.Delete(12);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("EF title", "EF author", "EF content");
//eFCoreExample.Edit(14);
//eFCoreExample.Update(14, "EF title2", "EF author2", "EF content2");
eFCoreExample.Delete(14);
Console.ReadKey();


