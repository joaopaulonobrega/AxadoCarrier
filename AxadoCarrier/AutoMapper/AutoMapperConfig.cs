using AutoMapper;
using AxadoCarrier.Domain.Entities.Registers;
using AxadoCarrier.ViewModels;

namespace AxadoCarrier.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
    
}