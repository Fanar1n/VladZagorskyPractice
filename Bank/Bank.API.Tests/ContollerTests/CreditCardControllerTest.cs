using AutoMapper;
using Bank.API.Tests.Models;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.Controllers;
using Moq;
using Shouldly;
using Xunit;

namespace Bank.API.Tests.ContollerTests
{
    public class CreditCardControllerTest
    {
        private readonly Mock<ICreditCardServices> _creditCardMoqService = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Add_ValidCreditCard_ReturnValidCreditCard()
        {
            //Arrange.
            var validCreditCardViewModel = ValidCreditCardViewModel.CreditCardViewModel;
            var validCreditCardModel = ValidCreditCard.CreditCardModel;

            _mapper.Setup(x => x.Map<CreditCard>(validCreditCardViewModel))
                .Returns(validCreditCardModel);
            _mapper.Setup(x => x.Map<CreditCardViewModel>(validCreditCardModel))
                .Returns(validCreditCardViewModel);
            _creditCardMoqService.Setup(x => x.Create(validCreditCardModel, default))
                .ReturnsAsync(validCreditCardModel);
            //Act.
            var controller = new CreditCardController(_creditCardMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.Create(validCreditCardViewModel, default);

            validCreditCardViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ValidCreditCard_ReturnUpdateCreditCard()
        {
            //Arrange.
            var validCreditCardModel = ValidCreditCard.CreditCardModel;
            var validCreditCardViewModel = ValidCreditCardViewModel.CreditCardViewModel;

            _mapper.Setup(x => x.Map<CreditCard>(validCreditCardViewModel))
                .Returns(validCreditCardModel);
            _mapper.Setup(x => x.Map<CreditCardViewModel>(validCreditCardModel))
                .Returns(validCreditCardViewModel);
            _creditCardMoqService.Setup(x => x.Update(validCreditCardModel, default))
                .ReturnsAsync(validCreditCardModel);
            //Act.
            var controller = new CreditCardController(_creditCardMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.Update(validCreditCardViewModel, default);

            validCreditCardViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Delete_ValidCreditCard()
        {
            //Arrange.
            var validCreditCardViewModel = ValidCreditCardViewModel.CreditCardViewModel;

            _mapper.Setup(x => x.Map<CreditCard>(validCreditCardViewModel));
            _mapper.Setup(x => x.Map<IEnumerable<CreditCard>>(validCreditCardViewModel));
            _creditCardMoqService.Setup(x => x.Delete(validCreditCardViewModel.Id, default));
            //Act.
            var controller = new CreditCardController(_creditCardMoqService.Object, _mapper.Object);
            //Assert.
            Action action = async () => await controller.Delete(validCreditCardViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidCreditCard()
        {
            //Arrange.
            var validCreditCardList = ValidCreditCard.InitListCreditCards;
            var validCreditCardViewList = ValidCreditCardViewModel.InitListCreditCards;

            _mapper.Setup(x => x.Map<IEnumerable<CreditCardViewModel>>(validCreditCardList))
                .Returns(validCreditCardViewList);

            _creditCardMoqService.Setup(x => x.GetAll(default))
                .ReturnsAsync(validCreditCardList);
            //Act.
            var controller = new CreditCardController(_creditCardMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.GetAll(default);

            validCreditCardViewList.ShouldBeEquivalentTo(result);
        }
    }
}