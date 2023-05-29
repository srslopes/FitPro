using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitPro.Database;
using MySqlX.XDevAPI;

namespace FitPro
{
    internal class Aluno
    {
        public int id;
        private string nome;
        private int telefone;
        private DateTime nascimento;
        private float altura;
        private int ultima;
        private List<int> fichas;
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
            ultima = -1;
            fichas = new List<int>();
            SQL = new Query();
        }

        private void carregar(int ID)
        {
            List<Dictionary<string, object>> dados = SQL.ReadWhere("aluno", $"ID={ID}");
            id = int.Parse(dados.FirstOrDefault()["ID"].ToString());
            nome = dados.FirstOrDefault()["nome"].ToString();
            telefone = int.Parse(dados.FirstOrDefault()["telefone"].ToString());
            nascimento = DateTime.Parse(dados.FirstOrDefault()["data_nascimento"].ToString());
            altura = float.Parse(dados.FirstOrDefault()["altura"].ToString());
            ultima = int.Parse(dados.FirstOrDefault()["id_ultima_ficha"].ToString());
            fichas = string2list(dados.FirstOrDefault()["ids_fichas"].ToString());
            fichas.Sort();
        }
        public void salvar()
        {
            fichas.Sort();
            if (id<0)
            {
                List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("nome", nome),
                    ("telefone", telefone),
                    ("data_nascimento", nascimento),
                    ("altura", altura),
                    ("id_ultima_ficha", ultima),
                    ("ids_fichas", list2string(fichas))
                };
                SQL.Insert("aluno", dados);
                id = ultimoId();
            }
            else
            {
                List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("nome", nome),
                    ("telefone", telefone),
                    ("data_nascimento", nascimento),
                    ("altura", altura),
                    ("id_ultima_ficha", ultima),
                    ("ids_fichas", list2string(fichas))
                };
                SQL.Update("aluno", dados, $"ID={id}");
            }
        }
        public void delete()
        {
            if (id != -1)
            {
                SQL.Delete("aluno", $"ID={id}");
                for (int i = 0; i< fichas.Count; i++)
                {
                    Ficha ficha = new Ficha(fichas[i]);
                    ficha.delete(true);
                    ficha = null;
                }
            }
            clear();
        }

        private int ultimoId()
        {
            int maior = 0;
            List<Dictionary<string, object>> alunos = SQL.Read("aluno");
            for(int i = 0; i<alunos.Count; i++)
            {
                if (int.Parse(alunos[i]["ID"].ToString()) > maior) maior = int.Parse(alunos[i]["ID"].ToString());
            }
            return maior;
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

        public void setUltima(int Ultima)
        {
            ultima = Ultima;
        }
        public int getUltima()
        {
            return ultima;
        }

        public void setFichas(List<int> Fichas)
        {
            fichas = Fichas;
            fichas.Sort();
        }
        public List<int> getFichas()
        {
            fichas.Sort();
            return fichas;
        }
        public void addFicha(int ID)
        {
            if(!fichas.Contains(ID)) fichas.Add(ID);
            fichas.Sort();
            ultima = ID;
        }
        public void removeFicha(int ID)
        {
            if (fichas.Contains(ID))
            {
                fichas.Sort();
                if (ID == ultima)
                {
                    if (fichas.Count == 0)
                    {
                        ultima = -1;
                        return;
                    }
                    ultima = fichas[fichas.Count - 1];
                }
                fichas.Remove(ID);
            }
            
        }
        private string list2string(List<int> Lista)
        {
            string str = "";
            if(Lista.Count==0)return str;
            if(Lista.Count==1)return Lista[0].ToString();
            for (int i = 0; i < Lista.Count; i++)
            {
                str += Lista[i].ToString();
                if(i!= Lista.Count-1) str += ".";
            }
            return str;
        }
        private List<int> string2list(string str)
        {
            List<int> Lista = new List<int>();
            if(str=="") return Lista;
            if(!str.Contains('.'))
            {
                Lista.Add(int.Parse(str));
                return Lista;
            }
            List<string> strings = str.Split('.').ToList<string>();            
            for (int i = 0; i < strings.Count; i++)
            {
                Lista.Add(int.Parse(strings[i]));
            }
            return Lista;
        }

    }
}
