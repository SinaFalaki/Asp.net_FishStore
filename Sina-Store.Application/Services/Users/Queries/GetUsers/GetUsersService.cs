using Sina_Store.Application.Interfaces.Contexts;
using Sina_Store.Common;

namespace Sina_Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;
        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDTO Execute(RequestGetUserDTO request)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;
            var UserList = users.ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUsersDTO
            {
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
                IsActive = p.IsActive
            }).ToList();

            return new ResultGetUserDTO
            {
                Rows = rowsCount,
                Users = UserList
            };
        }
    }
}
