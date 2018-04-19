using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.Core.DataAccess.EntityFramework
{
    // DbContext sınıflarızı singleton pattern'e göre üreteceğiz.
    class EFDbContextSingleton<TContext>
        where TContext : DbContext, new()
    {
        private static TContext _context;

        private EFDbContextSingleton()
        {

        }

        public static TContext Instance
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context;
            }
        }
    }
}
