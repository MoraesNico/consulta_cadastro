using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace consulta_cadastro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Form2 OutroForm = new Form2();

                this.Visible = false;

                OutroForm.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string criterio = nomeb.Text.ToString();
            string sqlcomando = "";

            SqlDataReader reg = null;
            if (criterio == "")
            {
                MessageBox.Show("Digite a expressão");
                return;
            }
            else
                sqlcomando = "SELECT * FROM pessoas Where NOME LIKE '" + criterio + "%'";
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350256\Documents\clientes.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = sqlcomando;
                conexao.Open();
                reg = comando.ExecuteReader();
                if (reg.Read())
                {

                    nomeb.Text = reg["NOME"].ToString();
                    cpfb.Text = reg["CPF"].ToString();
                    emailb.Text = reg["EMAIL"].ToString();
                    foneb.Text = reg["FONE"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro na consulta: " + ex.Message);
            }
        }
    }
}
