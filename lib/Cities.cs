using System;
using System.Linq;
using System.Collections.Generic;

namespace andoryu.TravellingSalesman
{

    public class Point
    {
        public int x {get; set;}
        public int y {get; set;}
    }

    public static class Cities
    {
        public static List<Point>GenerateCities(int number, int max_x=1024, int max_y=768)
        {
            var cities = new List<Point>();
            var r = new Random();

            foreach (int i in Enumerable.Range(0, number))
            {
                var cx = r.Next(100, max_x);
                var cy = r.Next(100, max_y);

                cities.Add(new Point{x=cx, y=cy});
            }

            return cities; 
        }
    }
}