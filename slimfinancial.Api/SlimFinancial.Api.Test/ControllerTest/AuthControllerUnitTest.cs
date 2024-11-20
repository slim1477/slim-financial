

using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SlimFinancial.Api.Controllers;
using SlimFinancial.Api.UnitTest.Fixtures;
using SlimFinancial.Application.Service;
using SlimFinancial.Domain.Dtos;

namespace SlimFinancial.Api.UnitTest;

    public class AuthControllerUnitTest
    {
       [Fact]
       public async Task Login_OnSuccess_ReturnStatusCode200()
        {
            var mockLoginRequest = AuthenticationFixture.GetLoginRequest();
            //Arrange
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(serice => serice.Login(It.IsAny<LoginRequestDto>()))
                          .ReturnsAsync(new LoginResponseDto { Message = "success"});
            var mockAuthController = new AuthController(mockAuthService.Object);
            //Act
            var result = (OkObjectResult) await mockAuthController.Login(mockLoginRequest);
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Login_OnFailure_ReturnStatusCode401()
        {
            var mockLoginRequest = AuthenticationFixture.GetLoginRequest();
            //Arrange
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(serice => serice.Login(mockLoginRequest))
                          .ReturnsAsync(new LoginResponseDto { Message = "not authorized" });
            var mockAuthController = new AuthController(mockAuthService.Object);
            //Act
            var result = (UnauthorizedObjectResult)await mockAuthController.Login(mockLoginRequest);
            //Assert
            result.StatusCode.Should().Be(401);

        }


        [Fact]
        public async Task Login_OnFailure_ReturnStatusCode400()
        {
            var mockLoginRequest = AuthenticationFixture.GetLoginRequest();
            //Arrange
            var mockAuthService = new Mock<IAuthService>();
            mockAuthService.Setup(serice => serice.Login(mockLoginRequest))
                          .ReturnsAsync(new LoginResponseDto());
            var mockAuthController = new AuthController(mockAuthService.Object);
            //Act
            var result = (BadRequestObjectResult)await mockAuthController.Login(mockLoginRequest);
            //Assert
            result.StatusCode.Should().Be(400);

        }
        [Fact]
        public async Task Register_OnSucess_ReturnStatusCode200()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockRegisterRequest = It.IsAny<RegisterRequestDto>();
            mockAuthService.Setup(service => service.Register(mockRegisterRequest))
                            .ReturnsAsync(new RegisterResponseDto { Message = "Created"});
            var mockAuthController = new AuthController (mockAuthService.Object);
            // Act
            var result = (OkObjectResult) await mockAuthController.Register(mockRegisterRequest);
            // Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Register_WithEmailExists_ReturnStatusCode409()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockRegisterRequest = It.IsAny<RegisterRequestDto>();
            mockAuthService.Setup(service => service.Register(mockRegisterRequest))
                            .ReturnsAsync(new RegisterResponseDto { Message = "Email already exists" });
            var mockAuthController = new AuthController(mockAuthService.Object);
            // Act
            var result = (ConflictObjectResult)await mockAuthController.Register(mockRegisterRequest);
            // Assert
            result.StatusCode.Should().Be(409);
        }

        [Fact]
        public async Task Register_OnFail_ReturnStatusCode400()
        {
            // Arrange
            var mockAuthService = new Mock<IAuthService>();
            var mockRegisterRequest = It.IsAny<RegisterRequestDto>();
            mockAuthService.Setup(service => service.Register(mockRegisterRequest))
                            .ReturnsAsync(new RegisterResponseDto());
            var mockAuthController = new AuthController(mockAuthService.Object);
            // Act
            var result = await mockAuthController.Register(mockRegisterRequest);
            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

}

