using GoShopping.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Keigen.Utility;
using GoShopping.Business;
namespace GoShopping.Service
{
    public class GoShoppingUow:IGoShoppingUow,IDisposable
    {
        private DbContext DbContext { get; set; }

        public GoShoppingUow()
        {
            DbContext = new GoShoppingDbContext();
            Videos = new GeneralRepository<Video>(DbContext);
        }

        #region IGoShoppingUow 成员

        public void Save()
        {
            DbContext.SaveChanges();
        }

        public Keigen.Utility.IRepository<Business.Video> Videos
        {
            get;
            private set; 
        }

        #endregion

        public void Dispose()
        {
            Dispose(true);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext!=null)
                {
                    DbContext.Dispose();
                }
            }
        }
    }
}
