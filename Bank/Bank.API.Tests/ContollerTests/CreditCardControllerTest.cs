using AutoMapper;
using Bank.API.Tests.Models;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.Controllers;
using Bank.Models.CreditCard;
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
            var addValidCreditCardViewModel = ValidCreditCardViewModel.AddCreditCardViewModel;
            var validCreditCardModel = ValidCreditCard.CreditCardModel;
            var shortValidCreditCardViewModel = ValidCreditCardViewModel.ShortCreditCardViewModel;

            _mapper.Setup(x => x.Map<CreditCard>(addValidCreditCardViewModel))
                .Returns(validCreditCardModel);
            _mapper.Setup(x => x.Map<ShortCreditCardViewModel>(validCreditCardModel))
                .Returns(shortValidCreditCardViewModel);
            _creditCardMoqService.Setup(x => x.Create(validCreditCardModel, default))
                .ReturnsAsync(validCreditCardModel);
            //Act.
            var controller = new CreditCardController(_creditCardMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.Create(addValidCreditCardViewModel, default);

            shortValidCreditCardViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ValidCreditCard_ReturnUpdateCreditCard()
        {
            //Arrange.
            var updateValidCreditCardViewModel = ValidCreditCardViewModel.UpdateCreditCardViewModel;
            var validCreditCardModel = ValidCreditCard.CreditCardModel;
            var shortValidCreditCardViewModel = ValidCreditCardViewModel.ShortCreditCardViewModel;

            _mapper.Setup(x => x.Map<CreditCard>(updateValidCreditCardViewModel))
                .Returns(validCreditCardModel);
            _mapper.Setup(x => x.Map<ShortCreditCardViewModel>(validCreditCardModel))
                .Returns(shortValidCreditCardViewModel);
            _creditCardMoqService.Setup(x => x.Update(validCreditCardModel, default))
                .ReturnsAsync(validCreditCardModel);
            //Act.
            var controller = new CreditCardController(_creditCardMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.Update(updateValidCreditCardViewModel, default);

            shortValidCreditCardViewModel.ShouldBeEquivalentTo(result);
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