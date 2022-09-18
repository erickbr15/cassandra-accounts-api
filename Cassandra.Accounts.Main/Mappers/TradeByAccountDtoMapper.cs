using AutoMapper;
using Cassandra.Accounts.Common.Model.Cassandra;

namespace Cassandra.Accounts.Main.Mappers
{
    /// <summary>
    ///     Automapper profile to map ITradesByAccount to TradeByAccountDto
    /// </summary>
    public class TradeByAccountDtoMapper : Profile
    {
        public TradeByAccountDtoMapper()
        {
            CreateMap<ITradesByAccount, TradeByAccountDto>()
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                .ForMember(dest => dest.TradeDate, opt => opt.MapFrom(src=> src.TradeDate.GetDate().DateTime))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Symbol, opt => opt.MapFrom(src => src.Symbol))
                .ForMember(dest => dest.Shares, opt => opt.MapFrom(src => src.Shares))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));            
        }
    }
}