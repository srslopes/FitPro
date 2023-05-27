using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitPro.Database;

namespace FitPro
{
    internal class Aluno
    {
        public int id;
        private string nome;
        private int telefone;
        private DateTime nascimento;
        private float altura;
        private Ficha ultima;
        private List<Ficha> fichas;
        private Query SQL;


        public Aluno()
        {
            id = -1;
            nome = "";
            nascimento = DateTime.MinValue;
            fichas = new List<Ficha>();
            SQL = new Query();
        }

        public void carregar(int ID)
        {
            List<Dictionary<string, object>> query = SQL.Read("aluno");
        }
        public void salvar()
        {
            if(id<0)
            {
               //id = SQL.Insert("aluno");
            }
            else
            {
                //List<Dictionary<string, object>> query = new List<Dictionary<string, object>>();
                //SQL.Update("aluno", query , "ID=" +id);
            }
        }
        public void delete()
        {
            if (id != -1) SQL.Delete("aluno", "ID="+id);
        }

        public int getId()
        {
            return id;
        }

        public void setNome(string Nome)
        {
            nome = Nome;
        }
        public string getNome() 
        {
            return nome;
        }

        public void setTelefone(int Telefone)
        {
            telefone = Telefone;
        }
        public int getTelefone() 
        {
            return telefone;
        }

        public void setNascimento(DateTime Nascimento)
        {
            nascimento = Nascimento;
        }
        public DateTime getNascimento()
        {
            return nascimento;
        }

        public void setAltura(float Altura)
        {
            altura = Altura;
        }
        public float getAltura()
        {
            return altura;
        }

        public void setUltima(Ficha Ultima)
        {
            ultima = Ultima;
        }
        public Ficha getUltima()
        {
            return ultima;
        }

        public void setFichas(List<Ficha> Fichas)
        {
            fichas = Fichas;
        }
        public List<Ficha> getFichas()
        {
            return fichas;
        }

    }
}
