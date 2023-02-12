// See https://aka.ms/new-console-template for more information

using LocalizationProject.BL.Managers;
using LocalizationProject.BL.Sources;
using LocalizationProject.Datas;
using LocalizationProject.Domain.Interfaces;

ILocalizationManager manager = new LocalizationManager();
manager.RegisterSource(new InMemorySource(LocalizationData.Source));

var input = Console.ReadLine();
if(input is null)
    Console.WriteLine("Некорректно!");

Console.WriteLine(manager.GetString(input).Result);