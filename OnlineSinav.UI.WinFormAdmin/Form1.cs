using OnlineSinav.UI.WinFormAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineSinav.UI.WinFormAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        HttpClient client;
        HttpResponseMessage response;
        List<Exam> list;

        private void btnGetExams_Click(object sender, EventArgs e)
        {
            GetExams();
        }

        void GetExams()
        {
            response = client.GetAsync("Exam", HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                list = response.Content.ReadAsAsync<List<Exam>>().Result;
                dataGridView1.DataSource = list;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3268/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void btnAddExam_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(client);
            frm.ShowDialog();
            GetExams();
        }
    }
}
