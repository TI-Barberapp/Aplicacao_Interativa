using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuario);

        List<UsuarioModel> BuscarTodos();
        List<UsuarioModel> BuscarBarbeiros();
    }

}
