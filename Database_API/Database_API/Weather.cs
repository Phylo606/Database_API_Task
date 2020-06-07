using System;
using System.Collections.Generic;
using System.Text;

namespace Database_API
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public int Celsius { get; set; }
        public int Farenheit => 32 + (int)(Celsius / 0.5556);
        public string Summary { get; set; }
    }
}
