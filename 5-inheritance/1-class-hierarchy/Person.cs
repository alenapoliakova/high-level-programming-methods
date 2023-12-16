using System;

/// <summary>
/// Represents a person with an age property.
/// </summary>
public class Person
{
    private int age;

    /// <summary>
    /// Gets or sets the age of the person. Age cannot be negative.
    /// </summary>
    public int Age
    {
        get { return age; }
        set { if (value < 0) value = 0; age = value; }
    }

    /// <summary>
    /// Prints information about the person.
    /// </summary>
    public virtual void Print()
    {
        Console.WriteLine($"Person - Age: {Age}");
    }

    /// <summary>
    /// Returns a string representation of the person.
    /// </summary>
    /// <returns>A string containing information about the person.</returns>
    public override string ToString()
    {
        return $"Person - Age: {Age}";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current person.
    /// </summary>
    /// <param name="obj">The object to compare with the current person.</param>
    /// <returns>True if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Person otherPerson = (Person)obj;
        return Age == otherPerson.Age;
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current person.</returns>
    public override int GetHashCode()
    {
        return Age.GetHashCode();
    }

    /// <summary>
    /// Creates a deep copy of the current person.
    /// </summary>
    /// <returns>A new Person object with the same age as the current person.</returns>
    public virtual Person Clone()
    {
        return new Person { Age = this.Age };
    }
}
