using System.Collections.Generic;
using Senai.InLock.Games.Domains;

namespace Senai.InLock.Games.Interfaces {
    public interface IUsuariosRepository {

        /// <summary>
        /// Mostra todos os usuarios cadastrados no banco de dados
        /// </summary>
        /// <returns></returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Retorna um usuario com a c
        /// </summary>
        /// <returns></returns>
        Usuarios ListarPorID(int ID);

        void Cadastrar(Usuarios usuario);

        void Alterar(Usuarios usuario);

        Usuarios Logar(string Email,string Senha);
    }
}