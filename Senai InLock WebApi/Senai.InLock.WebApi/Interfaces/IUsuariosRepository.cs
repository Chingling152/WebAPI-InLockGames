using Senai.InLock.WebApi.Models;

namespace Senai.InLock.WebApi.Interfaces {
    public interface IUsuariosRepository {

        /// <summary>
        /// Valida se existe um usuario com a combinação de Email e Senha inseridos
        /// </summary>
        /// <param name="email">Email do usuario</param>
        /// <param name="senha">Senha do usuario</param>
        /// <returns>Um usuario com todos os dados , se a combinação de email e senha não existir , retorna null </returns>
        UsuariosModel Validar(string email,string senha);

    }
}
