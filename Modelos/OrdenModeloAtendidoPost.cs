using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonederoFichines.Modelos
{
    public class OrdenModeloAtendidoPost
    {
        public string external_reference { get; set; }
        public string notification_url { get; set; }
        public int sponsor_id { get; set; }
        public IList<ItemOrden> items { get; set; }

        public class ItemOrden
        {
            public string id { get; set; }
            public string title { get; set; }
            public string currency_id { get; set; }
            public double unit_price { get; set; }
            public int quantity { get; set; }
            public string description { get; set; }
            public string picture_url { get; set; }
        }
    }
}
