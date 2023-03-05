namespace PractiseAlgorithms.Models;
public sealed class Person : IComparable<Person>
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }

    public static bool operator ==(Person first, Person next)
    {
        if (first.Name == next.Name && first.Surname == next.Surname)
        {
            return true;
        }

        return false;
    }

    public static bool operator !=(Person first, Person next)
    {
        if ((first.Name != next.Name) || (first.Surname != next.Surname))
        {
            return true;
        }

        return false;
    }

    public static Person operator +(Person first, Person second)
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

    public int CompareTo(Person? other)
    {
        if (other is null)
            throw new NullReferenceException($"{nameof(other)} is null");

        if (Age > other!.Age)
        {
            return 1;
        }
        else if (Age < other!.Age)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public override bool Equals(object obj)
    {
        if (obj is null)
            return false;

        if (obj is Person)
        {
            var other = obj as Person;

            if (other!.Age == Age)
                return true;
        }

        return false;
    }
}
