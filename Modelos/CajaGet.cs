using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonederoFichines.Modelos
{
    public class CajaGet
    {
        public Paging paging { get; set; }
        public IList<Result> results { get; set; }

        public class Paging
        {
            public int total { get; set; }
            public int offset { get; set; }
            public int limit { get; set; }
        }

        public class Qr
        {
            public string image { get; set; }
            public string template_document { get; set; }
            public string template_image { get; set; }
        }

        public class Result
        {
            public int user_id { get; set; }
            public string name { get; set; }
            public bool fixed_amount { get; set; }
            public string store_id { get; set; }
            public string url { get; set; }
            public string external_id { get; set; }
            public int id { get; set; }
            public Qr qr { get; set; }
            public DateTime date_created { get; set; }
            public DateTime date_last_updated { get; set; }
            public string external_store_id { get; set; }
        }
    }
}
