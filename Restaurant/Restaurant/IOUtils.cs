using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class IOUtils
    {
        public static Dictionary<String, Food> Read(string filename)
        {
            Dictionary<String, Food> menu = new Dictionary<String, Food>();
            using (StreamReader reader = new StreamReader(filename))
            {
                string line = null;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    string name = parts[0].Trim();
                    string type = parts[1].Trim();
                    double price = Convert.ToDouble(parts[2].Trim());
                    Food f = new Food(name, type, price);
                    menu.Add(name, f);
                }
            }
            return menu;
        }
    }
}
