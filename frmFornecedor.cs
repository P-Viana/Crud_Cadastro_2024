using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjCrudCadastro_PEDRO
{
    public partial class frmFornecedor : Form
    {
        public frmFornecedor()
        {
            InitializeComponent();
        }
        Conexao bd = new Conexao();
        private const string TABELA = "tblFornecedor";


        private void frmFornecedor_Load(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void ExibirDados()
        {
            // Comando SQL para selecionar todos os registros da tabela
            string dados = $"SELECT * FROM {TABELA}";
            // Obtém os dados do banco e exibe na grade de dados
            DataTable dt = bd.ExecutarConsulta(dados);
            dtgFornecedor.DataSource = dt.AsDataView();
        }

        private void LimpaCampos()
        {
            // Limpa os campos do formulário após uma operação de CRUD
            lblID.Text = "";
            txtRazaoSocial.Clear();
            txtNomeFantasia.Clear();
            txtCNPJ.Clear();
            txtRazaoSocial.Focus(); // Move o foco para o campo Nome
        }

        private void dtgFornecedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Cria uma instância de Cliente e preenche com os dados da linha selecionada na grade
            Fornecedor fornecedor = new Fornecedor();
            fornecedor.SetId(Convert.ToInt32(dtgFornecedor.Rows[e.RowIndex].Cells[0].Value));
            fornecedor.SetRazao(dtgFornecedor.Rows[e.RowIndex].Cells[1].Value.ToString());
            fornecedor.SetTelefone(dtgFornecedor.Rows[e.RowIndex].Cells[2].Value.ToString());
            fornecedor.SetCNPJ(dtgFornecedor.Rows[e.RowIndex].Cells[2].Value.ToString());

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Fornecedor cliente = new Fornecedor();
            // Verifica se os campos obrigatórios estão preenchidos
            if (txtRazaoSocial.Text != "" && txtNomeFantasia.Text != "" && txtCNPJ.Text != "")
            {
                // Define os valores do cliente a partir dos campos do formulário
                cliente.SetRazao(txtRazaoSocial.Text);
                cliente.SetTelefone(txtNomeFantasia.Text);
                cliente.SetCNPJ(txtCNPJ.Text);
                // String de inserção SQL usando os dados do cliente
                string inserir = $"INSERT INTO {TABELA} (razao_social, nome_fantasia, cnpj) VALUES('{cliente.GetRazao()}', '{cliente.GetNome()}', '{cliente.GetCNPJ()}')";
                // Executa o comando de inserção no banco de dados
                bd.ExecutarComandos(inserir);
                // Atualiza a exibição dos dados e limpa os campos do formulário
                ExibirDados();
                LimpaCampos();
            }
            else
            {

                // Exibe mensagem caso algum campo esteja vazio
                MessageBox.Show("Informação Inválida!", "Confirmação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ExibirDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Fornecedor cliente = new Fornecedor();

            // Verifica se os campos obrigatórios estão preenchidos e se há um ID válido
            if (txtRazaoSocial.Text != "" && txtNomeFantasia.Text != "" && txtCNPJ.Text !="" && int.TryParse(lblID.Text, out int
            id))
            {
                // Define os valores do cliente a partir dos campos do formulário
                cliente.SetId(id);
                cliente.SetRazao(txtRazaoSocial.Text);
                cliente.SetTelefone(txtNomeFantasia.Text);
                cliente.SetCNPJ(txtCNPJ.Text);
                // String de atualização SQL
                string alterar = $"UPDATE {TABELA} SET razao_social = '{cliente.GetRazao()}', nome_fantasia = '{cliente.GetNome()}', cnpj = '{cliente.GetCNPJ()}' WHERE id = {cliente.GetId()}";
                // Executa o comando de atualização
                int resultado = bd.ExecutarComandos(alterar);
                // Verifica o resultado e atualiza os dados
                if (resultado == 1)
                {
                    MessageBox.Show("Registro atualizado com sucesso!");
                    ExibirDados();
                    LimpaCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar!");
                }
            }
            else
            {
                MessageBox.Show("Informação Inválida!");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            Fornecedor cliente = new Fornecedor();
            // Verifica se há um ID válido para exclusão
            if (int.TryParse(lblID.Text, out int id))
            {
                cliente.SetId(id);
                // String de exclusão SQL
                string excluir = $"DELETE FROM {TABELA} WHERE id = {cliente.GetId()}";
                // Executa o comando de exclusão
                int resultado = bd.ExecutarComandos(excluir);
                // Verifica o resultado e atualiza os dados
                if (resultado == 1)
                {
                    MessageBox.Show("Registro deletado com sucesso!");
                    ExibirDados();
                    LimpaCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir!");
                }
            }
            else
            {
                MessageBox.Show("Informação Inválida!");
            }
        }
    }
}
