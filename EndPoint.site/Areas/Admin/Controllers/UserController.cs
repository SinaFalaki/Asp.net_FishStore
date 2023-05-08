using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sina_Store.Application.Services.Users.Commands.EditUser;
using Sina_Store.Application.Services.Users.Commands.RegisterUser;
using Sina_Store.Application.Services.Users.Commands.RemoveUser;
using Sina_Store.Application.Services.Users.Commands.UserSatusChange;
using Sina_Store.Application.Services.Users.Queries.GetRoles;
using Sina_Store.Application.Services.Users.Queries.GetUsers;
using static Sina_Store.Application.Services.Users.Commands.RegisterUser.RegisterUserService;


namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;

        public UserController(IGetUsersService getUsersService,
                              IGetRolesService getRolesService,
                              IRegisterUserService registerUserService
                            , IRemoveUserService removeUserService
                            , IUserSatusChangeService userSatusChangeService
                            , IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }

        public IActionResult Index(string SearchKey, int Page = 1)
        {
            return View(_getUsersService.Execute(new RequestGetUserDTO
            {

                SearchKey = SearchKey,
                Page = Page
            }));
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                roles = new List<RolesInRegisterUserDto>()
                   {
                        new RolesInRegisterUserDto
                        {
                             Id= RoleId
                        }
                   },
                Password = Password,
                RePasword = RePassword,
            });
            return Json(result);
        }

        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_removeUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long UserId)
        {
            return Json(_userSatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string Fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = Fullname,
                UserId = UserId,
            }));
        }

    }
}
