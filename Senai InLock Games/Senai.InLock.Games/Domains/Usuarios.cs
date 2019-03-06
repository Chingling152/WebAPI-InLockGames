namespace Senai.InLock.Games.Domains
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public short TipoUsuario { get; set; }
    }
}
