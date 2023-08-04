﻿using FluentAssertions;
using NetworkUtility.Ping;
using Xunit;

namespace NetworkUtility.Tests.PingTests;

public class NetworkServiceTests
{
    [Fact]
    public void NetworkService_SendPing_ReturnString()
    {
        //Arrange - variables, classes, mocks
        var pingService = new NetworkService();

        //Act
        var result = pingService.SendPing();

        //Assert
        result.Should().NotBeNullOrWhiteSpace();
        result.Should().Be("Success: Ping Sent!");
        result.Should().Contain("Success", Exactly.Once());

    }

    [Xunit.Theory]
    [InlineData(1, 1, 2)]
    [InlineData(2, 2, 4)]
    public void NetworkService_PingTimeout_ReturnInt(int a, int b, int excepted)
    {
        //Arrange
        var pingService = new NetworkService();

        //Act
        var result = pingService.PingTimeout(a, b);

        //Assert
        result.Should().Be(excepted);
        result.Should().BeGreaterThanOrEqualTo(2);
        result.Should().NotBeInRange(-10000, 0);

    }
    
} 