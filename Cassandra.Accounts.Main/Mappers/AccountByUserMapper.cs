using AutoMapper;
using Cassandra.Accounts.Common.Model.Cassandra;
using Cassandra.Accounts.Common.Model.Transactional;

namespace Cassandra.Accounts.Main.Mappers
{
    /// <summary>
    ///     Automapper profile to map Account to AccountByUser
    /// </summary>
    public sealed class AccountByUserMapper : Profile
    {
        public AccountByUserMapper()
        {
            CreateMap<Account, AccountByUser>()
                .ForMember(dest => dest.AccountNumber, opt => opt.MapFrom(src => src.AccountNumber))
                .ForMember(dest => dest.CashBalance, opt => opt.MapFrom(src => src.CashBalance))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username));
        }
    }
}
