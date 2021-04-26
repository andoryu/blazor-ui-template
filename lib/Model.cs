using System.Collections.Generic;

namespace andoryu.TravellingSalesman
{
    public class Model
    {
        public List<City> cities {get; set;}
        public List<Path> paths {get; set;}
        public List<string> logs {get; set;}

        public Model()
        {
            cities = new();
            paths = new();
            logs = new();
        }

    }
}