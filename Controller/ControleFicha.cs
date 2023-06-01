using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPro.Controller
{
    class ControleFicha
    {
        public ControleFicha()
        {

        }

        public static Ficha carregar(int ID)
        {
            Ficha ficha = new Ficha(ID);
            return ficha;
        }

        public static Ficha carregar()
        {
            Ficha ficha = new Ficha();
            return ficha;
        }

        public static void salvar(Ficha ficha)
        {
            ficha.salvar();
        }

        public static void deletar(Ficha ficha)
        {
            ficha.deletar();
        }
    }
}
