using Aplicacao_Interativa.Data;
using Aplicacao_Interativa.Helper;
using Aplicacao_Interativa.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Aplicacao_Interativa
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();



            builder.Services.AddDbContext<BancoContext>
                (options => options.UseMySql(
                    "server=dbadsappinterativa.mysql.database.azure.com;initial catalog=BD_AplicacaoInterativa;uid=barberuseradmin;pwd=ads@1234",
                    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.36-mysql")));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IAgendamentoRepositorio, AgendamentoRepositorio>();
            builder.Services.AddScoped<IEmail, Email>();
            builder.Services.AddScoped<ITokenCacheService, TokenCacheService>();
            builder.Services.AddScoped<ISessao, Sessao>();
            builder.Services.AddSession(o => {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseBrowserLink();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}