using IronMaidenRegistry.DTOs.Member;

namespace IronMaidenRegistry.Infrastructure.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly Func<AppDbContext, Guid, Task<MemberResult?>> GetById =
        EF.CompileAsyncQuery((AppDbContext context, Guid id) =>

            context.Members.Select(m => new MemberResult
            {
                Id = m.Id,
                FullName = m.FullName,
                BirthDate = m.BirthDate
            })
            .AsNoTracking()
            .FirstOrDefault(i => i.Id == id));

    private readonly AppDbContext _dbContext;
    public MemberRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ServiceResponse<List<MemberResult>>> GetAllMembersAsync()
    {
        var serviceResponse = new ServiceResponse<List<MemberResult>>();

        try
        {
            var members = await _dbContext
                .Database
                .SqlQueryRaw<MemberResult>("""
                                            SELECT MemberId AS MemberId,
                                                   FullName AS FullName,
                                                   BirthDate AS BirthDate
                                            FROM Members;
                                            """)
                                            .AsNoTracking()
                                            .ToListAsync();

            if (members is null)
                throw new Exception("Members list is empty!");

            var membersMapped = new List<MemberResult>();

            foreach (var member in members)
            {
                var memberResult = new MemberResult()
                {
                    Id = member.Id,
                    FullName = member.FullName,
                    BirthDate = member.BirthDate
                };

                membersMapped.Add(memberResult);
            }

            serviceResponse.Data = membersMapped;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<MemberResult>> GetMemberByIdAsync(Guid id)
    {
        var serviceResponse = new ServiceResponse<MemberResult>();

        try
        {
            var member = await GetById(_dbContext, id);

            if (member is null)
                throw new Exception($"Member with id {id} no found!");

            serviceResponse.Data = member;
        }

        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }
}