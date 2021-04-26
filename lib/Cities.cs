using System;
using System.Linq;
using System.Collections.Generic;

namespace andoryu.TravellingSalesman
{
    public static class Cities
    {
        public static List<City>GenerateCities(int number, int max_x=1024, int max_y=768)
        {
            var cities = new List<City>();
            var r = new Random();

            foreach (int i in Enumerable.Range(0, number))
            {
                var cx = r.Next(100, max_x);
                var cy = r.Next(100, max_y);

                cities.Add(new City{x=cx, y=cy});
            }

            return cities; 
        }
    }
}