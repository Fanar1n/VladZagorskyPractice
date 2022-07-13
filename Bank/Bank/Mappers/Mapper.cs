using AutoMapper;
using Bank.BLL.Models;
using Bank.Models.Client;
using Bank.Models.CreditCard;

namespace Bank.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreditCard, CreditCardViewModel>().ReverseMap();
            CreateMap<Client, ClientViewModel>().ReverseMap();
            CreateMap<CreditCard,AddCreditCardViewModel>().ReverseMap();
            CreateMap<CreditCard, ShortCreditCardViewModel>().ReverseMap();
            CreateMap<Client,ShortClientViewModel>().ReverseMap();
            CreateMap<Client,AddClientViewModel>().ReverseMap();
        }
    }
}
