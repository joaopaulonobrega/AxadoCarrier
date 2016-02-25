using AxadoCarrier.Domain.Entities.Registers;
using AxadoCarrier.ViewModels;
using AutoMapper;

namespace AxadoCarrier.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<CarrierViewModel, Carrier>();
            Mapper.CreateMap<RatingViewModel, Rating>();
        }
    }
}