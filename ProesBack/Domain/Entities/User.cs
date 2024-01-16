using ProesBack.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
namespace ProesBack.Domain.Entities
{
    public class User : BaseModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public long loginId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PictureUrl { get; set; }
    }
}
