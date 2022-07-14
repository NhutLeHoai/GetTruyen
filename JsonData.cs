using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTruyen
{
    public class JsonData
    {

    }
    public class Group
    {
        public Photo albums { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Album
    {
        public string name { get; set; }
        public string created_time { get; set; }
        public string id { get; set; }  
        public Photo photos { get; set; }
    }
    public class Photo
    {
        public Data[] data;
        public Paging paging { get; set; }
    }
    public class Data
    {
        public Largest_Image largest_image { get; set; }
        public string name { get; set; }
        public string created_time { get; set; }
        public string id { get; set; }
    }

    public class Largest_Image
    {
        public string source { get; set; }
        public string height { get; set; }
        public string width { get; set; }
    }

    public class Paging
    {

        public string next { get; set; }
        public string previous { get; set; }
        public Cursor cursors { get; set; }
    }
    public class Cursor
    {
        public string before { get; set; }
        public string after { get; set; }   
    }
}
    