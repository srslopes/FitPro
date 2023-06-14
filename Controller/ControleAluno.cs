using FitPro.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlX.XDevAPI;
using FitPro;

namespace FitPro.Controller
{
    class ControleAluno
    {

        public ControleAluno()
        {

        }

        public static Aluno carregar(int ID)
        {
            Query SQL = new Query();
            List<Dictionary<string, object>> alunos = SQL.Read("aluno");
            int i;
            for (i = 0; i < alunos.Count; i++)
            {
                if (int.Parse(alunos[i]["ID"].ToString()) == ID) break;
            }
            if (i == alunos.Count) return null;
            Aluno aluno = new Aluno();
            aluno.setId(int.Parse(alunos[i]["ID"].ToString()));
            aluno.setNome(alunos[i]["nome"].ToString());
            aluno.setTelefone(int.Parse(alunos[i]["telefone"].ToString()));
            aluno.setNascimento(DateTime.Parse(alunos[i]["data_nascimento"].ToString()));
            aluno.setAltura(float.Parse(alunos[i]["altura"].ToString()));
            aluno.setFichas(aluno.string2list(alunos[i]["IDs_fichas"].ToString()));
            aluno.getFichas().Sort();
            SQL = null;
            return aluno;
        }

        public static void salvar(Aluno aluno)
        {
            Query SQL = new Query();
            aluno.getFichas().Sort();
            List<(string column, object value)> dados = new List<(string column, object value)>
            {
                    ("nome", aluno.getNome()),
                    ("telefone", aluno.getTelefone()),
                    ("data_nascimento", aluno.getNascimento().ToString()),
                    ("altura", aluno.getAltura()),
                    ("IDs_fichas", aluno.list2string(aluno.getFichas()))
            };

            if (aluno.getId() < 0)
            {                
                SQL.Insert("aluno", dados);
                aluno.setId(aluno.ultimoId());
            }
            else
            {
                SQL.Update("aluno", dados, $"ID={aluno.getId()}");
            }
        }

        public static void deletar(Aluno aluno)
        {
            Query SQL = new Query();
            if (aluno.getId() != -1)
            {                
                while (aluno.getFichas().Count>1)
                {
                    aluno = ControleAluno.carregar(aluno.getId());
                    Ficha ficha = ControleFicha.carregar(aluno.getFichas()[0]);
                    ControleFicha.deletar(ficha);
                }
                SQL.Delete("aluno", $"ID={aluno.getId()}");
            }
            aluno.clear();
        }
        public static List<Aluno> Listar()
        {            
            List<Aluno> lista = new List<Aluno>();
            Query SQL = new Query();
            List<Dictionary<string, object>> alunos = SQL.Read("aluno");
            for (int i = 0; i < alunos.Count; i++)
            {
                Aluno aluno = new Aluno();
                aluno.setId(int.Parse(alunos[i]["ID"].ToString()));
                aluno.setNome(alunos[i]["nome"].ToString());
                aluno.setTelefone(int.Parse(alunos[i]["telefone"].ToString()));
                aluno.setNascimento(DateTime.Parse(alunos[i]["data_nascimento"].ToString()));
                aluno.setAltura(float.Parse(alunos[i]["altura"].ToString()));
                aluno.setFichas(aluno.string2list(alunos[i]["IDs_fichas"].ToString()));
                aluno.getFichas().Sort();
                lista.Add(aluno);
            }
            return lista;
        }
    }
}
