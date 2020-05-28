using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonederoFichines.Api;
using MonederoFichines.Modelos;
using Newtonsoft.Json;

namespace MonederoFichines
{
    public partial class FormQR : Form
    {
        readonly ApiMercadoPago api = new ApiMercadoPago();
        private string cajaId;

        public FormQR()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
        }

        private void InitializeBackgroundWorker()
        {
            backgroundWorker1.DoWork += new DoWorkEventHandler(BackgroundWorker1_DoWork);
        }

        private void FormQR_Load(object sender, EventArgs e)
        {
            //if (backgroundWorker1.IsBusy != true)
            //{
            //    // Start the asynchronous operation.
            //    backgroundWorker1.RunWorkerAsync();
            //}
        }

        // This event handler is where the time-consuming work is done.
        private async void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            while (true)
            {
                // Perform a time consuming operation and report progress.
                var status = false;

                var orden = JsonConvert.DeserializeObject<OrdenModeloAtendidoGet>(await api.PostOrdenModeloAtendido(cajaId));

                Stopwatch sw = new Stopwatch();
                sw.Start();

                // Intenta buscar que haya realizado el pago durante 9 minutos = 540 segundos.
                while (!status && sw.Elapsed.TotalSeconds < 540)
                {
                    if (await api.GetPago(orden.external_reference))
                    {
                        status = true;
                        Console.WriteLine("Se encontro el pago de la siguiente orden: " + orden.external_reference);
                        
                        //// Le avisa al arduino que encontro un pago.
                        //serialPort1.Open();
                        //Thread.Sleep(2000);
                        //serialPort1.Write("pagoefectuado");
                        //serialPort1.Close();
                    }
                }
                sw.Stop();
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = await api.GetSucursales();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var cajasJson = await api.GetCajas();
            var caja = JsonConvert.DeserializeObject<CajaGet>(cajasJson);

            richTextBox2.Text = cajasJson;
            comboBox1.DataSource = caja.results;
            comboBox1.DisplayMember = "name";
            comboBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = (CajaGet.Result)comboBox1.SelectedItem;
            pictureBox1.ImageLocation = item.qr.image;
            cajaId = item.external_id;

            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
