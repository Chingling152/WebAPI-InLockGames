using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;

namespace Senai.InLock.WebApi.Repositories {
    public class JogosRepository : IJogosRepository {

        private const string Conexao = "Data Source=.\\SQLEXPRESS; initial catalog = InLock_Games_Manha;user id = sa; pwd = 132";

        /// <summary>
        /// Cadastra um Jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Jogo que será cadastrado</param>
        public void Cadastrar(JogoModel jogo) {
            using (SqlConnection connection = new SqlConnection(Conexao)) {
                string comando = "INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,EstudioId,Valor) VALUES (@NomeJogo , @Descricao , @DataLancamento , @EstudioId , @Valor)";
                connection.Open();

                SqlCommand cmd = new SqlCommand(comando, connection);

                cmd.Parameters.AddWithValue("@NomeJogo",jogo.NomeJogo);
                cmd.Parameters.AddWithValue("@Descricao",jogo.Descricao);
                cmd.Parameters.AddWithValue("@DataLancamento",jogo.DataLancamento);
                cmd.Parameters.AddWithValue("@EstudioId",jogo.EstudioId);
                cmd.Parameters.AddWithValue("@Valor",jogo.Valor);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Lista todos os jogos e suas respectivas empresas
        /// </summary>
        /// <returns>Uma lista com todos os jogos</returns>
        public List<JogoModel> Listar() {

            using(SqlConnection connection = new SqlConnection(Conexao)) {
                string comando = "SELECT Jogos.* , Estudios.* FROM Jogos LEFT JOIN Estudios ON Estudios.EstudioId = Jogos.EstudioId; ";

                connection.Open();
                SqlCommand cmd = new SqlCommand(comando,connection);

                SqlDataReader leitor = cmd.ExecuteReader();

                if (leitor.HasRows) {
                    List<JogoModel> jogos = new List<JogoModel>();
                    while (leitor.Read()) {
                        jogos.Add(
                            new JogoModel() {
                                /* Dados do jogo */
                                JogoId = Convert.ToInt32(leitor["JogoId"]),
                                NomeJogo = leitor["NomeJogo"].ToString(),
                                Descricao = leitor["Descricao"].ToString(),
                                DataLancamento = Convert.ToDateTime(leitor["DataLancamento"]),
                                Valor = Convert.ToDouble(leitor["Valor"]),
                                EstudioId = Convert.ToInt32(leitor["EstudioId"]),

                                /* Dados do estudio*/
                                Estudio = new EstudioModel() {
                                    EstudioId = Convert.ToInt32(leitor["EstudioId"]),
                                    NomeEstudio = leitor["NomeEstudio"].ToString()
                                }

                            }  
                        );
                    }
                    return jogos;
                }
                
            }
            
            throw new Exception("Não existem jogos no banco de dados");
        }
    }
}
