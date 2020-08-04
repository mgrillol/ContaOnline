using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using Newtonsoft.Json;

namespace WindowsExemploClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
            ExibirDados();
        }

        private async void ExibirDados()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:44332/api/contaservice"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resultadoString = await response.Content.ReadAsStringAsync();
                        var lista = JsonConvert.DeserializeObject<ContaListItem[]>(resultadoString).ToList();
                        dataGridView1.DataSource = lista;
                    }
                }
            }
        }
    }
}
