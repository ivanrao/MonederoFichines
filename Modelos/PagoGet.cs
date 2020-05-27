using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonederoFichines.Modelos
{
    class PagoGet
    {
        public Paging paging { get; set; }
        public IList<Result> results { get; set; }
    }

    public class Paging
    {
        public int total { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class Metadata
    {
    }

    public class FeeDetail
    {
        public double amount { get; set; }
        public string fee_payer { get; set; }
        public string type { get; set; }
    }

    public class Payer
    {
        public string id { get; set; }
    }

    public class TransactionDetails
    {
        public int total_paid_amount { get; set; }
        public object acquirer_reference { get; set; }
        public int installment_amount { get; set; }
        public object financial_institution { get; set; }
        public double net_received_amount { get; set; }
        public int overpaid_amount { get; set; }
        public object external_resource_url { get; set; }
        public object payable_deferral_period { get; set; }
        public string payment_method_reference_id { get; set; }
    }

    public class Order
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class AdditionalInfo
    {
        public object nsu_processadora { get; set; }
        public object available_balance { get; set; }
    }

    public class Identification
    {
        public string number { get; set; }
        public string type { get; set; }
    }

    public class Cardholder
    {
        public Identification identification { get; set; }
        public string name { get; set; }
    }

    public class Card
    {
        public string first_six_digits { get; set; }
        public int expiration_year { get; set; }
        public DateTime date_created { get; set; }
        public int expiration_month { get; set; }
        public string id { get; set; }
        public Cardholder cardholder { get; set; }
        public string last_four_digits { get; set; }
        public DateTime date_last_updated { get; set; }
    }

    public class Result
    {
        public Metadata metadata { get; set; }
        public object corporation_id { get; set; }
        public string operation_type { get; set; }
        public IList<FeeDetail> fee_details { get; set; }
        public object notification_url { get; set; }
        public DateTime date_approved { get; set; }
        public object acquirer { get; set; }
        public object money_release_schema { get; set; }
        public Payer payer { get; set; }
        public TransactionDetails transaction_details { get; set; }
        public string statement_descriptor { get; set; }
        public object call_for_authorize_id { get; set; }
        public int installments { get; set; }
        public string pos_id { get; set; }
        public string external_reference { get; set; }
        public object date_of_expiration { get; set; }
        public long id { get; set; }
        public string payment_type_id { get; set; }
        public Order order { get; set; }
        public object counter_currency { get; set; }
        public string status_detail { get; set; }
        public object differential_pricing_id { get; set; }
        public AdditionalInfo additional_info { get; set; }
        public bool live_mode { get; set; }
        public object marketplace_owner { get; set; }
        public Card card { get; set; }
        public object integrator_id { get; set; }
        public string status { get; set; }
        public int transaction_amount_refunded { get; set; }
        public int transaction_amount { get; set; }
        public string description { get; set; }
        public DateTime money_release_date { get; set; }
        public object merchant_number { get; set; }
        public IList<object> refunds { get; set; }
        public string authorization_code { get; set; }
        public bool captured { get; set; }
        public int collector_id { get; set; }
        public object merchant_account_id { get; set; }
        public int taxes_amount { get; set; }
        public DateTime date_last_updated { get; set; }
        public int coupon_amount { get; set; }
        public string store_id { get; set; }
        public DateTime date_created { get; set; }
        public IList<object> acquirer_reconciliation { get; set; }
        public int sponsor_id { get; set; }
        public int shipping_amount { get; set; }
        public string issuer_id { get; set; }
        public string payment_method_id { get; set; }
        public bool binary_mode { get; set; }
        public object platform_id { get; set; }
        public object deduction_schema { get; set; }
        public string processing_mode { get; set; }
        public string currency_id { get; set; }
        public int shipping_cost { get; set; }
    }
}
