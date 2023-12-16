using System;
using System.Collections.Generic;

/// <summary>
/// Represents a teacher with a list of students, inheriting from the Person class.
/// </summary>
public class Teacher : Person
{
    private List<Student> students = new List<Student>();

    /// <summary>
    /// Gets or sets the list of students associated with the teacher.
    /// </summary>
    public List<Student> Students
    {
        get { return students; }
        set { students = value; }
    }

    /// <summary>
    /// Prints information about the teacher.
    /// </summary>
    public override void Print()
    {
        Console.WriteLine($"Teacher - Age: {Age}");
    }

    /// <summary>
    /// Returns a string representation of the teacher.
    /// </summary>
    /// <returns>A string containing information about the teacher.</returns>
    public override string ToString()
    {
        return $"Teacher - Age: {Age}";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current teacher.
    /// </summary>
    /// <param name="obj">The object to compare with the current teacher.</param>
    /// <returns>True if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (!base.Equals(obj))
            return false;

        Teacher otherTeacher = (Teacher)obj;
        return students.SequenceEqual(otherTeacher.students);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current teacher.</returns>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        foreach (var student in students)
        {
            hash ^= student.GetHashCode();
        }
        return hash;
    }

    /// <summary>
    /// Creates a deep copy of the current teacher.
    /// </summary>
    /// <returns>A new Teacher object with the same age and students as the current teacher.</returns>
    public override Person Clone()
    {
        Teacher clone = new Teacher { Age = this.Age };
        clone.Students.AddRange(this.Students);
        return clone;
    }
}
