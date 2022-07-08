using AutoMapper;
using Bank.BLL.Models;
using Bank.DAL.Entities;

namespace Bank.BLL.AMapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreditCard, CreditCardEntity>().ReverseMap();
            CreateMap<Client, ClientEntity>().ReverseMap();
        }
    }
}
