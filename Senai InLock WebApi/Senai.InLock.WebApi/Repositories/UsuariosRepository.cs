using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;
using System;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories {
    public class UsuariosRepository : IUsuariosRepository {

        private const string Conexao = "Data Source=.\\SQLEXPRESS; initial catalog = InLock_Games_Manha;user id = sa; pwd = 132";

        /// <summary>
        /// Retorna um usuario que tenha a combinação de Email e Senha
        /// </summary>
        /// <param name="email">Email do usuario que será procurado</param>
        /// <param name="senha">Senha do usuario que será procurado</param>
        /// <returns>Um usuario no banco de dados que tenha a combinação de Email e Senha</returns>
        public UsuariosModel Validar(string email, string senha) {

            using(SqlConnection connection = new SqlConnection(Conexao)) {
                connection.Open();

                string comando = "SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha";
                SqlCommand cmd = new SqlCommand(comando,connection);

                cmd.Parameters.AddWithValue("@Email",email);
                cmd.Parameters.AddWithValue("@Senha",senha);

                SqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.HasRows) {
                    while (leitor.Read()) {
                        return new UsuariosModel() {
                            ID = Convert.ToInt32(leitor["UsuarioId"]),
                            Email = leitor["Email"].ToString(),
                            Senha = leitor["Senha"].ToString(),
                            TipoUsuario = leitor["TipoUsuario"].ToString(),
                        };
                    }
                }
            }
            throw new Exception("Senha ou Email incorretos");
        }

    }
}
