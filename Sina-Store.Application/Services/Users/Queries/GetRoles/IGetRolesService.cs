using Sina_Store.Common.Dto;

namespace Sina_Store.Application.Services.Users.Queries.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();

    }
}
