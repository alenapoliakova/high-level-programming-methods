using NUnit.Framework;
using System;

[TestFixture]
public class PersonTests
{
    [Test]
    public void ToString_ReturnsCorrectString()
    {
        Person person = new Person { Age = 25 };

        string result = person.ToString();

        Assert.AreEqual("Person - Age: 25", result);
    }

    [Test]
    public void Equals_TwoEqualPersons_ReturnsTrue()
    {
        Person person1 = new Person { Age = 30 };
        Person person2 = new Person { Age = 30 };

        bool result = person1.Equals(person2);

        Assert.IsTrue(result);
    }

    [Test]
    public void Equals_TwoDifferentPersons_ReturnsFalse()
    {
        Person person1 = new Person { Age = 25 };
        Person person2 = new Person { Age = 30 };

        bool result = person1.Equals(person2);

        Assert.IsFalse(result);
    }

    [Test]
    public void GetHashCode_ReturnsHashCode()
    {
        Person person = new Person { Age = 35 };

        int hashCode = person.GetHashCode();

        Assert.AreEqual(35.GetHashCode(), hashCode);
    }

    [Test]
    public void Clone_ReturnsDeepCopy()
    {
        Person person = new Person { Age = 40 };

        Person clone = person.Clone() as Person;

        Assert.IsNotNull(clone);
        Assert.AreEqual(person.Age, clone.Age);
        Assert.AreNotSame(person, clone);
    }
}
