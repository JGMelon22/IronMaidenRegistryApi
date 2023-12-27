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
    public async Task<IActionResult> GetAllMembersAsync(Guid id)
    {
        var member = await _repository.GetMemberByIdAsync(id);

        return member.Data != null
            ? Ok(member)
            : NotFound();
    }
}