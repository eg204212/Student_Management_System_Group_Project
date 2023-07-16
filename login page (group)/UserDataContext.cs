using SQL_Group_4115_4212.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQL_Group_4115_4212.NewFolder;


namespace SQL_Group_4115_4212
{
    public class UserDataContext: DbContext
    {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = DataFile.db");
        }


        public DbSet<crudop>? Crudops { get; set; }
    }
}
