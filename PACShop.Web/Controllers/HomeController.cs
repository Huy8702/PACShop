using AutoMapper;
using PACShop.Model.Models;
using PACShop.Service;
using PACShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PACShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;
        IProductService _productService;
        ICommonService _commonService;

        public HomeController(IProductCategoryService productCategoryService, 
            IProductService productService,
            ICommonService commonService)
        {
            _productCategoryService = productCategoryService;
            _commonService = commonService;
            _productService = productService;
        }

        // GET: Home
        public ActionResult Index()
        {
            var slidemodel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>,IEnumerable < SlideViewModel>>(slidemodel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var lastestProductModel = _productService.GetLastest(3);
            var topSaleProductModel = _productService.GetHotProduct(3);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topSaleProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topSaleProductModel);
            homeViewModel.LastestProducts = lastestProductViewModel;
            homeViewModel.TopSaleProducts = topSaleProductViewModel;

            return View(homeViewModel);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footerModel = _commonService.GetFooter();
            var footerViewModel = Mapper.Map<Footer, FooterViewModel>(footerModel);
            return PartialView(footerViewModel);
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return PartialView(listProductCategoryViewModel);
        }

    }
}