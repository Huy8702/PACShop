using PACShop.Data;

namespace PACShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private PACShopDbContext dbContext;

        public PACShopDbContext Init()
        {
            return dbContext ?? (dbContext = new PACShopDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}