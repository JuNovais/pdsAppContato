using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Lógica interna para CadastrarContato.xaml
    /// </summary>
    public partial class CadastrarContato : Window

        
    {
        private MySqlConnection conexao;

        private MySqlCommand comando;
        public CadastrarContato()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
            conexao = new MySqlConnection(conexaoString);
            comando = conexao.CreateCommand();

            conexao.Open();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                


                
                {
                    var nome = tbNome.Text;
                    var email = tbEmail.Text;
                    var datanasc = dateDataNasc.Value;
                    var telefone = tbTelefone.Text;
                    var sexo = tbSexo.Text;
                    

                    


                    string query = "INSERT INTO contato_con (nome_con, email_con, data_nasc_con, sexo_con, telefone_con) VALUES (@_nome, @_email, @_datanasc, @_sexo, @_telefone)";
                    var comando = new MySqlCommand(query, conexao);

                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.Parameters.AddWithValue("@_datanasc", datanasc);
                    comando.ExecuteNonQuery();

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Salvo com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro do sistema");
            }
        }

        
    }
}
