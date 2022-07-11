using AutoMapper;
using Bank.API.Tests.Models;
using Bank.API.Tests.ViewModels;
using Bank.BLL.Interfaces;
using Bank.BLL.Models;
using Bank.Controllers;
using Bank.Models;
using Moq;
using Shouldly;
using Xunit;

namespace Bank.API.Tests.ContollerTests
{
    public class ClientControllerTest
    {
        private readonly Mock<IClientService> _clientMoqService = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Add_ValidClient_ReturnValidClient()
        {
            //Arrange.
            var validClientViewModel = ValidClientViewModel.ClientViewModel;
            var validClientModel = ValidClient.ClientModel;

            _mapper.Setup(x => x.Map<Client>(validClientViewModel))
                .Returns(validClientModel);
            _mapper.Setup(x => x.Map<ClientViewModel>(validClientModel))
                .Returns(validClientViewModel);
            _clientMoqService.Setup(x => x.Create(validClientModel, default))
                .ReturnsAsync(validClientModel);
            //Act.
            var controller = new ClientController(_clientMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.Create(validClientViewModel, default);

            validClientViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ValidClient_ReturnUpdateClient()
        {
            //Arrange.
            var validClientModel = ValidClient.ClientModel;
            var validClientViewModel = ValidClientViewModel.ClientViewModel;

            _mapper.Setup(x => x.Map<Client>(validClientViewModel))
                .Returns(validClientModel);
            _mapper.Setup(x => x.Map<ClientViewModel>(validClientModel))
                .Returns(validClientViewModel);
            _clientMoqService.Setup(x => x.Update(validClientModel, default))
                .ReturnsAsync(validClientModel);
            //Act.
            var controller = new ClientController(_clientMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.Update(validClientViewModel, default);

            validClientViewModel.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Delete_ValidClient()
        {
            //Arrange.
            var validClientViewModel = ValidClientViewModel.ClientViewModel;

            _mapper.Setup(x => x.Map<Client>(validClientViewModel));
            _mapper.Setup(x => x.Map<IEnumerable<Client>>(validClientViewModel));
            _clientMoqService.Setup(x => x.Delete(validClientViewModel.Id, default));
            //Act.
            var controller = new ClientController(_clientMoqService.Object, _mapper.Object);
            //Assert.
            Action action = async () => await controller.Delete(validClientViewModel.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidClient()
        {
            //Arrange.
            var validClientList = ValidClient.InitListClient;
            var validClientViewList = ValidClientViewModel.InitListClient;

            _mapper.Setup(x => x.Map<IEnumerable<ClientViewModel>>(validClientList))
                .Returns(validClientViewList);
            _clientMoqService.Setup(x => x.GetAll(default))
                .ReturnsAsync(validClientList);
            //Act.
            var controller = new ClientController(_clientMoqService.Object, _mapper.Object);
            //Assert.
            var result = await controller.GetAll(default);

            validClientViewList.ShouldBeEquivalentTo(result);
        }
    }
}
