using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;
using Web.ViewModels;

namespace Web.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Drug, DrugViewModel>();
            CreateMap<DrugViewModel, Drug>();
            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();


            //CreateMap<IEnumerable<Drug>, IEnumerable<DrugViewModel>>();
            //CreateMap<IEnumerable<DrugViewModel>, IEnumerable<Drug>>();
            //CreateMap<IEnumerable<Company>, IEnumerable<CompanyViewModel>>();
            //CreateMap<IEnumerable<CompanyViewModel>, IEnumerable<Company>>();
        }
    }
}
