using Swashbuckle.AspNetCore.Annotations;

namespace ProesBack.Domain.Entities
{
    public class BaseModel
    {
        [SwaggerSchema(ReadOnly = true)]
        public virtual long Id { get; set; }
    }
}
