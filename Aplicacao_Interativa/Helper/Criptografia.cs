﻿using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Aplicacao_Interativa.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encoding = new ASCIIEncoding();
            var array = encoding.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var item in array)
            {
                strHexa.Append(item.ToString("x2"));
            }

            return strHexa.ToString();
        }

        public static string CriptografarSenha(string senha)
        {
            string senhaCriptografada = GerarHash(senha);

            return senhaCriptografada;

        }
    }
}
