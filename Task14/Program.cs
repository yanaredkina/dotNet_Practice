using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SQLite;

namespace Task14
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>();

            using (var connection = new SQLiteConnection("Data Source=./../../../../northwind.db"))
            {
                connection.Open();

                var command = new SQLiteCommand(
                    "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, ShipVia, " +
                    "Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry " +
                    "FROM Orders;", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order();
                        order.OrderID = Convert.ToInt32(reader["OrderID"]);
                        order.CustomerID = reader["CustomerID"] is DBNull ? null : (string)reader["CustomerID"];
                        order.EmployeeID = reader["EmployeeID"] is DBNull ? null : (long)reader["EmployeeID"];
                        order.OrderDate = reader["OrderDate"] is DBNull ? null : (DateTime)reader["OrderDate"];
                        order.RequiredDate = reader["RequiredDate"] is DBNull ? null : (DateTime)reader["RequiredDate"];
                        order.ShippedDate = reader["ShippedDate"] is DBNull ? null : (DateTime)reader["ShippedDate"];
                        order.ShipVia = reader["ShipVia"] is DBNull ? null : (long)reader["ShipVia"];
                        order.Freight = reader["Freight"] is DBNull ? null : (decimal)reader["Freight"];
                        order.ShipName = reader["ShipName"] is DBNull ? null : (string)reader["ShipName"];
                        order.ShipAddress = reader["ShipAddress"] is DBNull ? null : (string)reader["ShipAddress"];
                        order.ShipCity = reader["ShipCity"] is DBNull ? null : (string)reader["ShipCity"];
                        order.ShipRegion = reader["ShipRegion"] is DBNull ? null : (string)reader["ShipRegion"];
                        order.ShipPostalCode = reader["ShipPostalCode"] is DBNull ? null : (string)reader["ShipPostalCode"];
                        order.ShipCountry = reader["ShipCountry"] is DBNull ? null : (string)reader["ShipCountry"];

                        orders.Add(order);
                    }
                }
            }

            var query1 = orders
                .Select(o => o.ShipCountry)
                .Distinct()
                .Count();
            Console.WriteLine($"1. Количество стран, в которые доставлялся товар: {query1}\n");


            var query2 = orders
                .GroupBy(c => c.ShipCountry)
                .Select(group => new
                {
                    Country = group.Key,
                    CityCount = group.Select(q => q.ShipCity).Distinct().Count() });

            Console.WriteLine("2. Страны с указанным количеством различных городов, в которые доставлялся товар:");
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Country}: {item.CityCount}");
            }
            Console.WriteLine();


            var query3 = orders
                .Where(o => o.ShipCountry == "USA")
                .Sum(f => f.Freight);
            Console.WriteLine($"3. Общая сумма стоимости перевозки всех товаров по Америке: {query3}\n");


            var query4 = orders
                .Where(o => o.Freight < 100)
                .Sum(f => f.Freight);
            Console.WriteLine($"4. Общая сумма стоимости перевозки всех товаров, перевозка которых обходится дешевле 100$: {query4}\n");


            var query5 = orders
                .Where(o => o.ShipCountry == "Germany")
                .Average(o => o.Freight);
            Console.WriteLine($"5. Средняя стоимость перевозки всех товаров, доставляемых в Германию: {query5}\n");
        }
    }
}