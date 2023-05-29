using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitPro.Database;

namespace FitPro
{
    internal class Ficha
    {
        private int id;
        private int idAluno;
        private DateTime data;
        private float peso;
        private float peito;
        private float cintura;
        private float bracoL;
        private float bracoR;
        private float pernaL;
        private float pernaR;
        private string comentarios;
        private Query SQL;

        public Ficha()
        {
            clear();
        }
        public Ficha(int ID)
        {
            carregar(ID);
        }

        private void clear()
        {
            id = -1;
            data = DateTime.Today;
            idAluno = -1;
            peso = 0;
            peito = 0;
            cintura = 0;
            bracoL = 0;
            bracoR = 0;
            pernaL = 0;
            pernaR = 0;
            comentarios = "";
            SQL = new Query();
        }

        private void carregar(int ID)
        {
            List<Dictionary<string, object>> dados = SQL.ReadWhere("ficha", $"ID={ID}");
            id = int.Parse(dados.FirstOrDefault()["ID"].ToString());
            data = DateTime.Parse(dados.FirstOrDefault()["data"].ToString());
            idAluno = int.Parse(dados.FirstOrDefault()["id_aluno"].ToString());
            peso = float.Parse(dados.FirstOrDefault()["peso"].ToString());
            peito = float.Parse(dados.FirstOrDefault()["medida_peito"].ToString());
            cintura = float.Parse(dados.FirstOrDefault()["medida_barriga"].ToString());
            bracoL = float.Parse(dados.FirstOrDefault()["medida_braco_esquerdo"].ToString());
            bracoR = float.Parse(dados.FirstOrDefault()["medida_braco_direito"].ToString());
            pernaL = float.Parse(dados.FirstOrDefault()["medida_perna_esquerdo"].ToString());
            pernaR = float.Parse(dados.FirstOrDefault()["medida_perna_direito"].ToString());
            comentarios = dados.FirstOrDefault()["comentarios"].ToString();
        }
        public void salvar()
        {
            if (id < 0)
            {
                List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("data", data),
                    ("id_aluno", idAluno),
                    ("peso", peso),
                    ("medida_barriga", cintura),
                    ("medida_peito", peito),
                    ("medida_braco_direito", bracoR),
                    ("medida_braco_esquerdo", bracoL),
                    ("medida_perna_direito", pernaR),
                    ("medida_perna_esquerdo", pernaL),
                    ("comentarios", comentarios)
                };
                SQL.Insert("ficha", dados);
                id = ultimoId();
            }
            else
            {
                List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("data", data),
                    ("peso", peso),
                    ("medida_barriga", cintura),
                    ("medida_peito", peito),
                    ("medida_braco_direito", bracoR),
                    ("medida_braco_esquerdo", bracoL),
                    ("medida_perna_direito", pernaR),
                    ("medida_perna_esquerdo", pernaL),
                    ("comentarios", comentarios)
                };
                SQL.Update("ficha", dados, $"ID={id}");
            }
        }
        public void delete()
        {
            if(id!=-1) SQL.Delete("ficha", $"ID={id}");
            if (idAluno != -1)
            {
                Aluno aluno = new Aluno();
                aluno.removeFicha(id);
                aluno.salvar();
                aluno = null;
            }
            clear();
        }
        public void delete(bool x)
        {
            if (id != -1) SQL.Delete("ficha", $"ID={id}");            
            clear();
        }

        private int ultimoId()
        {
            int maior = 0;
            List<Dictionary<string, object>> fichas = SQL.Read("ficha");
            for (int i = 0; i < fichas.Count; i++)
            {
                if (int.Parse(fichas[i]["ID"].ToString()) > maior) maior = int.Parse(fichas[i]["ID"].ToString());
            }
            return maior;
        }

        public int getId()
        {
            return id;
        }

        public DateTime getData()
        {
            return data;
        }

        public void setPeso(float Peso)
        {
            peso = Peso;
        }
        public float getPeso()
        {
            return peso;
        }

        public void setPeito(float Peito)
        {
            peito = Peito;
        }
        public float getPeito()
        {
            return peito;
        }

        public void setCintura(float Cintura)
        {
            cintura = Cintura;
        }
        public float getCintura()
        {
            return cintura;
        }

        public void setBracoL(float BracoL)
        {
            bracoL = BracoL;
        }
        public float getBracoL()
        {
            return bracoL;
        }

        public void setBracoR(float BracoR)
        {
            bracoR = BracoR;
        }
        public float getBracoR()
        {
            return bracoR;
        }

        public void setPernaL(float PernaL)
        {
            pernaL = PernaL;
        }
        public float getPernaL()
        {
            return pernaL;
        }

        public void setPernaR(float PernaR)
        {
            pernaR = PernaR;
        }
        public float getPernaR()
        {
            return pernaR;
        }

        public void setComentarios(string Comentarios)
        {
            comentarios = Comentarios;
        }
        public string getComentarios()
        {
            return comentarios;
        }

    }
}
