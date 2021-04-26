namespace andoryu.TravellingSalesman
{

    public class City
    {
        public int x {get; set;}
        public int y {get; set;}
    }

    public class Path
    {
        public City a {get; set;}
        public City b {get; set;}
    }

    public class Circle
    {
        public int x {get; set;}
        public int y {get; set;}
        public int radius {get; set;}
        public string colour {get; set;}
    }

    public class Line
    {
        public int x1 {get; set;}
        public int y1 {get; set;}
        public int x2 {get; set;}
        public int y2 {get; set;}

        public int width {get; set;}

        public string colour {get; set;}
    }
}