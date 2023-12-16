using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class TeacherTests
{
    [Test]
    public void ToString_ReturnsCorrectString()
    {
        Teacher teacher = new Teacher { Age = 35 };

        string result = teacher.ToString();

        Assert.AreEqual("Teacher - Age: 35", result);
    }

    [Test]
    public void Equals_TwoEqualTeachers_ReturnsTrue()
    {
        Teacher teacher1 = new Teacher { Age = 40 };
        Teacher teacher2 = new Teacher { Age = 40 };

        bool result = teacher1.Equals(teacher2);

        Assert.IsTrue(result);
    }

    [Test]
    public void Equals_TwoDifferentTeachers_ReturnsFalse()
    {
        Teacher teacher1 = new Teacher { Age = 45 };
        Teacher teacher2 = new Teacher { Age = 50 };

        bool result = teacher1.Equals(teacher2);

        Assert.IsFalse(result);
    }

    [Test]
    public void GetHashCode_ReturnsHashCode()
    {
        Teacher teacher = new Teacher { Age = 42 };

        int hashCode = teacher.GetHashCode();

        Assert.AreEqual(42.GetHashCode(), hashCode);
    }

    [Test]
    public void Clone_ReturnsDeepCopy()
    {
        Teacher teacher = new Teacher { Age = 38 };
        Student student = new Student();
        teacher.Students.Add(student);

        Teacher clone = teacher.Clone() as Teacher;

        Assert.IsNotNull(clone);
        Assert.AreEqual(teacher.Age, clone.Age);
        Assert.AreNotSame(teacher, clone);
        CollectionAssert.AreEqual(teacher.Students, clone.Students);
    }
}
