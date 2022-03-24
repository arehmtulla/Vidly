using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //customer
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();

            //movie
            Mapper.CreateMap<Movie, MovieDTO>();
            Mapper.CreateMap<MovieDTO, Movie>();

            //membership type
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            //genre
            Mapper.CreateMap<Genre, GenreDTO>();
        }
    }
}