using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using AutoMapper;
using Dal;
using Dto.models;

namespace DTO.Classes
{
    public class MyDBDProfile : Profile
    {
        public MyDBDProfile()
        {
            CreateMap<Dal.Models.Settlement, Settlements>().ReverseMap();
        }
    }
}
