using AutoMapper;
using Entities.DTO;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryMS
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Book, BookDto>();
            CreateMap<CategoryCreateDto,Category>();
            CreateMap<BookCreateDto,Book>();
            CreateMap<RentRequestCreateDto,RentRequest>();
            CreateMap<RentRequestDto, RentRequest>();
            CreateMap<RentRequestUpdateDto, RentRequest>();
            CreateMap<RentRequest, RentRequestDto>();
            CreateMap<RentRequest, RentRequestUpdateDto>();
            CreateMap<PlanCreateDto, Plan>();
            CreateMap<Plan,PlanDto>();
            CreateMap<BookDateDto, BookDate>();
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<UserProfileEditDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserPlanValidityDto, UserPlanValidity>();
        }

    }
}
