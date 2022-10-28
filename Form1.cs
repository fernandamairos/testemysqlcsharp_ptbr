using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Cadastro_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = "server=localhost; database=cadastro; user id=root; password=pastel; port=3306;";
                con.Open();

                string sql = "INSERT INTO pessoa_fisica (nome_completo, nascimento, celular) VALUES (@nome_completo, @nascimento, @celular)";

                MySqlCommand c = new MySqlCommand(sql, con);

                c.Parameters.Add(new MySqlParameter("@nome_completo", this.txtnome.Text));
                c.Parameters.Add(new MySqlParameter("@nascimento", this.txtnascimento.Text));
                c.Parameters.Add(new MySqlParameter("@celular", this.txtcelular.Text));

                c.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Ok!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
