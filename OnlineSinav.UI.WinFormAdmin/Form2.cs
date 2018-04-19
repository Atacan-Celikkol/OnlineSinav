using OnlineSinav.UI.WinFormAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineSinav.UI.WinFormAdmin
{
    public partial class Form2 : Form
    {
        HttpClient _client;

        public Form2(HttpClient client)
        {
            _client = client;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            HttpResponseMessage response = _client.GetAsync("Lesson", HttpCompletionOption.ResponseContentRead).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Lesson> list = response.Content.ReadAsAsync<List<Lesson>>().Result;
                cmbLessons.DisplayMember = "Name";
                cmbLessons.ValueMember = "LessonID";
                cmbLessons.DataSource = list;

                response = _client.GetAsync("Category", HttpCompletionOption.ResponseContentRead).Result;
                if (response.IsSuccessStatusCode)
                {
                    List<Category> cList = response.Content.ReadAsAsync<List<Category>>().Result;
                    cmbCategories.DisplayMember = "Name";
                    cmbCategories.ValueMember = "CategoryID";
                    cmbCategories.DataSource = cList;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Exam exam = new Exam()
            {
                CategoryID = (int)cmbCategories.SelectedValue,
                Date = dateTimePicker1.Value,
                Duration = (uint)txtDuration.Value,
                IsActive = true,
                LessonID = (int)cmbLessons.SelectedValue,
                Name = txtExamName.Text
            };

            HttpResponseMessage response = _client.PostAsJsonAsync("Exam", exam).Result;
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Sınav başarıyla eklendi");
                this.Close();
            }
        }
    }
}
