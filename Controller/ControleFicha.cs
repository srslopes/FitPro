using FitPro.Database;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FitPro.Controller
{
    class ControleFicha
    {
        public ControleFicha()
        {

        }

        public static Ficha carregar(int ID)
        {
            Query SQL = new Query();
            List<Dictionary<string, object>> fichas = SQL.Read("ficha");
            int i;
            for (i = 0; i < fichas.Count; i++)
            {
                if (int.Parse(fichas[i]["ID"].ToString()) == ID) break;
            }
            //if (i == fichas.Count) return null;
            Ficha ficha = new Ficha();
            ficha.setId(int.Parse(fichas[i]["ID"].ToString()));
            ficha.setData(DateTime.Parse(fichas[i]["data"].ToString()));
            ficha.setIdAluno(int.Parse(fichas[i]["ID_aluno"].ToString()));
            ficha.setPeso(float.Parse(fichas[i]["peso"].ToString()));
            ficha.setPeito(float.Parse(fichas[i]["medida_peito"].ToString()));
            ficha.setCintura(float.Parse(fichas[i]["medida_barriga"].ToString()));
            ficha.setBracoL(float.Parse(fichas[i]["medida_braco_esquerdo"].ToString()));
            ficha.setBracoR(float.Parse(fichas[i]["medida_braco_direito"].ToString()));
            ficha.setPernaL(float.Parse(fichas[i]["medida_perna_esquerda"].ToString()));
            ficha.setPernaR(float.Parse(fichas[i]["medida_perna_direita"].ToString()));
            ficha.setComentarios(fichas[i]["comentarios"].ToString());
            SQL = null;
            return ficha;
        }

        public static void salvar(Ficha ficha, Aluno aluno = null)
        {
            Query SQL = new Query();
            if (aluno != null) ficha.setIdAluno(aluno.getId());
            List<(string column, object value)> dados = new List<(string column, object value)>
                {
                    ("data", ficha.getData().ToString()),
                    ("id_aluno", ficha.getIdAluno()),
                    ("peso", ficha.getPeso()),
                    ("medida_barriga", ficha.getCintura()),
                    ("medida_peito", ficha.getPeito()),
                    ("medida_braco_direito", ficha.getBracoR()),
                    ("medida_braco_esquerdo", ficha.getBracoL()),
                    ("medida_perna_direita", ficha.getPernaR()),
                    ("medida_perna_esquerda", ficha.getPernaL()),
                    ("comentarios", ficha.getComentarios())
                };
            if (ficha.getId()<0)
            {
                SQL.Insert("ficha", dados);                
                ficha.setId(ficha.ultimoId());
                aluno = ControleAluno.carregar(ficha.getIdAluno());
                aluno.addFicha(ficha.getId());
                ControleAluno.salvar(aluno);
            }
            else
            {
                SQL.Update("ficha", dados, $"ID={ficha.getId()}");
            }
            SQL = null;
        }

        public static void deletar(Ficha ficha)
        {
            Query SQL = new Query();
            if (ficha.getId() != -1) SQL.Delete("ficha", $"ID={ficha.getId()}");
            if (ficha.getIdAluno() != -1)
            {
                Aluno aluno = ControleAluno.carregar(ficha.getIdAluno());
                aluno.removeFicha(ficha.getId());
                ControleAluno.salvar(aluno);
            }
            ficha.clear();
        }
    }
}
