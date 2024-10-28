using System;

namespace PACShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        PACShopDbContext Init();
    }
}