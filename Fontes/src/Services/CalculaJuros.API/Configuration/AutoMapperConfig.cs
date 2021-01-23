using AutoMapper;
using CalculaJuros.API.ViewModel;
using DesafioTecnico.Business.Models;

namespace CalculaJuros.API.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Juros, JurosViewModel>()
                 .ForMember(dest => dest.ValorTaxaJuros, opt => opt.MapFrom(src => src.Taxa.ValorTaxa)).ReverseMap();
        }
    }
}
