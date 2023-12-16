using System;

/// <summary>
/// Represents a student with an advisor, inheriting from the Student class.
/// </summary>
public class StudentWithAdvisor : Student
{
    /// <summary>
    /// Gets or sets the advisor of the student.
    /// </summary>
    public Teacher Advisor { get; set; }

    /// <summary>
    /// Prints information about the student with an advisor.
    /// </summary>
    public override void Print()
    {
        Console.WriteLine($"StudentWithAdvisor - Age: {Age}");
    }

    /// <summary>
    /// Returns a string representation of the student with an advisor.
    /// </summary>
    /// <returns>A string containing information about the student with an advisor.</returns>
    public override string ToString()
    {
        return $"StudentWithAdvisor - Age: {Age}";
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current student with an advisor.
    /// </summary>
    /// <param name="obj">The object to compare with the current student with an advisor.</param>
    /// <returns>True if the objects are equal; otherwise, false.</returns>
    public override bool Equals(object obj)
    {
        if (!base.Equals(obj))
            return false;

        StudentWithAdvisor otherStudent = (StudentWithAdvisor)obj;
        return Advisor.Equals(otherStudent.Advisor);
    }

    /// <summary>
    /// Serves as the default hash function.
    /// </summary>
    /// <returns>A hash code for the current student with an advisor.</returns>
    public override int GetHashCode()
    {
        int hash = base.GetHashCode();
        hash ^= Advisor.GetHashCode();
        return hash;
    }

    /// <summary>
    /// Creates a deep copy of the current student with an advisor.
    /// </summary>
    /// <returns>A new StudentWithAdvisor object with the same age, advisor, and teachers as the current student with an advisor.</returns>
    public override Person Clone()
    {
        StudentWithAdvisor clone = new StudentWithAdvisor { Age = this.Age, Advisor = this.Advisor };
        clone.Teachers.AddRange(this.Teachers);
        return clone;
    }
}
