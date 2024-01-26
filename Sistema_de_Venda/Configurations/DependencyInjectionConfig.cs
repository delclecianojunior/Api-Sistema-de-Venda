using Business.Interfaces;
using Business.Notificacoes;
using Business.Services;
using Data.Context;
using Data.Repository;

namespace Sistema_de_Venda.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Contexto>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
            services.AddScoped<IComissaoRepository, ComissaoRepository>();

            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IVendedorService, VendedorService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IItemVendaService, ItemVendaService>();
            services.AddScoped<IComissaoService, ComissaoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
