using System;
using System.Windows.Forms;
using System.Configuration;

namespace SistemaFerramentas
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            string versao = ConfigurationManager.AppSettings["AppVersion"];
            this.Text = $"Sistema de Ferramentas - Versão {versao}";
        }
    }
}
