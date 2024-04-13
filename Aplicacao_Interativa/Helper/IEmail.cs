using Aplicacao_Interativa.Models;

namespace Aplicacao_Interativa.Helper
{
    public interface IEmail
    {
        bool Enviar(string email, string assunto, string mensagem);
    }
}
