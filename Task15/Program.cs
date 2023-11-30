using System;
using System.Linq;
using System.Xml.Linq;

namespace Task15
{
    class Program
    {
        static void Main(string[] args)
        {

            #region #1 Creating XML

            XElement computers = new XElement("Computers",
                new XElement("Computer",
                    new XAttribute("Name", "Chif"),
                    new XElement("Processor",
                        new XAttribute("Vendor", "Intel"),
                        new XAttribute("Model", "Intel Core I7"),
                        new XAttribute("Frequency", 3)),
                    new XElement("Memory",
                        new XAttribute("Volume", 4)),
                    new XElement("HDD",
                        new XAttribute("Volume", 1500)),
                    new XElement("Mouse", "Logitech")),
                new XElement("Computer",
                    new XAttribute("Name", "Workstation"),
                    new XElement("Processor",
                        new XAttribute("Vendor", "Intel"),
                        new XAttribute("Model", "Intel Core I3"),
                        new XAttribute("Frequency", 2.6)),
                    new XElement("Memory",
                        new XAttribute("Volume", 2)),
                    new XElement("HDD",
                        new XAttribute("Volume", 1000)),
                    new XElement("Mouse", "Logitech")),
                new XElement("Computer",
                    new XAttribute("Name", "AMD Workstation"),
                    new XElement("Processor",
                        new XAttribute("Vendor", "AMD"),
                        new XAttribute("Model", "AMD Ryzen 7"),
                        new XAttribute("Frequency", 3)),
                    new XElement("Memory",
                        new XAttribute("Volume", 3)),
                    new XElement("HDD",
                        new XAttribute("Volume", 6000)),
                    new XElement("Mouse", "Microsoft")));
            XDocument xmldoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), computers);
            #endregion


            #region #2 LINQ to XML

            Console.WriteLine("Производители процессоров (различные) на имеющихся компьютерах:");
            computers.Descendants("Processor")
                .Select(e => (string)e.Attribute("Vendor")!)
                .Distinct()
                .PrintCollection();

            Console.WriteLine("\nРазличные производители мышек на имеющихся компьютерах:");
            computers.Descendants("Mouse")
                .Select(e => e.Value)
                .Distinct()
                .PrintCollection();

            Console.WriteLine("\nСуммарный общий объем дискового пространства на всех компьютерах:");
            computers.Descendants("HDD")
                .Select(e => (int)e.Attribute("Volume")!)
                .Sum()
                .PrintInt();

            Console.WriteLine("\nMemory before upgrade:");
            computers.Descendants("Memory")
                .PrintCollection();

            foreach (var item in computers.Descendants("Memory"))
            {
                int value;
                if ((value = (int)item.Attribute("Volume")!) < 4)
                {
                    item.SetAttributeValue("Volume", value + 8);
                }
            }
            Console.WriteLine("\nMemory after upgrade:");
            computers.Descendants("Memory")
                .PrintCollection();

            #endregion


            #region #3 Saving XML to file

            xmldoc.Save("computers.xml");

            #endregion
        }
    }
}
