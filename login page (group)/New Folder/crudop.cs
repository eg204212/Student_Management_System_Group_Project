using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_Group_4115_4212.NewFolder
{
    public class crudop
    {

        [Key]
        public string StuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string StuEmail { get; set; }
        public string RegUsername { get; set; }
        public string RegPassword { get; set; }



    }
}
