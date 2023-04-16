namespace LearningReflection;

public interface ITalk
{
    void Talk(string sentence);
}

public class EmployeeMarkerAttribute : Attribute
{
}

public class Person : ITalk
{
    public string Name { get; set; }

    public int Age { get; set; }

    private string _privateField = "Test";

    public Person()
    {
        Console.WriteLine("Person being created.");
    }

    public Person(string name)
    {
        Console.WriteLine($"Person with name {name} being created.");
        Name = name;
    }

    private Person(string name, int age)
    {
        Console.WriteLine($"Person with name {name} and age {age} being created.");
        Name = name;
    }

    public void Talk(string sentence)
    {
        Console.WriteLine(sentence);
    }

    protected void Yell(string sentence)
    {
        Console.WriteLine(sentence.ToUpper());
    }

    public override string ToString()
    {
        return $"{Name}, {Age}, {_privateField}";
    }
}

[EmployeeMarker]
public class Employee : Person
{
    public string Company { get; set; }
}

public class Alien : ITalk
{
    public void Talk(string sentence)
    {
        Console.WriteLine($"Alien: {sentence}");
    }
}