using System;
using System.Collections.Generic;
using System.Threading;

public class PizzaShopManagementSystem
{
    /// <summary>
    /// Represents a pizza order with an order number and the time it was received.
    /// </summary>
    public class PizzaOrder
    {
        public int OrderNumber { get; set; }
        public DateTime TimeReceived { get; set; }
    }

    /// <summary>
    /// Represents a baked pizza with an order number and the time it was ready.
    /// </summary>
    public class Pizza
    {
        public int OrderNumber { get; set; }
        public DateTime TimeReady { get; set; }
    }

    /// <summary>
    /// Represents a baker in the pizza shop.
    /// </summary>
    public class Baker
    {
        public int Id { get; set; }

        /// <summary>
        /// Starts the baking process for the baker.
        /// </summary>
        public void StartBaking(Queue<PizzaOrder> orderQueue, List<Pizza> storage, object lockObject, ManualResetEvent shutdownEvent)
        {
            while (!shutdownEvent.WaitOne(0))
            {
                PizzaOrder order;
                lock (lockObject)
                {
                    if (orderQueue.Count > 0)
                    {
                        order = orderQueue.Dequeue();
                        Console.WriteLine($"{order.OrderNumber}, Baking started by Baker {Id}");
                    }
                    else
                    {
                        order = null;
                    }
                }

                if (order != null)
                {
                    Thread.Sleep(5000); // Simulating baking time
                    Pizza pizza = new Pizza { OrderNumber = order.OrderNumber, TimeReady = DateTime.Now };
                    ReserveStorage(storage, pizza);
                    Console.WriteLine($"{pizza.OrderNumber}, Baking completed by Baker {Id}");
                }
            }
        }

        private void ReserveStorage(List<Pizza> storage, Pizza pizza)
        {
            lock (storage)
            {
                // Attempt to reserve space in the storage
                while (storage.Count >= 10)
                {
                    Monitor.Wait(storage);
                }

                storage.Add(pizza);
                Monitor.PulseAll(storage);
            }
        }
    }

    /// <summary>
    /// Represents a courier responsible for pizza delivery.
    /// </summary>
    public class Courier
    {
        public int Id { get; set; }
        public int CargoCapacity { get; set; }

        /// <summary>
        /// Starts the pizza delivery process for the courier.
        /// </summary>
        public void StartDelivering(List<Pizza> storage, ManualResetEvent shutdownEvent)
        {
            while (!shutdownEvent.WaitOne(0))
            {
                Pizza pizza;
                lock (storage)
                {
                    if (storage.Count > 0)
                    {
                        pizza = storage[0];
                        storage.RemoveAt(0);
                        Console.WriteLine($"{pizza.OrderNumber}, Delivery started by Courier {Id}");
                    }
                    else
                    {
                        pizza = null;
                    }
                }

                if (pizza != null)
                {
                    Thread.Sleep(3000); // Simulating delivery time
                    Console.WriteLine($"{pizza.OrderNumber}, Delivery completed by Courier {Id}");
                }
            }
        }
    }

    /// <summary>
    /// Entry point of the Pizza Shop Management System.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            int numberOfBakers = 2;
            int numberOfCouriers = 3;

            Queue<PizzaOrder> orderQueue = new Queue<PizzaOrder>();
            List<Pizza> storage = new List<Pizza>();

            object storageLock = new object();
            ManualResetEvent shutdownEvent = new ManualResetEvent(false);

            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < numberOfBakers; i++)
            {
                Baker baker = new Baker { Id = i + 1 };
                Thread bakerThread = new Thread(() => baker.StartBaking(orderQueue, storage, storageLock, shutdownEvent));
                bakerThread.Start();
                threads.Add(bakerThread);
            }

            for (int i = 0; i < numberOfCouriers; i++)
            {
                Courier courier = new Courier { Id = i + 1, CargoCapacity = 2 };
                Thread courierThread = new Thread(() => courier.StartDelivering(storage, shutdownEvent));
                courierThread.Start();
                threads.Add(courierThread);
            }

            for (int i = 1; i <= 15; i++)
            {
                PizzaOrder order = new PizzaOrder { OrderNumber = i, TimeReceived = DateTime.Now };
                orderQueue.Enqueue(order);
                Console.WriteLine($"{order.OrderNumber}, Order received");
                Thread.Sleep(2000);
            }

            shutdownEvent.Set(); // Signal threads to exit

            foreach (var thread in threads)
            {
                thread.Join();
            }

            AnalyzeAndProvideRecommendations(storage, orderQueue, numberOfBakers, numberOfCouriers);
        }

        /// <summary>
        /// Analyzes the performance of the pizza shop and provides recommendations to the owner.
        /// </summary>
        public static void AnalyzeAndProvideRecommendations(List<Pizza> storage, Queue<PizzaOrder> orderQueue, int numberOfBakers, int numberOfCouriers)
        {
            // Analysis logic and recommendations go here
            // For demonstration purposes, just print a message
            Console.WriteLine("Analysis and recommendations:");
            Console.WriteLine($"- Number of Bakers: {numberOfBakers}");
            Console.WriteLine($"- Number of Couriers: {numberOfCouriers}");
            Console.WriteLine($"- Orders in Queue: {orderQueue.Count}");
            Console.WriteLine($"- Pizzas in Storage: {storage.Count}");
        }
    }
}
