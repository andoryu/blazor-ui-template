using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace andoryu.TravellingSalesman.NN
{

    public class Distance
    {
        public City city;
        public double distance;
    }

    public class NearestNeighbour
    {
        private List<City> cities;

        public NearestNeighbour(List<City> cities)
        {
            //take a copy - we will be destroying this
            this.cities = cities.ToList(); 
        }

        private double CalcDistance(City a, City b)
        {
            double x = (double)(a.x - b.x);
            double y = (double)(a.y - b.y);

            return Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2));

        }

        public double run(IProgress<Path> progress)
        {

            var first = cities.First();            
            double sum_distance = 0.0;

            var current = first;

            do
            {
                cities.Remove(current);

                //calculate the distance from current to cities in 
                var result = cities.Select(c => new Distance {city = c, distance = CalcDistance(current, c)})
                                    .OrderBy(d => d.distance);

                var closest_path = result.First();
                sum_distance += closest_path.distance;
                progress?.Report(new Path {a = current, b = closest_path.city});

                current = closest_path.city;

            } while (cities.Count > 1);

            sum_distance += CalcDistance(current, first);
            progress?.Report(new Path {a = current, b = first});

            return sum_distance;
        }

    }
}