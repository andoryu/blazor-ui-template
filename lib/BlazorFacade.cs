using System;
using System.Collections.Generic;


namespace andoryu.TravellingSalesman
{
    public class BlazorFacade
    {
        //model storage
        public List<Point> city_list {get; set;}
        public List<string> logs;


        //internal storage
        public BlazorFacade()
        {
            city_list = new();
            logs = new();
        }

        // public API
        public void GenerateCities(int number, int max_x=1920, int max_y=1080)
        {
            city_list = Cities.GenerateCities(number, max_x, max_y);
            CitiesHaveChanged();

            logs.Add($"Generated points for {number} cities.");
            LogsHaveChanged();
        }


        //event handling
        public event EventHandler LogChange;
        public event EventHandler CitiesChange;

        public List<string> GetLogs()
        {
            return logs;
        }

        public void SetLogs(List<string> logs)
        {
            this.logs = logs;
            LogsHaveChanged();
        }

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