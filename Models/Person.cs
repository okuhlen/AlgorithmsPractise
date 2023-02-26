namespace PractiseAlgorithms.Models;
public sealed class Person
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public static bool operator == (Person first, Person next)
    {
        if (first.Name == next.Name && first.Surname == next.Surname)
        {
            return true;
        }

        return false;
    }

    public static bool operator != (Person first, Person next)
    {
        if ((first.Name != next.Name ) || (first.Surname != next.Surname))
        {
            return true;
        }

        return false;
    }

    public static Person operator + (Person first, Person second)
    {
        return new()
        {
            Name = $"{first.Name} {second.Name}",
            Surname = $"{first.Surname} {second.Surname}",
            Age = first.Age + second.Age
        };
    }

    public override string ToString()
    {
        return $"{Name} {Surname} {Age}";
    }
}
