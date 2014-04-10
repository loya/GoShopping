using GoShopping.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoShopping.Data
{
    public class GoShoppingDbContext:DbContext
    {
        public DbSet<Video> Videos { get; set; }

    }
}
