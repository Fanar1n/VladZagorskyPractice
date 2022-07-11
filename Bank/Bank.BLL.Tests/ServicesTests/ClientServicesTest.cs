using AutoMapper;
using Bank.BLL.Models;
using Bank.BLL.Services;
using Bank.BLL.Tests.Entities;
using Bank.BLL.Tests.Models;
using Bank.DAL.Entities;
using Bank.DAL.Interfaces;
using Moq;
using Shouldly;
using Xunit;

namespace Bank.BLL.Tests.ServicesTests
{
    public class ClientServicesTest
    {
        private readonly Mock<IClientRepository> _clientMoqRepository = new();
        private readonly Mock<IMapper> _mapper = new();

        [Fact]
        public async Task Add_ValidClient_ReturnValidClient()
        {
            //Arrange.
            var validClient = ValidClient.Client;
            var validClientEntity = ValidClientEntity.ClientEntity;

            _mapper.Setup(x => x.Map<Client>(validClientEntity))
                .Returns(validClient);
            _mapper.Setup(x => x.Map<ClientEntity>(validClient))
                .Returns(validClientEntity);
            _clientMoqRepository.Setup(x => x.Create(validClientEntity, default))
                .ReturnsAsync(validClientEntity);
            //Act.
            var service = new ClientService(_clientMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.Create(validClient, default);

            validClient.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Update_ValidClient_ReturnUpdateClient()
        {
            //Arrange.
            var validClient = ValidClient.Client;
            var validClientEntity = ValidClientEntity.ClientEntity;

            _mapper.Setup(x => x.Map<Client>(validClientEntity))
                .Returns(validClient);
            _mapper.Setup(x => x.Map<ClientEntity>(validClient))
                .Returns(validClientEntity);
            _clientMoqRepository.Setup(x => x.Update(validClientEntity, default))
                .ReturnsAsync(validClientEntity);
            _clientMoqRepository.Setup(x => x.Get(validClient.Id, default))
                .ReturnsAsync(validClientEntity);
            //Act.
            var service = new ClientService(_clientMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.Update(validClient, default);

            validClient.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task Delete_ValidClient()
        {
            //Arrange.
            var validClient = ValidClient.Client;

            _mapper.Setup(x => x.Map<ClientEntity>(validClient));
            _clientMoqRepository.Setup(x => x.Delete(validClient.Id, default));
            //Act.
            var service = new ClientService(_clientMoqRepository.Object, _mapper.Object);
            //Assert.
            Action action = async () => await service.Delete(validClient.Id, default);

            action.ShouldNotThrow();
        }

        [Fact]
        public async Task Get_WhenHasData_ReturnValidClient()
        {
            //Arrange.
            var validClient = ValidClient.Client;
            var validClientEntity = ValidClientEntity.ClientEntity;

            _mapper.Setup(x => x.Map<Client>(validClientEntity))
                .Returns(validClient);
            _mapper.Setup(x => x.Map<ClientEntity>(validClient))
                .Returns(validClientEntity);
            _clientMoqRepository.Setup(x => x.Get(validClientEntity.Id, default))
                .ReturnsAsync(validClientEntity);
            //Act.
            var service = new ClientService(_clientMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.Get(validClient.Id, default);

            validClient.ShouldBeEquivalentTo(result);
        }

        [Fact]
        public async Task GetAll_WhenHasData_ReturnValidCreditCard()
        {
            //Arrange.
            var validClient = ValidClient.InitListClient;
            var validClientEntity = ValidClientEntity.InitListClientEntity;

            _mapper.Setup(x => x.Map<IEnumerable<Client>>(validClientEntity))
                .Returns(validClient);
            _clientMoqRepository.Setup(x => x.GetAll(default))
                .ReturnsAsync(validClientEntity);
            //Act.
            var service = new ClientService(_clientMoqRepository.Object, _mapper.Object);
            //Assert.
            var result = await service.GetAll(default);

            validClient.ShouldBeEquivalentTo(result);
        }
    }
}
