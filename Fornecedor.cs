using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjCrudCadastro_PEDRO
{
    internal class Fornecedor
    {
        private int id;
        private string razao_social;
        private string nome_fantasia;
        private string cnpj;
        public int GetId()
        {
            return id;
        }
        public void SetId(int id)
        {
            this.id = id;
        }

        public string GetRazao()
        {
            return razao_social;
        }
        public void SetRazao(string razao)
        {
            this.razao_social = razao;
        }
        public string GetNome()
        {
            return nome_fantasia;
        }
        public void SetTelefone(string fantasia)
        {
            this.nome_fantasia = fantasia;
        }
        public string GetCNPJ()
        {
            return cnpj;
        }
        public void SetCNPJ(string CNPJ)
        {
            this.cnpj = CNPJ;
        }
    }
}
