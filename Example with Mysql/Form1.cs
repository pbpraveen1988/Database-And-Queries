using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseAndQueries;
using Example.Models;
namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataSource = Queries.GetAllData<User>();
            dataGridView1.AutoGenerateColumns = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User _user = new User();
            _user.Name = textBox1.Text;
            Queries.Add<User>(_user);
            dataGridView1.DataSource = Queries.GetAllData<User>();
            dataGridView1.AutoGenerateColumns = true;
        }
    }
}
