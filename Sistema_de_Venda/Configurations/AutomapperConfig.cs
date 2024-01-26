using AutoMapper;
using Business.Models;
using Sistema_de_Venda.ViewModel;
using static System.Net.Mime.MediaTypeNames;

namespace Sistema_de_Venda.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
            CreateMap<Vendedor, VendedorViewModel>().ReverseMap();
            CreateMap<ItemVenda, ItemVendaViewModel>().ReverseMap();
            CreateMap<Venda, VendaViewModel>()
            .ForMember(dest => dest.ItensVenda, opt => opt.MapFrom(src => src.ItensVenda))
            .ReverseMap();
            CreateMap<Comissao, ComissaoViewModel>().ReverseMap();
        }

        private static byte[] GetBytesFromFormFile(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
