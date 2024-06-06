using System;

namespace Кулинарный_сайт.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double  Calorie_content { get; set; }
        public double Squirrels { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public int Glycemic_index { get; set; }
    }
}
