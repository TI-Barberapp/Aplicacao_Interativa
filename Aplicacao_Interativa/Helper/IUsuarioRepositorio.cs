using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        List<UsuarioModel> BuscarTodos();
        List<UsuarioModel> BuscarBarbeiros();
        UsuarioModel BuscarPorLogin(string email);
        UsuarioModel RecuperarPeloId(int id);
        UsuarioModel SalvarNovaSenha(UsuarioModel usuario, string novaSenha);
        string BuscarEmailBarbeiroEspecifico(string nome);
        string BuscarNomeUsuarioPeloId(int id);
    }

}
