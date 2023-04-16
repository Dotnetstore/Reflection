using System.Reflection;

namespace LearningReflection;

public class Module2
{
    static void CodeFromModule2()
    {
        var currentAssembly = Assembly.GetExecutingAssembly();
        var typesFromCurrentAssembly = currentAssembly.GetTypes();

        //foreach (var type in typesFromCurrentAssembly)
        //{
        //    Console.WriteLine(type.Name);
        //}

        var oneTypeFromCurrentAssembly = currentAssembly.GetType("LearningReflection.Person");
        //Console.WriteLine(oneTypeFromCurrentAssembly.Name);

        foreach (var type in oneTypeFromCurrentAssembly.GetConstructors(
                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            Console.WriteLine($"{type}, {type.IsPublic}");
        }

        foreach (var type in oneTypeFromCurrentAssembly.GetMethods(
                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            Console.WriteLine($"{type}, {type.IsPublic}");
        }

        foreach (var type in oneTypeFromCurrentAssembly.GetFields(
                     BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            Console.WriteLine($"{type}, {type.IsPublic}");
        }

        //var externalAssembly = Assembly.Load("System.Text.Json");
        //var typesFromExternalAssembly = externalAssembly.GetTypes();

        //var modules = externalAssembly.GetModules();
        //var module = externalAssembly.GetModule("System.Text.Json.dll");

        Console.WriteLine("Hello, World!");
    }
}