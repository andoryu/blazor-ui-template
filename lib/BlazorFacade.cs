using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using andoryu.TravellingSalesman.NN;

namespace andoryu.TravellingSalesman
{


       public class BlazorFacade
    {
        //model storage
        private Model model;

        public BlazorFacade()
        {
            model = new();
        }

        public void AddPath(Path path)
        {
            model.paths.Add(path);
            CitiesHaveChanged();
        }

        public void AddLog(string log, bool trigger_update=true)
        {
            model.logs.Add(log);
            if(trigger_update)
            {
                LogsHaveChanged();
            }
        }


        // public API
        public void GenerateCities(int number, int max_x=1920, int max_y=1080)
        {
            model.cities = Cities.GenerateCities(number, max_x, max_y);
            model.paths.Clear();
            CitiesHaveChanged();

            AddLog($"Generated points for {number} cities.");
        }

        public async void RunNearestNeighbour()
        {
            var watch = new Stopwatch();

            model.paths.Clear();
            CitiesHaveChanged();

            var nn = new NearestNeighbour(model.cities);

            var progress = new Progress<Path>(value => { AddPath(value); });
            
            watch.Start();
            var distance = await Task.Run(() => nn.run(progress));
            watch.Stop();

            AddLog("Running Nearest Neighbour algorithm", false);
            AddLog($"Nearest Neighbour distance: {distance:F2}", false);
            AddLog($"Executed in {watch.ElapsedMilliseconds} ms");

        }

        public List<object> GetDisplayList()
        {
            var dl = new List<object>();

            //add the paths first so that they get over drawn by the city dots
            foreach (var path in model.paths)
            {
                var line = new Line();
                line.x1 = path.a.x;
                line.y1 = path.a.y;
                line.x2 = path.b.x;
                line.y2 = path.b.y;

                line.width = 2;
                line.colour = "#101090";

                dl.Add(line);
            }

            //first circle in green
            var first = model.cities.First();
            var fcircle = new Circle();
            fcircle.x = first.x;
            fcircle.y = first.y;
            fcircle.radius = 5;

            fcircle.colour = "#00ff00";

            dl.Add(fcircle);

            //add the cities in so that they overwrite the paths
            foreach (var city in model.cities.Skip(1))
            {
                var circle = new Circle();
                circle.x = city.x;
                circle.y = city.y;
                circle.radius = 5;

                circle.colour = "#ffffff";

                dl.Add(circle);
            }

            return dl;
        }

        // getters/setters
        public List<string> GetLogs()
        {
            return model.logs;
        }

        public List<City> GetCities()
        {
            return model.cities;
        }

        //event handling
        public event EventHandler LogChange;
        public event EventHandler CitiesChange;

        private void LogsHaveChanged()
        {
            LogChange?.Invoke(this, EventArgs.Empty);
        }

        private void CitiesHaveChanged()
        {
            CitiesChange?.Invoke(this, EventArgs.Empty);
        }

    }
}