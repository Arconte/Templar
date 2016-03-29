using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Templar.Domain.Entities;
using Templar.Domain.Values;

namespace Templar.SqlServer.Repository.Configuration
{
    public class MapperConfiguration
    {
        public void Configure(IMapperConfiguration MapperConfiguration)
        {
            MapperConfiguration.CreateMap<Model.Clue, ClueEntity>();
            MapperConfiguration.CreateMap<ClueEntity, Model.Clue>();
        }
    }
}
