using ProesBack.Domain.Enums;

namespace ProesBack.Domain.Entities
{
    public class User : BaseModel
    {
        public int loginId { get; set; }
        public UserType UserType { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PictureUrl { get; set; }
    }
}
