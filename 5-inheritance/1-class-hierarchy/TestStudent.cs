using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class StudentTests
{
    [Test]
    public void ToString_ReturnsCorrectString()
    {
        Student student = new Student { Age = 20 };

        string result = student.ToString();

        Assert.AreEqual("Student - Age: 20", result);
    }

    [Test]
    public void Equals_TwoEqualStudents_ReturnsTrue()
    {
        Student student1 = new Student { Age = 25 };
        Student student2 = new Student { Age = 25 };

        bool result = student1.Equals(student2);

        Assert.IsTrue(result);
    }

    [Test]
    public void Equals_TwoDifferentStudents_ReturnsFalse()
    {
        Student student1 = new Student { Age = 30 };
        Student student2 = new Student { Age = 35 };

        bool result = student1.Equals(student2);

        Assert.IsFalse(result);
    }

    [Test]
    public void GetHashCode_ReturnsHashCode()
    {
        Student student = new Student { Age = 22 };

        int hashCode = student.GetHashCode();

        Assert.AreEqual(22.GetHashCode(), hashCode);
    }

    [Test]
    public void Clone_ReturnsDeepCopy()
    {
        Student student = new Student { Age = 18 };
        Teacher teacher = new Teacher();
        student.Teachers.Add(teacher);

        Student clone = student.Clone() as Student;

        Assert.IsNotNull(clone);
        Assert.AreEqual(student.Age, clone.Age);
        Assert.AreNotSame(student, clone);
        CollectionAssert.AreEqual(student.Teachers, clone.Teachers);
    }
}
