using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonederoFichines.Modelos
{
    public class SucursalGet
    {
        public Paging paging { get; set; }
        public IList<Result> results { get; set; }

        public class Paging
        {
            public int total { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
        }

        public class Monday
        {
            public string open { get; set; }
            public string close { get; set; }
        }

        public class Tuesday
        {
            public string open { get; set; }
            public string close { get; set; }
        }

        public class Wednesday
        {
            public string open { get; set; }
            public string close { get; set; }
        }

        public class Thursday
        {
            public string open { get; set; }
            public string close { get; set; }
        }

        public class Friday
        {
            public string open { get; set; }
            public string close { get; set; }
        }

        public class BusinessHours
        {
            public IList<Monday> monday { get; set; }
            public IList<Tuesday> tuesday { get; set; }
            public IList<Wednesday> wednesday { get; set; }
            public IList<Thursday> thursday { get; set; }
            public IList<Friday> friday { get; set; }
        }

        public class Location
        {
            public string address_line { get; set; }
            public string reference { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
        }

        public class Result
        {
            public string id { get; set; }
            public string name { get; set; }
            public DateTime date_creation { get; set; }
            public BusinessHours business_hours { get; set; }
            public Location location { get; set; }
            public string external_id { get; set; }
        }
    }
}
