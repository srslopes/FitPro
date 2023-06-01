using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPro.Controller
{
    class ControleAluno
    {
        public ControleAluno()
        {

        }

        public static Aluno carregar(int ID)
        {
            Aluno aluno = new Aluno(ID);
            return aluno;
        }

        public static Aluno carregar()
        {
            Aluno aluno = new Aluno();
            return aluno;
        }

        public static void salvar(Aluno aluno)
        {
            aluno.salvar();
        }

        public static void deletar(Aluno aluno)
        {
            aluno.deletar();
        }
    }
}
