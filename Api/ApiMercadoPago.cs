using MonederoFichines.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static MonederoFichines.Modelos.OrdenModeloAtendidoPost;

namespace MonederoFichines.Api
{
    class ApiMercadoPago
    {
        public static readonly string userId = "569771402";                                                                         // Vendedor
        public static readonly string accessToken = "APP_USR-2735819449801949-051723-03454e26f7f6c5415cea09a06471c775-569771402";   // Vendedor
        public static readonly int sponsorId = 571587697;                                                                           // Sponsor
        public static readonly string cajaId = "caja3";

        public async Task<string> GetSucursales(string userId, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.mercadopago.com/users/" + userId + "/stores/search?access_token=" + accessToken))
                {
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var suc = response.Content.ReadAsStringAsync();

                        var json = JsonConvert.DeserializeObject<dynamic>(suc.Result);

                        return suc.Result;
                    }

                    return "No se pudo obtener la sucursal";
                }
            }
        }

        public async Task<string> GetCajas(string userId, string accessToken)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.mercadopago.com/pos?access_token=" + accessToken))
                {
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var suc = response.Content.ReadAsStringAsync();

                        return suc.Result;
                    }

                    return "No se pudo obtener las cajas";
                }
            }
        }

        public async Task<string> PostOrdenModeloAtendido()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.mercadopago.com/mpmobile/instore/qr/" + userId + "/" + cajaId + "?access_token=" + accessToken))
                {
                    OrdenModeloAtendidoPost orden = LlenarInfoOrden();

                    request.Content = new StringContent(JsonConvert.SerializeObject(orden));
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var suc = response.Content.ReadAsStringAsync();

                        return suc.Result;
                    }

                    return "No se pudo crear la orden";
                }
            }
        }

        public async Task<bool> GetPago(string externalReference)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.mercadopago.com/v1/payments/search?external_reference=" + externalReference + "&access_token=" + accessToken))
                {
                    var response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var suc = response.Content.ReadAsStringAsync();

                        return ComprobarResultado(suc.Result);
                    }

                    return false;
                }
            }
        }

        ////// Metodos Auxiliares ////////////////////////////////////////////////////////////////////////////////////////////////

        public bool ComprobarResultado(string resultado)
        {
            var pago = JsonConvert.DeserializeObject<PagoGet>(resultado);

            if (pago.results.Count > 0)
            {
                return true;
            }

            return false;
        }

        public OrdenModeloAtendidoPost LlenarInfoOrden()
        {
            OrdenModeloAtendidoPost orden = new OrdenModeloAtendidoPost();

            orden.external_reference = Guid.NewGuid().ToString().Replace("-", "");
            orden.notification_url = "";
            orden.sponsor_id = sponsorId;

            orden.items = new List<ItemOrden>();
            orden.items.Add(LlenarInfoItems());

            return orden;
        }

        public ItemOrden LlenarInfoItems()
        {
            ItemOrden item = new ItemOrden();

            item.id = "1";
            item.title = "Tetris";
            item.currency_id = "ARS";
            item.unit_price = 30;
            item.quantity = 1;
            item.description = "Ficha tetris";
            item.picture_url = "";

            return item;
        }
    }
}
