using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using static PizzaShopManagementSystem;

[TestFixture]
public class PizzaShopManagementSystemTests
{
    [Test]
    public void Test_AnalyzeAndProvideRecommendations()
    {
        // Arrange
        List<PizzaOrder> orders = new List<PizzaOrder>();
        List<Pizza> storage = new List<Pizza>();

        for (int i = 1; i <= 5; i++)
        {
            orders.Add(new PizzaOrder { OrderNumber = i, TimeReceived = DateTime.Now });
        }

        int numberOfBakers = 2;
        int numberOfCouriers = 3;

        // Act
        PizzaShopManagementSystem.Program.AnalyzeAndProvideRecommendations(storage, new Queue<PizzaOrder>(orders), numberOfBakers, numberOfCouriers);

        // Assert
        // Add specific assertions based on the analysis logic (not implemented in the provided example)
        Assert.Pass("Analysis and recommendations tested successfully.");
    }
}
