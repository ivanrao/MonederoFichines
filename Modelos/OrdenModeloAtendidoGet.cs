using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonederoFichines.Modelos
{
    class OrdenModeloAtendidoGet
    {
        public string id { get; set; }
        public IList<Item> items { get; set; }
        public int collector_id { get; set; }
        public Collector collector { get; set; }
        public int total_amount { get; set; }
        public int amount { get; set; }
        public string external_reference { get; set; }
        public string operation_type { get; set; }
        public PaymentMethods payment_methods { get; set; }
        public string marketplace { get; set; }
        public int marketplace_fee { get; set; }
        public int sponsor_id { get; set; }
        public BackUrls back_urls { get; set; }
        public Payer payer { get; set; }
        public DateTime expiration_date_to { get; set; }
        public bool expires { get; set; }
        public string additional_info { get; set; }
        public string site_id { get; set; }
        public long client_id { get; set; }
        public IList<string> processing_modes { get; set; }
        public InternalMetadata internal_metadata { get; set; }

        public class Item
        {
            public string id { get; set; }
            public string title { get; set; }
            public int quantity { get; set; }
            public string currency_id { get; set; }
            public int unit_price { get; set; }
            public string description { get; set; }
        }

        public class Collector
        {
        }

        public class ExcludedPaymentMethod
        {
            public string id { get; set; }
        }

        public class ExcludedPaymentType
        {
            public string id { get; set; }
        }

        public class PaymentMethods
        {
            public IList<ExcludedPaymentMethod> excluded_payment_methods { get; set; }
            public IList<ExcludedPaymentType> excluded_payment_types { get; set; }
        }

        public class BackUrls
        {
            public string success { get; set; }
            public string pending { get; set; }
            public string failure { get; set; }
        }

        public class Identification
        {
            public string number { get; set; }
            public string type { get; set; }
        }

        public class Address
        {
            public bool primary { get; set; }
            public string zip { get; set; }
        }

        public class Phone
        {
            public string area_code { get; set; }
            public string number { get; set; }
        }

        public class Payer
        {
            public int id { get; set; }
            public string email { get; set; }
            public Identification identification { get; set; }
            public Address address { get; set; }
            public Phone phone { get; set; }
            public IList<object> internal_tags { get; set; }
        }

        public class InternalMetadata
        {
        }
    }
}
