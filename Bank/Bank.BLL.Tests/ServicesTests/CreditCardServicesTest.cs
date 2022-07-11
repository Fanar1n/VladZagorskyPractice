using AutoMapper;
using Bank.BLL.Models;
using Bank.BLL.Services;
using Bank.BLL.Tests.Entity;
using Bank.BLL.Tests.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;
using Moq;
using Shouldly;
using Xunit;

namespace Bank.BLL.Tests.ServicesTests
{
    public class CreditCardServicesTest
    {
        private readonly Mock<ICreditCardRepository> _creditCardMoqRepository = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Add_ValidCreditCard_ReturnValidCreditCard()
        {
            //Arrange.
            var validCreditCard = ValidCreditCard.CreditCard;
            var validCreditCardEntity = ValidCreditCardEntity.CreditCardEntity;

            _mapper.Setup(x => x.Map<CreditCard>(validCreditCardEntity))
                .Returns(validCreditCard);
            _mapper.Setup(x => x.Map<CreditCardEntity>(validCreditCard))
                .Returns(validCreditCardEntity);
            _creditCardMoqRepository.Setup(x => x.Create(validCreditCardEntity, default))
                .ReturnsAsync(validCreditCardEntity);
            //Act.
            var service = new CreditCardService(_creditCardMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.Create(validCreditCard, default);

            validCreditCard.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ValidCreditCard_ReturnUpdateCreditCard()
        {
            //Arrange.
            var validCreditCard = ValidCreditCard.CreditCard;
            var validCreditCardEntity = ValidCreditCardEntity.CreditCardEntity;

            _mapper.Setup(x => x.Map<CreditCard>(validCreditCardEntity))
                .Returns(validCreditCard);
            _mapper.Setup(x => x.Map<CreditCardEntity>(validCreditCard))
                .Returns(validCreditCardEntity);
            _creditCardMoqRepository.Setup(x => x.Update(validCreditCardEntity, default))
                .ReturnsAsync(validCreditCardEntity);
            _creditCardMoqRepository.Setup(x => x.Get(validCreditCard.Id, default))
                .ReturnsAsync(validCreditCardEntity);
            //Act.
            var service = new CreditCardService(_creditCardMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.Update(validCreditCard, default);

            validCreditCard.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Delete_ValidCreditCard()
        {
            //Arrange.
            var validCreditCard = ValidCreditCard.CreditCard;

            _mapper.Setup(x => x.Map<CreditCardEntity>(validCreditCard));
            _creditCardMoqRepository.Setup(x => x.Delete(validCreditCard.Id, default));
            //Act.
            var service = new CreditCardService(_creditCardMoqRepository.Object, _mapper.Object);
            //Assert.
            Action action = async () => await service.Delete(validCreditCard.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public async Task Get_WhenHasData_ReturnValidCreditCard()
        {
            //Arrange.
            var validCreditCard = ValidCreditCard.CreditCard;
            var validCreditCardEntity = ValidCreditCardEntity.CreditCardEntity;

            _mapper.Setup(x => x.Map<CreditCard>(validCreditCardEntity))
                .Returns(validCreditCard);
            _mapper.Setup(x => x.Map<CreditCardEntity>(validCreditCard))
                .Returns(validCreditCardEntity);
            _creditCardMoqRepository.Setup(x => x.Get(validCreditCardEntity.Id, default))
                .ReturnsAsync(validCreditCardEntity);
            //Act.
            var service = new CreditCardService(_creditCardMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.Get(validCreditCard.Id, default);
            
            validCreditCard.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidCreditCard()
        {
            //Arrange.
            var validCreditCard = ValidCreditCard.CreditCardList;
            var validCreditCardEntity = ValidCreditCardEntity.CreditCardEntityList;

            _mapper.Setup(x => x.Map<IEnumerable<CreditCard>>(validCreditCardEntity))
                .Returns(validCreditCard);
            _creditCardMoqRepository.Setup(x => x.GetAll(default))
                .ReturnsAsync(validCreditCardEntity);
            //Act.
            var service = new CreditCardService(_creditCardMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.GetAll(default);

            validCreditCard.ShouldBeEquivalentTo(result);
        }
    }
}
