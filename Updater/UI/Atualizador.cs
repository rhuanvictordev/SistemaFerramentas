using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Net.Http;
using Newtonsoft.Json;

namespace Updater
{
    public partial class Atualizador : Form
    {
        private readonly HttpClient _httpClient;
        private string appName = ConfigurationManager.AppSettings["AppName"];
        private string appVersion = ConfigurationManager.AppSettings["AppVersion"];
        private string serverUrl = ConfigurationManager.AppSettings["ServerUrl"];

        public Atualizador(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
            lblInfo.Text = "Servidor indisponível no momento";
            lblLog.Text = "Consultando Servidor...";
            btnExecutar.Visible = true;
        }

        private void Atualizador_Load(object sender, EventArgs e)
        {
            lblNomeSistema.Text = $"{appName}   [ Atualizador ]";
            requisitarServidor(serverUrl, appName, appVersion);
        }

        private async Task requisitarServidor(string serverUrl, string appName, string appVersion)
        {
            Object contentBody = new { appName = appName, appVersion = appVersion };
            string json = JsonConvert.SerializeObject(contentBody);
            //MessageBox.Show(json);

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(serverUrl, content);
            
            /*if (response.StatusCode == 200)
            {

            }
            else 
            {
                lblInfo.Text = "Servidor Indisponível";
            }*/

        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
