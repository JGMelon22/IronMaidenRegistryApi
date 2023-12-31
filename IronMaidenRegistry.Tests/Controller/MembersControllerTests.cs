using FakeItEasy;
using FluentAssertions;
using IronMaidenRegistry.Controllers;
using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Member;
using IronMaidenRegistry.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IronMaidenRegistry.Tests.Controller;

public class MembersControllerTests
{
    private readonly MembersController _membersController;
    private readonly IMemberRepository _memberRepository;

    public MembersControllerTests()
    {
        _memberRepository = A.Fake<IMemberRepository>();

        // SUT
        _membersController = new MembersController(_memberRepository);
    }

    [Fact]
    public void MembersController_GetAllMembersAsync_ReturnsMembers()
    {
        // Arrange
        var members = A.Fake<ServiceResponse<List<MemberResult>>>();
        A.CallTo(() => _memberRepository.GetAllMembersAsync()).Returns(members);

        // Act
        var result = _membersController.GetAllMembersAsync();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }
}