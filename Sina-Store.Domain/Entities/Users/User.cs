using Sina_Store.Domain.Entities.Commons;

namespace Sina_Store.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        //public long id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserInRole> UserInRole { get; set; }
    }
}
