using System.ComponentModel.DataAnnotations;

namespace SQL_Group_4115_4212.NewFolder
{
    internal class Admin
    {
        [Key]
        public string? AdminName { get; set; }
        public string? AdminPassWord { get; set; }

    }
}
