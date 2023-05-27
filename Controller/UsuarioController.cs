using FitPro.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitPro.Controller
{
    public class UsuarioController
    {
        private Query query;

        public UsuarioController()
        {
            query = new Query();
        }

        public void CadastrarUsuario(string nome, string email, string senha)
        {
            string senhacriptografada = BCrypt.Net.BCrypt.HashPassword(senha);

            List<(string column, object value)> values = new List<(string column, object value)>
            {
                ("nome", nome),
                ("email", email),
                ("senha", senhacriptografada)
            };

            query.Insert("usuario", values);
        }

        public List<Dictionary<string, object>> GetUsuarios()
        {
            return query.Read("usuario");
        }

        public Dictionary<string, object> GetUsuarioAsID(int id)
        {
            string condition = $"ID = {id}";
            List<Dictionary<string, object>> results = query.ReadWhere("usuario", condition);
            return results.FirstOrDefault();
        }

        public void DeleteUser(int id)
        {
            string condition = $"ID = {id}";
            query.Delete("usuario", condition);
        }

        public void UpdateUser(int id, string nome, string email, string senha)
        {
            string condition = $"ID = {id}";
            string senhacriptografada = BCrypt.Net.BCrypt.HashPassword(senha);

            List<(string column, object value)> values = new List<(string column,object value)>
            {
                ("nome", nome),
                ("email", email),
                ("senha", senhacriptografada)
            };

            query.Update("usuario", values, condition);
        }
    }
}
