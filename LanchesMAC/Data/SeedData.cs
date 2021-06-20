using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMAC.Data
{
    public static class SeedData
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            //Incluir perfis customizados
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            //Define perfis em um array de string
            string[] roleNames = { "Admin", "Member" };
            IdentityResult roleResult;

            //percorre array de strings
            //verifica se o perfil já existe
            foreach (var role in roleNames)
            {
                //Inclui os perfis e salva no banco
                var RoleExist = await RoleManager.RoleExistsAsync(role);
                if (!RoleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(role));
                }

            }

            //Cria um super usuário que pode manter a aplicação web
            var powerUser = new IdentityUser
            {
                //Obtem o nome e email do arquivo de configuração
                UserName = configuration.GetSection("UserSettings")["UserName"],
                Email = configuration.GetSection("UserSettings")["UserEmail"],

            };

            //Obtém a senha do arquivo de configuração
            var Password = configuration.GetSection("UserSettings")["UserPassword"];

            var user = await UserManager.FindByEmailAsync(configuration.GetSection("UserSettings")["UserEmail"]);

            if (user == null)
            {
                //Cria o admin com os dados informados
                var createPowerUser = await UserManager.CreateAsync(powerUser, Password);

                if (createPowerUser.Succeeded)
                {
                    //Caso tenha criado com sucesso, adiciona o usuario como admin
                    await UserManager.AddToRoleAsync(powerUser, "Admin");
                }
            }
        }
    }
}
