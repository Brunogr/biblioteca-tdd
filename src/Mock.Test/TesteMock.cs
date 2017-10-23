using Mock.Exemplo;
using Moq;
using System;
using Xunit;

namespace Mock.Test
{
    public class TesteMock
    {
        private IUsuarioService _usuarioService;
        public TesteMock()
        {

        }

        [Fact]
        public void TesteGetUsuario()
        {
            //Mockando o repositório e adicionando comportamento
            var repository = new Mock<IUsuarioRepository>();
            
            repository.Setup(mockRepository => 
                    mockRepository.Get(It.IsAny<Guid>()))
                .Returns((Guid id) => 
                    new Usuario() { Id = id }
                );

            _usuarioService = new UsuarioService(repository.Object);

            var guid = Guid.NewGuid();

            Assert.Equal(guid, _usuarioService.RetornarUsuario(guid).Id);
        }
    }
}
