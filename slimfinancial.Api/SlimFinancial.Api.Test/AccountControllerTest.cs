using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SlimFinancial.Api.Controllers;
using SlimFinancial.Api.UnitTest.Fixtures;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;


namespace SlimFinancial.Api.Test;

public class AccountControllerTest
    {
        [Fact]
        public async Task AccountOpening_OnSucess_ReturnStatusCode200()
        {
        //Arrange
        var mockAccountService = new Mock<IAccountService>();
        mockAccountService.Setup(service => service.OpenAccount(AccountFixture.AccountOpenSuccess()))
                          .ReturnsAsync(new ReqResponseDto());
        var accountController = new AccountController(mockAccountService.Object);
        // Act
        var result = (OkObjectResult) await accountController.OpenAccount(AccountFixture.AccountOpenSuccess());
        // Assert
        Console.WriteLine(result.ToString());
        result.StatusCode.Should().Be(200);
    }

        [Fact]
        public async Task AccountOpening_IsNotSuccessfull_RetunsStatusCode422() 
        {
        //Arrange
        var mockAccountService = new Mock<IAccountService>();
        mockAccountService.Setup(service => service.OpenAccount(AccountFixture.AccountOpenFail()))
                          .ReturnsAsync(new ReqResponseDto());
        var accountController = new AccountController(mockAccountService.Object);
        // Act
        var result = (UnprocessableEntityObjectResult) await accountController.OpenAccount(AccountFixture.AccountOpenFail());
        // Assert
        result.Should().BeOfType<UnprocessableEntityObjectResult>();
    }
        [Fact]
        public async Task AccountClosed_OnSuccessfull_ReturnsStatusCode200() 
        {
            //Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.CloseAccount("111122544"))
                            .ReturnsAsync(new ReqResponseDto());
            var accountController = new AccountController(mockAccountService.Object);
            // Act
            var result = (OkObjectResult) await accountController.CloseAccount("111122544");
            // Assert
            result.StatusCode.Should().Be(200);
    }
        [Fact]
        public async Task AccountClosed_IsNotSuccessfull_ReturnsStatusCode422() 
        {
            //Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.CloseAccount(""))
                          .ReturnsAsync(new ReqResponseDto());
            var accountController = new AccountController(mockAccountService.Object);
            // Act
            var result = (UnprocessableEntityObjectResult)await accountController.CloseAccount("");
            // Assert
            result.Should().BeOfType<UnprocessableEntityObjectResult>();
        }
        [Fact]
        public async Task GetAllAccounts_OnSuccessStatusCode200() 
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.GetAllAccounts())
            .ReturnsAsync(new List<AccountDto>());
            var accountController = new AccountController(mockAccountService.Object);
            //Act
            var result = (OkObjectResult) await accountController.GetAllAccounts();
             // Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetAllAccounts_InvokeService()
        {
            // Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.GetAllAccounts())
            .ReturnsAsync(new List<AccountDto>());
            var accountController = new AccountController(mockAccountService.Object);
            //Act
            var result = (OkObjectResult)await accountController.GetAllAccounts();
            // Assert
            mockAccountService.Verify(service => service.GetAllAccounts(),Times.Once);

        }

        // Move to account service test
        [Fact]
        public async Task GetAllAccountService_Returns_ListOfAccounts()
        {
            //Arrange
            var mockAccountService = new Mock<IAccountService>();
            mockAccountService.Setup(service => service.GetAllAccounts())
          .ReturnsAsync(new List<AccountDto>());
        var accountController = new AccountController(mockAccountService.Object);
        //Act
        var result = (OkObjectResult) await accountController.GetAllAccounts();
        //Assert
        result.Value.Should().BeOfType<List<AccountDto>>();
    }
    }
