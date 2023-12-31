using IronMaidenRegistry.DTOs.Member;

namespace IronMaidenRegistry.Interfaces;

public interface IMemberRepository
{
    Task<ServiceResponse<List<MemberResult>>> GetAllMembersAsync();
    Task<ServiceResponse<MemberResult>> GetMemberByIdAsync(Guid id);
    Task<ServiceResponse<MemberResult>> AddMemberAsync(MemberInput newMember);
    Task<ServiceResponse<MemberResult>> UpdateMemberAsync(Guid id, MemberInput updatedMember);
    Task<ServiceResponse<bool>> RemoveMemberAsync(Guid id);
}