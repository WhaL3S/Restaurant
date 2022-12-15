using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    class Table
    {
        LinkedList<Food> foodList = new LinkedList<Food>();

        string name;
        int totalTime = 0;

        public Table(string name) { this.name = name; }

        public void AddFood(Food f)
        {
            foodList.AddLast(f);
            totalTime += f.GetPreparationTime();
        }

        public LinkedList<Food> GetFoodList() { return foodList; }
        public int GetTotalTime() { return totalTime; }
        public string GetName() { return name; }
    }
}
