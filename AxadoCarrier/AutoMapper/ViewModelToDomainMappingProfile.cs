using AutoMapper;
using AxadoCarrier.Domain.Entities.Registers;
using AxadoCarrier.ViewModels;

namespace AxadoCarrier.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
       
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappings";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Carrier, CarrierViewModel>();
            Mapper.CreateMap<Rating, RatingViewModel>();
        }
    }
}