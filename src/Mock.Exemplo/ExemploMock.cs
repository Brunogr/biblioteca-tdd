using System;

namespace Mock.Exemplo
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Usuario RetornarUsuario(Guid id)
        {
            return _usuarioRepository.Get(id);
        }
    }

    public interface IUsuarioService
    {
        Usuario RetornarUsuario(Guid id);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuario Get(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUsuarioRepository
    {
        Usuario Get(Guid id);
    }

    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
