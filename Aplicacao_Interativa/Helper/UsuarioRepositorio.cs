﻿using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Enums;
using Aplicacao_Interativa.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplicacao_Interativa.Helper
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();

            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = RecuperarPeloId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um problema na atualização do perfil.");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Celular = usuario.Celular;

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }
        public bool Apagar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = RecuperarPeloId(usuario.Id);

            if (usuarioDB == null) throw new Exception("Houve um problema na deleção do perfil.");

            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }
        public List<UsuarioModel> BuscarBarbeiros()
        {
            return _bancoContext.Usuarios.Where(u => u.Perfil == PerfilEnum.Barbeiro).ToList();
        }

        public UsuarioModel BuscarPorLogin(string email)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
        }

        public UsuarioModel RecuperarPeloId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public UsuarioModel SalvarNovaSenha(UsuarioModel usuario, string novaSenha)
        {
            usuario.Senha = novaSenha;

            usuario.SetGerarHash();

            _bancoContext.SaveChanges();

            return usuario;
        }

        public string CriptografarSenha(UsuarioModel usuario, string senha)
        {
            usuario.Senha = senha;
            usuario.SetGerarHash();

            return usuario.Senha;
        }

        public string BuscarEmailBarbeiroEspecifico(string nome)
        {
            List<UsuarioModel> listaBarbeiro = BuscarBarbeiros();

            foreach (UsuarioModel barbeiros in listaBarbeiro)
            {
                if(barbeiros.Nome == nome)
                {
                    return barbeiros.Email;
                }
            }
            return "agendamentobarber@outlook.com";
        }
        public string BuscarNomeUsuarioPeloId(int id)
        {
            List<UsuarioModel> listaUsuarios = BuscarTodos();

            foreach (UsuarioModel usuario in listaUsuarios)
            {
                if(usuario.Id == id)
                {
                    return usuario.Nome;
                }
            }
            return "None";
        }
    }
}
