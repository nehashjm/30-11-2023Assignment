﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
}

class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description {  get; set; }
}
class Program
    {
    static void MapProperties(Source source, Destination destination)
    {
        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] deatinationProperties = typeof(Destination).GetProperties();
   
        foreach(var sourceProperty in sourceProperties)
        {
            foreach(var destinationProperty in deatinationProperties)
            {
                if(sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }
        }
    }
        static void Main(string[] args)
        {
            Source source = new Source {Id =1,Name ="SourceObject" };
            Destination destination = new Destination { Id = 0, Name = "Destination Object", Description = "Hello this is description of Destination object" };

            MapProperties(source, destination);
        Console.WriteLine("Mapped Properties in Destination");
        Console.WriteLine($"Id: { destination.Id}");
        Console.WriteLine($"Name: {destination.Name}");
        Console.WriteLine($"Description: {destination.Description}");
        Console.ReadKey();
    }
    }

