using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoShopping.Business;
using Keigen.Utility;
namespace GoShopping.Service
{
    public interface IGoShoppingUow
    {
        void Save();
        IRepository<Video> Videos { get; }
        
    }
}
