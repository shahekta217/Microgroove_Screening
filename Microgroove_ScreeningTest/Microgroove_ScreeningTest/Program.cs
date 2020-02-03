using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Microgroove_ScreeningTest
{
    class Program
    {
        
        public void CsvToJson()
        {
            //Creating File object which will hold all the values
            File file = new File();
            List<Order> orders = new List<Order>();
            List<Item> items = new List<Item>();

            //Reading csv file
            var lines = System.IO.File.ReadAllLines(@"C:\Users\Ekta\Desktop\test.csv");

            var csv = new List<string[]>();
            foreach (string line in lines)
                csv.Add(line.Split(','));

            //Reading each line and creating reqired objects and adding those objects to file object
            for (int i = 0; i < lines.Length; i++)
            {
                if (csv[i][0].Trim('"') == "F")
                {
                    file.Dt = csv[i][1].Trim('"');
                    file.type = csv[i][2].Trim('"');
                }
                else if(csv[i][0].Trim('"') == "O")
                {
                    Order order = new Order();
                    items = new List<Item>();
                    order.dt = csv[i][1].Trim('"');
                    order.code = csv[i][2].Trim('"');
                    order.number = csv[i][3].Trim('"');
                    orders.Add(order);

                    file.orders = orders;
                }
                else if(csv[i][0].Trim('"') == "B")
                {
                    Buyer buyer = new Buyer();
                    buyer.name = csv[i][1].Trim('"');
                    buyer.street = csv[i][2].Trim('"');
                    buyer.zip = csv[i][3].Trim('"');
                    orders[orders.Count - 1].buyer = buyer; 
                }
                else if (csv[i][0].Trim('"') == "L")
                {
                    Item item = new Item();
                    item.sku = csv[i][1].Trim('"');
                    item.qty = csv[i][2].Trim('"');
                    items.Add(item);
                    orders[orders.Count - 1].items = items;
                }
                else if (csv[i][0].Trim('"') == "T")
                {
                    Timing timing = new Timing();
                    timing.start = csv[i][1].Trim('"');
                    timing.stop = csv[i][2].Trim('"');
                    timing.gap = csv[i][3].Trim('"');
                    timing.offset = csv[i][4].Trim('"');
                    timing.pause = csv[i][5].Trim('"');
                    orders[orders.Count - 1].timing = timing;
                }
                else if(csv[i][0].Trim('"') == "E")
                {
                    Ender ender = new Ender();
                    ender.process = csv[i][1].Trim('"');
                    ender.paid = csv[i][2].Trim('"');
                    ender.created = csv[i][3].Trim('"');
                    file.ender = ender;

                }
            }
            var op = JsonConvert.SerializeObject(file);
            Console.Write(op);
            Console.Read();
           
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CsvToJson();
         
        }
    }
}
