namespace PACShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}