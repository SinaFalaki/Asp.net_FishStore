using Sina_Store.Domain.Entities.Commons;

namespace Sina_Store.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        // public long id { get; set; }
        public string name { get; set; }

        public ICollection<UserInRole> UserInRole { get; set; }

    }
}
