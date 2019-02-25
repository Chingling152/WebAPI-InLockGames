using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;
using System;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories {
    public class UsuarioRepository : IUsuarioRepository {
        private const string Conexao = "Data Source=.\\SQLEXPRESS; initial catalog = InLock_Games_Manha;user id = sa; pwd = 132";

        public UsuarioModel Validar(string email, string senha) {

            using(SqlConnection connection = new SqlConnection(Conexao)) {
                string comando = "SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha";
                SqlCommand cmd = new SqlCommand(comando,connection);

                cmd.Parameters.AddWithValue("@Email",email);
                cmd.Parameters.AddWithValue("@Senha",senha);

                SqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.HasRows) {
                    while (leitor.Read()) {
                        return new UsuarioModel() {
                            ID = Convert.ToInt32(leitor["ID"]),
                            Email = leitor["Email"].ToString(),
                            Senha = leitor["Senha"].ToString(),
                            TipoUsuario = leitor["TipoUsuario"].ToString(),
                        };
                    }
                }
            }
            return null;
        }
    }
}
