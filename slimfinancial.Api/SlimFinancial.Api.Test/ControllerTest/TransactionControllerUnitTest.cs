using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SlimFinancial.Api.Controllers;
using SlimFinancial.Api.UnitTest.Fixtures;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.UnitTest;

public class TransactionControllerUnitTest
    {
        [Fact]
        public async Task GetAllTransactions_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockTransactionService = new Mock<ITransactionService>();
            mockTransactionService.Setup(service => service.GetAllTransactions())
                                  .ReturnsAsync(new List<TransactionDto>());
            var mockTransactionController = new TransactionController(mockTransactionService.Object);
            //Action
            var result = (OkObjectResult) await mockTransactionController.GetAllTransactionsasync();
             //Assert
            result.StatusCode.Should().Be(200);
        }
           [Fact]
           public async Task GetTransactionByAccountNumber_OnSuccess_ReturnStatusCode200()
           {
                //Arrange
                var mockTransactionService = new Mock<ITransactionService>();
                mockTransactionService.Setup(service => service.GetTransactionByAccountNumber(TransactionFixture.GetTransactionByAccount()))
                                      .ReturnsAsync(new List<TransactionDto>());
                var mockTransactionController = new TransactionController(mockTransactionService.Object);
                //Act
                var result = (OkObjectResult) await mockTransactionController.GetTransactionsByAccountNumberAsync(TransactionFixture.GetTransactionByAccount());
                //Assert
                result.StatusCode.Should().Be(200);
            }
           [Fact]
           public async Task CreateTransaction_OnSuccess_ReturnStatusCode200()
            {
            //Arrange
            var mockTransactionService = new Mock<ITransactionService>();
            var transactionRequest = TransactionFixture.CreateTransaction();
            var transactionResponse = new TransactionResDto { Status = true };
            mockTransactionService.Setup(service => service.CreateTransactionAsync(It.IsAny<TransactionReqDto>()))
                                  .ReturnsAsync(transactionResponse);
            var mockTransactionController = new TransactionController(mockTransactionService.Object);
            //Act
            var result = (OkObjectResult) await mockTransactionController.CreateTransaction(TransactionFixture.CreateTransaction());
            //Assert
            result.StatusCode.Should().Be(200);
            }
           
         
    }

