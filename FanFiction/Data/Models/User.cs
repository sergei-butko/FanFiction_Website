using System.ComponentModel.DataAnnotations;

namespace FanFiction.Data.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)] public string Email { get; set; }
    }
}