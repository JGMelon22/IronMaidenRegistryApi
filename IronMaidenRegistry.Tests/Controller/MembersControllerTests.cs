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

    [Fact]
    public void MembersController_GetMemberByIdAsync_ReturnsMembers()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var member = A.Fake<ServiceResponse<MemberResult>>();
        A.CallTo(() => _memberRepository.GetMemberByIdAsync(id)).Returns(member);

        // Act
        var result = _membersController.GetMemberByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void MembersController_AddMemberAsync_ReturnsMembers()
    {
        // Arrange 
        var newMember = A.Fake<MemberInput>();
        var memberResult = A.Fake<ServiceResponse<MemberResult>>();
        A.CallTo(() => _memberRepository.AddMemberAsync(newMember)).Returns(memberResult);

        // Act
        var result = _membersController.AddMemberAsync(newMember);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void MembersController_UpdateMemberAsync_ReturnsMembers()
    {
        // Arrange 
        Guid id = Guid.NewGuid();
        var updatedMember = A.Fake<MemberInput>();
        var memberResult = A.Fake<ServiceResponse<MemberResult>>();
        A.CallTo(() => _memberRepository.AddMemberAsync(updatedMember)).Returns(memberResult);

        // Act
        var result = _membersController.UpdateMemberAsync(id, updatedMember);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }

    [Fact]
    public void MembersController_RemoveMemberAsync_ReturnsMembers()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var success = A.Fake<ServiceResponse<bool>>();
        A.CallTo(() => _memberRepository.RemoveMemberAsync(id)).Returns(success);

        // Act
        var result = _membersController.RemoveMemberAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<IActionResult>>();
    }
}