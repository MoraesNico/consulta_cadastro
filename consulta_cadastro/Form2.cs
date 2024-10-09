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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace consulta_cadastro
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 OutroForm = new Form1();

            this.Visible = false;

            OutroForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexao = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\20231350256\Documents\clientes.mdf;Integrated Security=True;Connect Timeout=30");
                SqlCommand comando = new SqlCommand();
                comando.Connection = conexao;
                comando.CommandText = "INSERT INTO pessoas (cpf,nome,email,fone) values (@cpf,@nome,@email,@fone)";
                comando.Parameters.AddWithValue("@cpf", cpfb.Text);
                comando.Parameters.AddWithValue("@nome", nomeb.Text);
                comando.Parameters.AddWithValue("@email", emailb.Text);
                comando.Parameters.AddWithValue("@fone", foneb.Text);
                conexao.Open();
                comando.ExecuteNonQuery();
                conexao.Close();
                MessageBox.Show("Registro Inserido com Sucesso!");
                cpfb.Text = nomeb.Text = emailb.Text = foneb.Text = "";
                cpfb.Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao Incluir!==> " + erro.Message);
            }
        }
    }
}
