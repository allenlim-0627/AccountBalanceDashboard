using AccountBalance.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountBalance.Profile
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<AccountModel, AccountExcelDTO>().ReverseMap();
                config.CreateMap<AccountModel, AccountDTO>().ReverseMap();
            });
        }
    }
}