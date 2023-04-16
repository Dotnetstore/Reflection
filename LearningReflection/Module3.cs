using System.Reflection;

namespace LearningReflection;

public class Module3
{
    static void CodeFromModule3()
    {
        //var personType = typeof(Person);
        //var personConstructors = personType.GetConstructors(
        //    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

        //foreach (var personConstructor in personConstructors)
        //{
        //    Console.WriteLine(personConstructor);
        //}

        //var personPrivateConstructor = personType.GetConstructor(
        //    BindingFlags.Instance | BindingFlags.NonPublic,
        //    null, new[] { typeof(string), typeof(int) },
        //    null);

        //var person1 = personConstructors[0].Invoke(null);
        //var person2 = personConstructors[1].Invoke(new object[] { "Hans" });
        //var person3 = personConstructors[2].Invoke(new object[] { "Hans", 51 });

        //var person4 = Activator.CreateInstance("LearningReflection", "LearningReflection.Person");
        //var person5 = Activator.CreateInstance(
        //    "LearningReflection", "LearningReflection.Person",
        //    true,
        //    BindingFlags.Instance | BindingFlags.Public,
        //    null,
        //    new object[] { "Hans" },
        //    null,
        //    null);

        //var personTypeFromString = Type.GetType("LearningReflection.Person");
        //var person6 = Activator.CreateInstance(
        //    personTypeFromString, new object[] { "Hans" });

        //var person7 = Activator.CreateInstance(
        //    "LearningReflection", "LearningReflection.Person",
        //    true,
        //    BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
        //    null,
        //    new object[] { "Hans", 52 },
        //    null,
        //    null);

        var currentAssembly = Assembly.GetExecutingAssembly();
        var person8 = currentAssembly.CreateInstance("LearningReflection.Person");

        var typeFromConfig = Type.GetType(GetTypeFromConfiguration());
        var iTalkInstance = Activator.CreateInstance(typeFromConfig) as ITalk;
        iTalkInstance.Talk("I am the best!");

        static string GetTypeFromConfiguration()
        {
            return "LearningReflection.Alien";
        }
    }
}