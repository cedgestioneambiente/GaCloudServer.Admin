using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.Shared;

namespace GaCloudServer.BusinessLogic.Mappers.Preventivi
{
    internal class CreDebMapperProfile : Profile
    {
        public CreDebMapperProfile()
        {

            //CreDeb

            CreateMap<CreDebCanaleDto, CreDebCanale>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CreDebCanaleDto>, PageResponse<CreDebCanale>>(MemberList.Destination).ReverseMap();

            CreateMap<CreDebContoDto, CreDebConto>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CreDebContoDto>, PageResponse<CreDebConto>>(MemberList.Destination).ReverseMap();

            CreateMap<CreDebIncassiInObjectDto, CreDebIncassiInObject>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CreDebIncassiInObjectDto>, PageResponse<CreDebIncassiInObject>>(MemberList.Destination).ReverseMap();

            CreateMap<CreDebIncassiInObjectDetailDto, CreDebIncassiInObjectDetail>(MemberList.Destination)
                .ForMember(dest => dest.Task, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<PageResponse<CreDebIncassiInObjectDetailDto>, PageResponse<CreDebIncassiInObjectDetail>>(MemberList.Destination).ReverseMap();

            

           
        }
    }
}

