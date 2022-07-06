using AutoMapper;
using Bank.BLL.Models;
using Bank.Models;

namespace Bank.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreditCardViewModel, CreditCard>().ReverseMap();
        }
    }
}
