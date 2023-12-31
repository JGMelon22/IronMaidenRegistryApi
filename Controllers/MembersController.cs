using IronMaidenRegistry.DTOs.Member;

namespace IronMaidenRegistry.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberRepository _repository;

    public MembersController(IMemberRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMembersAsync()
    {
        var members = await _repository.GetAllMembersAsync();

        return members.Data != null
            ? Ok(members)
            : NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMemberByIdAsync(Guid id)
    {
        var member = await _repository.GetMemberByIdAsync(id);

        return member.Data != null
            ? Ok(member)
            : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddMemberAsync(MemberInput newMember)
    {
        var member = await _repository.AddMemberAsync(newMember);
        return member.Data != null
            ? Ok(member)
            : BadRequest(member);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateMemberAsync(Guid id, MemberInput updatedMember)
    {
        var member = await _repository.UpdateMemberAsync(id, updatedMember);
        return member.Data != null
            ? Ok(member)
            : NotFound(member);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveMemberAsync(Guid id)
    {
        var member = await _repository.RemoveMemberAsync(id);
        return member.Success
            ? NoContent()
            : BadRequest(member);
    }
}