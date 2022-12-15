using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Food
    {
        private string name;
        private string type;
        private double price;
        private int preparationTime;

        public string GetName() { return this.name; }
        public new string GetType() { return this.type; }
        public double GetPrice() { return this.price; }
        public int GetPreparationTime() { return this.preparationTime; }
        


        public Food(string name, string type, double price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
            SetPreparationTime();
        }

        private void SetPreparationTime()
        {
            if (this.type == "Starter")
                this.preparationTime = 5;
            else if (this.type == "Main")
                this.preparationTime = 20;
            else if (this.type == "Dessert")
                this.preparationTime = 5;
            else if (this.type == "Drink")
                this.preparationTime = 1;
        }

        public override string ToString()
        {
            return string.Format("{0,-10}  {1,-20} {2,5:f2}  {3,10:d2}",
                 type, name, price, preparationTime);
        }

    }
}
