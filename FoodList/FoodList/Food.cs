using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace FoodList
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }


        public override string ToString()
        {
            return $"{Name} from {Location}";
        }
    }
}
