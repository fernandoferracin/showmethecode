using AutoMapper;
using DesafioTecnico.Business.Models;
using TaxaJuros.API.ViewModel;

namespace TaxaJuros.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Taxa, TaxaViewModel>().ReverseMap();
        }
    }
}