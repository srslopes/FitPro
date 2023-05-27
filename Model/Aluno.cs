using System;
using System.Collections;
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
        public Query SQL;


        public Aluno()
        {
            clear();
        }
        public Aluno(int ID)
        {
            carregar(ID);
        }

        private void clear()
        {
            id = -1;
            nome = "";
            telefone = 0;
            nascimento = DateTime.MinValue;
            fichas = new List<Ficha>();
            SQL = new Query();
        }

        private void carregar(int ID)
        {
            List<Dictionary<string, object>> dados = SQL.ReadWhere("aluno", "ID="+ID);
        }
        public void salvar()
        {
            if(id<0)
            {
                List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("nome", nome),
                    ("telefone", telefone),
                    ("data_nascimento", nascimento),
                    ("altura", altura),
                    ("id_ultima_ficha", ultima.getId()),
                    ("ids_fichas", list2string(fichas))
                };
                SQL.Insert("aluno", dados);
            }
            else
            {
                List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("nome", nome),
                    ("telefone", telefone),
                    ("data_nascimento", nascimento),
                    ("altura", altura),
                    ("id_ultima_ficha", ultima.getId()),
                    ("ids_fichas", list2string(fichas))
                };
                SQL.Update("aluno", dados, $"ID = {id}");
            }
        }
        public void delete()
        {
            if (id != -1) SQL.Delete("aluno", $"ID={id}");
            clear();
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

        private string list2string(List<Ficha> Lista)
        {
            string str = "";
            return str;
        }
        private List<Ficha> string2list(string str)
        {
            List<Ficha> Lista = new List<Ficha>();
            return Lista;
        }

    }
}
