using System.ComponentModel.DataAnnotations;

namespace SQL_Group_4115_4212.NewFolder
{
    public class User
    {
        [Key]
        public string? UserName { get; set; }
        public string? UserPassWord { get; set; }
       
    }
}