using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class StudentWithAdvisorTests
{
    [Test]
    public void ToString_ReturnsCorrectString()
    {
        StudentWithAdvisor student = new StudentWithAdvisor { Age = 20 };

        string result = student.ToString();

        Assert.AreEqual("StudentWithAdvisor - Age: 20", result);
    }

    [Test]
    public void Equals_TwoDifferentStudentsWithAdvisors_ReturnsFalse()
    {
        StudentWithAdvisor student1 = new StudentWithAdvisor { Age = 30 };
        StudentWithAdvisor student2 = new StudentWithAdvisor { Age = 35 };

        bool result = student1.Equals(student2);

        Assert.IsFalse(result);
    }
}
