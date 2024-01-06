using IronMaidenRegistry.Domain.Entities;
using IronMaidenRegistry.DTOs.Member;
using IronMaidenRegistry.Infrastructure.Data;
using IronMaidenRegistry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IronMaidenRegistry.Tests.Repository;

public class MemberRepositoryTests
{
    private readonly AppDbContext _dbContext;
    private readonly MemberRepository _memberRepository;

    public MemberRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _dbContext = new AppDbContext(options);
        _dbContext.Database.EnsureDeletedAsync();

        if (_dbContext.Members.Count() <= 0)
            for (int i = 0; i < 10; i++)
            {
                _dbContext.Members.AddAsync(
                    new Member
                    {
                        Id = Guid.NewGuid(),
                        FullName = "Nem Member Test",
                        BirthDate = new DateOnly(1993, 08, 04),
                        InstrumentId = Guid.NewGuid()
                    });

                _dbContext.SaveChangesAsync();
            }

        _memberRepository = new MemberRepository(_dbContext);
    }

    [Fact]
    public void MemberRepository_AddMemberAsync_ReturnsMemberResult()
    {
        // Arrange
        var memberInput = new MemberInput("New member Test", new DateOnly(1993, 08, 04), Guid.NewGuid());

        // Act
        var result = _memberRepository.AddMemberAsync(memberInput);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<MemberResult>>>();
    }

    [Fact]
    public void MemberRepository_GetAllMembersAsync_ReturnsListMemberResult()
    {
        // Arrange

        // Act

        // Assert
    }

    [Fact]
    public void MemberRepository_GetMemberByIdAsync_ReturnsMemberResult()
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act
        var result = _memberRepository.GetMemberByIdAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<MemberResult>>>();
    }

    [Fact]
    public void MemberRepository_RemoveMemberAsync_ReturnsSuccess()
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act
        var result = _memberRepository.RemoveMemberAsync(id);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<bool>>>();
    }

    [Fact]
    public void MemberRepository_UpdateMemberAsync_ReturnsMemberResult()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        var memberInput = new MemberInput("Updated Member Test", new DateOnly(2010, 07, 22), Guid.NewGuid());

        // Act
        var result = _memberRepository.UpdateMemberAsync(id, memberInput);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Task<ServiceResponse<MemberResult>>>();
    }
}