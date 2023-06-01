using AutoMapper;
using sportLife2.DbModel;

namespace sportLife2.DTOs
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Pitch, PitchCreateDTO>().ReverseMap();
            CreateMap<PitchCreateDTO, Pitch>().ReverseMap();
            CreateMap<Pitch, PitchUpdateDTO>().ReverseMap();
            CreateMap<Pitch, TypePitchDTO>().ReverseMap();
            CreateMap<Rezervation, RezervationCreateDTO>().ReverseMap();
            CreateMap<RezervationCreateDTO, Rezervation>().ReverseMap();
            CreateMap<TypePitchDTO, Pitch>().ReverseMap();
            CreateMap<RezervationListDTO, Rezervation>().ReverseMap();
            CreateMap<Rezervation, RezervationListDTO>().ReverseMap();
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<UserUpdateDTO, UserEntity>().ReverseMap();


        }
    }

}
