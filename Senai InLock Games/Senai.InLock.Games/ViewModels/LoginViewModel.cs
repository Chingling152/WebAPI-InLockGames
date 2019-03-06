namespace Senai.InLock.Games.ViewModels {
    /// <summary>
    /// Modelo usado apenas para fazer login na API (Evitando de enviar dados inuteis como ID e Tipo Usuario)
    /// </summary>
    public class LoginViewModel {
        /// <summary>
        /// Email do Usuario
        /// </summary>
        public string Email;

        /// <summary>
        /// Senha do Usuario
        /// </summary>
        public string Senha;
    }
}
