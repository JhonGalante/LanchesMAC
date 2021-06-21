using LanchesMAC.Areas.Admin.Servicos;
using LanchesMAC.Context;
using LanchesMAC.Models;
using LanchesMAC.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMAC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Definição do contexto e a passagem da string de conexão do arquivo de configuração
            services.AddDbContext<AppDbContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Home/AccessDenied");

            services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

            //Definição dos repositórios da aplicação como serviços para permitir a injeção de dependencia
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
            services.AddTransient<ILancheRepository, LancheRepository>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            services.AddScoped<RelatorioVendasService>();

            //Serviço para obter o contexto da aplicação (criado um único serviço para toda a aplicação)
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Serviço para obter o carrinho de compras do usuário (criado um serviço diferente para cada requisição feita)
            services.AddScoped(cp => CarrinhoCompra.GetCarrinho(cp));

            services.AddControllersWithViews();

            //Configura a utilização da páginação
            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap4";
                options.PageParameterName = "pageindex";
            });

            //Configura o uso da sessão
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "categoriaFiltro",
                    pattern: "Lanche/{action}/{categoria?}",
                    defaults: new { Controller = "Lanche", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
