﻿using AutoMapper;
using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Common.Model.Transactional;

namespace Cassandra.Accounts.Main.Mappers
{
    /// <summary>
    ///     Automapper profile to map Trade to TradesByAccount
    /// </summary>
    public sealed class TradesByAccountMapper : Profile
    {
        public TradesByAccountMapper()
        {
            CreateMap<Trade, TradesByAccount>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.AccountNumber))
                .ForMember(dest => dest.TradeDate, opt => opt.MapFrom(src => Cassandra.TimeUuid.NewId(new DateTimeOffset(src.Date))))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.InstrumentSymbol))
                .ForMember(dest => dest.Shares, opt => opt.MapFrom(src => src.Shares))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}
