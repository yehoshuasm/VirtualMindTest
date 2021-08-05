using System.ComponentModel.DataAnnotations;

namespace VirtualMindApi.Database.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
