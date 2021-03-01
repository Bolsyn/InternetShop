using System;
using System.Collections.Generic;
using System.Text;

namespace InternetShop.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Developer { get; set; }
        public string Description { get; set; }
        public List<string> Comments { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }

    }
}
