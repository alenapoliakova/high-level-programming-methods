using System;
using System.Collections.Generic;

/// <summary>
/// Represents a student with additional properties and methods.
/// </summary>
public class Student : Person
{
    private List<Teacher> teachers = new List<Teacher>();

    /// <summary>
    /// Gets or sets the list of teachers associated with the student.
    /// </summary>
    public List<Teacher> Teachers
    {
        get { return teachers; }
        set { teachers = value; }
    }

    /// <summary>
    /// Prints information about the student.
    /// </summary>
    public override void Print()
    {
        Console.WriteLine($"Student - Age: {Age}");
    }

    /// <summary>
    /// Returns a string representation of the student.
    /// </summary>
    /// <returns>A string containing information about the student.</returns>
    public override string ToString()
    {
        return $"Student - Age: {Age}";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current student.
    /// </summary>
    /// <param name="obj">The object to compare with the current student.</param>
    /// <returns>True if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (!base.Equals(obj))
            return false;

        Student otherStudent = (Student)obj;
        return teachers.SequenceEqual(otherStudent.teachers);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current student.</returns>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        foreach (var teacher in teachers)
        {
            hash ^= teacher.GetHashCode();
        }
        return hash;
    }

    /// <summary>
    /// Creates a deep copy of the current student.
    /// </summary>
    /// <returns>A new Student object with the same age and teachers as the current student.</returns>
    public override Person Clone()
    {
        Student clone = new Student { Age = this.Age };
        clone.Teachers.AddRange(this.Teachers);
        return clone;
    }
}
