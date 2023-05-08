namespace Sina_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUserDTO Execute(RequestGetUserDTO request);
    }
}
