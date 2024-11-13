using PACShop.Common;
using PACShop.Data.Infrastructure;
using PACShop.Data.Repositories;
using PACShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACShop.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
        IEnumerable<Slide> GetSlides();
    }
    public class CommonService : ICommonService
    {
        IFooterRepository _footerRepository;
        IUnitOfWork _unitOfWork;
        ISlideRepository _sliderepository;
        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork, ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _sliderepository = slideRepository;
        }
        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }

        public IEnumerable<Slide> GetSlides()
        {
            return _sliderepository.GetMulti(x=>x.Status);
        }
    }
}
