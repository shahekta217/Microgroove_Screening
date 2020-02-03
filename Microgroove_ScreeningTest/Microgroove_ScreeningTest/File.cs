using System;
using System.Collections.Generic;
using System.Text;

namespace Microgroove_ScreeningTest
{
    public class File
    {
        public string Dt;
        public string type;
        public List<Order> orders;
        public Ender ender;
    }

    public class Ender
    {
        public string process;
        public string paid;
        public string created;
    }

    public class Order
    {
        public string dt;
        public string code;
        public string number;
        public Buyer buyer;
        public Timing timing;
        public List<Item> items;

    }

    public class Item
    {
        public string sku;
        public string qty;
    }

    public class Timing
    {
        public string start;
        public string stop;
        public string gap;
        public string offset;
        public string pause;
    }

    public class Buyer
    {
        public string name;
        public string street;
        public string zip;
    }
}
