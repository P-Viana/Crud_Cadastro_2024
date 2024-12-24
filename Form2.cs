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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void cadsatroDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente f = new frmCliente();
            f.Show();
        }

        private void cadstroDeFornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedor f = new frmFornecedor();
            f.Show();
        }
    }
}
