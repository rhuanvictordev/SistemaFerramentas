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
        private string AppName = ConfigurationManager.AppSettings["AppName"];
        private string AppKeyName = ConfigurationManager.AppSettings["AppKeyName"];
        private string AppVersion = ConfigurationManager.AppSettings["AppVersion"];
        private string ServerUrl = ConfigurationManager.AppSettings["ServerUrl"];

        public Atualizador(HttpClient httpClient)
        {
            InitializeComponent();
            _httpClient = httpClient;
            notificarUI("Consultando Servidor", "Verificando Atualização");
        }

        public void notificarUI(string logMessage, string infoMessage)
        {
            lblLog.Text = !logMessage.Equals(String.Empty) ? $"{logMessage}..." : lblLog.Text;
            lblInfo.Text = !infoMessage.Equals(String.Empty) ? infoMessage : lblInfo.Text;
        }

        private void Atualizador_Load(object sender, EventArgs e)
        {
            lblNomeSistema.Text = $"{AppName}   [ Atualizador ]";
            string versaoRecebida = VerificarVersaoAtual(ServerUrl, AppKeyName);
            if (!versaoRecebida.Equals(String.Empty))
            {
                notificarUI("", "Sucesso!");
            }
            else 
            {
                notificarUI("", "Servidor Indisponível");
            }
        }

        private string VerificarVersaoAtual(string serverUrl, string appName)
        {
            try
            {
                Object requestBody = new { appName = appName };
                string json = JsonConvert.SerializeObject(requestBody);
                //MessageBox.Show(json);

                /*HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(serverUrl, content);*/
                
                return "1.0";

            }
            catch (Exception ex) 
            {
                return String.Empty;
            }
        }

        private void btnExecutar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
