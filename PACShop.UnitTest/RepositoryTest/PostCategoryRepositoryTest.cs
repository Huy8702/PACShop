using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using PACShop.Data.Infrastructure;
using PACShop.Data.Repositories;
using PACShop.Model.Models;

namespace PACShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.ID);
        }

        [TestMethod]
        public void PostCategory_Repository_Delete()
        {
            var result = objRepository.Delete(3);           
            Assert.AreEqual(3, result.ID);
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(4, list.Count);
        }

    }
}